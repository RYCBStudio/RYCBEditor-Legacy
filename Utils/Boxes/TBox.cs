using Sunny.UI;
using System;
using System.Diagnostics;
using System.Management;
using System.Threading;
using System.Windows.Forms;

namespace IDE;
public partial class TBox : UIForm
{
    static Stopwatch w = new();
    static bool successful = false;

    private UIStyle[] Styles = new UIStyle[] { UIStyle.Blue, UIStyle.Colorful, UIStyle.Orange, UIStyle.Red, UIStyle.Purple };

    public TBox()
    {
        InitializeComponent();
        CPUInfo.Text = GetCpuName();
        var diskInfo = GetDiskInfo();
        DiskManufacturer.Text = diskInfo.manufacturer;
        DiskModel.Text = diskInfo.model;
    }

    private void ChangeStyle(object sender, EventArgs e)
    {
        uiStyleManager1.Style = Styles[new Random().Next(Styles.Length)];
        if (successful)
        {
            CPUTestOrigin.Text = w.Elapsed.TotalSeconds.ToString();
            CPUTestScore.Text = Math.Floor(1 / w.Elapsed.TotalSeconds * 100000).ToString();
            uiButton1.Text = "点击开始测试";
        }
    }

    private void CPUTest(object sender, EventArgs e)
    {
        uiButton1.Text = "测试中，请耐心等待";
        w.Restart();
        var pi = new Thread((n) => new PIer().Execute((int)n));
        pi.IsBackground = true;
        pi.Start(20000);
    }

    /// <summary>
    /// 获取CPU名称信息
    /// </summary>
    /// <returns>CPU名称信息</returns>
    public static string GetCpuName()
    {
        var CPUName = "";
        var management = new ManagementObjectSearcher("Select * from Win32_Processor");
        foreach (var baseObject in management.Get())
        {
            var managementObject = (ManagementObject)baseObject;
            CPUName = managementObject["Name"].ToString();
        }
        return Environment.ProcessorCount.ToString() + "x " + CPUName;
    }

    /// <summary>
    /// 获取硬盘厂商信息和硬盘型号信息
    /// </summary>
    /// <returns>包含硬盘厂商信息和硬盘型号信息的元组</returns>
    public static (string manufacturer, string model) GetDiskInfo()
    {
        var searcher = new ManagementObjectSearcher("SELECT * FROM win32_DiskDrive");
        var diskManufacturer = "";
        var diskModel = "";
        foreach (ManagementObject mo in searcher.Get())
        {
            diskManufacturer = mo["Manufacturer"].ToString();
            diskModel = mo["Model"].ToString();
        }
        return (diskManufacturer, diskModel);
    }


    public class PIer
    {
        private int InverseXModuleY(int x, int y)
        {
            var u = x;
            var v = y;
            var c = 1;
            var a = 0;
            do
            {
                var q = v / u;
                var t = c;
                c = a - q * c; a = t; t = u;
                u = v - q * u; v = t;
            } while (u != 0);
            a = a % y;
            if (a < 0) { a = y + a; }
            return a;
        }
        private int MultiplyModule(int a, int b, int m)
        {
            return (int)FloatModule((double)a * (double)b, m);
        }
        private int PowModule(int a, int b, int m)
        {
            var r = 1;
            var aa = a;
            while (true)
            {
                if ((b & 1) != 0) { r = MultiplyModule(r, aa, m); }
                b = b >> 1;
                if (b == 0) { break; }
                aa = MultiplyModule(aa, aa, m);
            }
            return r;
        }
        private int IsPrime(int n)
        {
            int r, i;
            if ((n % 2) == 0) { return 0; }
            r = (int)Math.Sqrt(n);
            for (i = 3; i <= r; i += 2)
            {
                if ((n % i) == 0) { return 0; }
            }
            return 1;
        }
        private int NextPrime(int n)
        {
            do { n++; } while (IsPrime(n) == 0);
            return n;
        }
        private double FloatModule(double a, double b)
        {
            return a - (int)(a / b) * b;
        }
        public int Execute(int n)
        {
            var sum = 0.0;
            var N = (int)((n + 20) * Math.Log(10) / Math.Log(2));
            for (var a = 3; a <= (2 * N); a = NextPrime(a))
            {
                var vmax = (int)(Math.Log(2 * N) / Math.Log(a));
                var av = 1;
                for (var i = 0; i < vmax; i++)
                {
                    av = av * a;
                }
                var s = 0;
                var num = 1;
                var den = 1;
                var v = 0;
                var kq = 1;
                var kq2 = 1;
                int t;
                for (var k = 1; k <= N; k++)
                {
                    t = k;
                    if (kq >= a)
                    {
                        do
                        {
                            t = t / a; v--;
                        } while ((t % a) == 0);
                        kq = 0;
                    }
                    kq++;
                    num = MultiplyModule(num, t, av);
                    t = 2 * k - 1;
                    if (kq2 >= a)
                    {
                        if (kq2 == a)
                        {
                            do
                            {
                                t = t / a; v++;
                            } while ((t % a) == 0);
                        }
                        kq2 -= a;
                    }
                    den = MultiplyModule(den, t, av);
                    kq2 += 2;
                    if (v > 0)
                    {
                        t = InverseXModuleY(den, av);
                        t = MultiplyModule(t, num, av);
                        t = MultiplyModule(t, k, av);
                        for (var i = v; i < vmax; i++)
                        {
                            t = MultiplyModule(t, a, av);
                        }
                        s += t;
                        if (s >= av) { s -= av; }
                    }
                }
                t = PowModule(10, n - 1, av);
                s = MultiplyModule(s, t, av);
                sum = FloatModule(sum + (double)s / (double)av, 1.0);

            }
            w.Stop();
            successful = true;
            return (int)Math.Floor((int)(sum * 1e9) / 1e8);
        }
    }

    private void Transmit(object sender, EventArgs e)
    {
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        this.Hide();

    }

    private void Notch(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("https://www.minecraft.net");
        timer1.Start();
    }

    private void RE(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Application.Exit();
        timer1.Start();
    }

    private void Ingot(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        this.uiTabControlMenu1.SelectedTab = tabPage1;
        CPUTest(uiButton1, e);
        timer1.Start();

    }

    private void Android(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("https://www.android.com/");
        timer1.Start();

    }

    private void Google(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("https://www.google.com/");
        timer1.Start();

    }

    private void Azure(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("https://www.azure.com/");
        timer1.Start();

    }

    private void GoogleTranslate(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("https://translate.google.com/");
        timer1.Start();

    }

    private void Microsoft(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("https://www.microsoft.com");
        timer1.Start();

    }

    private void VisualStudio(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("https://www.visualstudio.com");
        timer1.Start();

    }

    private void Windows(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("https://www.windows.com");
        timer1.Start();

    }

    private void Mail(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("mailto://rycbstudio@163.com");
        timer1.Start();

    }

    private void Crash(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        throw new StackOverflowException("Welcome to visit https://stackoverflow.com!");
        timer1.Start();

    }

    private void Cortana(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("https://support.microsoft.com/zh-cn/topic/%E4%BB%80%E4%B9%88%E6%98%AF-cortana-953e648d-5668-e017-1341-7f26f7d0f825");
        timer1.Start();

    }

    private void Bug(object sender, EventArgs e)
    {

        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        throw new OutOfMemoryException("You can always believe Mojang's update speed!");
        timer1.Start();

    }

    private void Regedit(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("regedit");
        timer1.Start();

    }

    private void Java(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("https://www.oracle.com/java/");
        timer1.Start();

    }

    private void Bugjump(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("https://bugs.mojang.com");
        timer1.Start();

    }

    private void StarRail(object sender, EventArgs e)
    {
        timer1.Stop();
        ((UIButton)sender).Style = UIStyle.Custom;
        ((UIButton)sender).StyleCustomMode = true;
        ((UIButton)sender).BackColor = System.Drawing.Color.Transparent;
        Process.Start("https://hsr.hoyoverse.com");
        timer1.Start();
    }
}
