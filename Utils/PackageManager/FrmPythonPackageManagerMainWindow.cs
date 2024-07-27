using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sunny.UI;
using IDE.Utils.Boxes.PackageManager;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace IDE.Utils;
public partial class PythonPackageManagerMain : UIForm
{

    private List<string> packageNames = [];
    private Dictionary<string, Dictionary<string, string>> packageInfo = [];
    private FrmPyPiSearcherUI psui;
    internal static FrmPackageManagerProgressWindow pw;

    public PythonPackageManagerMain()
    {
        InitializeComponent();
        InitializeLocalization();
    }

    private void GetAllPackages()
    {
        packageNames.Clear();
        Process pip = new()
        {
            StartInfo = new ProcessStartInfo()
            {
                Arguments = $"list --format=freeze",
                FileName = "pip",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            }
        };
        pip.Start();
        var output = pip.StandardOutput.ReadToEnd();
        foreach (var item in output.Split(["\r", "\n", "\r\n"], StringSplitOptions.RemoveEmptyEntries))
        {
            packageNames.Add($"{item.Split('=')[0]}");
        }
        pip.Dispose();
    }

    private string GetPackageStatus(string name)
    {
        Process pip = new();
        var filename = GlobalSettings.commonTempFilePath;
        pip.StartInfo = new ProcessStartInfo()
        {
            Arguments = $"show {name} > {filename}",
            FileName = "pip",
            CreateNoWindow = true,
            UseShellExecute = true,
            WindowStyle = ProcessWindowStyle.Hidden
        };
        pip.Start();
        if (File.ReadAllText(filename).Contains("not found"))
        {
            return "nf";
        }
        else
        {
            return "i";
        }
    }

    private Dictionary<string, string> AnalyzePackageInfo(string name)
    {
        Dictionary<string, string> ret = [];
        var pip = new Process
        {
            StartInfo = new()
            {
                Arguments = $"show {name}",
                FileName = "pip",
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
            }
        };
        pip.Start();
        var __ = pip.StandardOutput.ReadToEnd();
        if (__.IsNullOrEmpty()) { ret.Add("Error", pip.StandardError.ReadToEnd()); return ret; }
        var output = __.Split(new string[] { "\r", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries); ;
        List<string> content = ["[.]"];
        foreach (var item in output)
        {
            content.Add($"{item.Replace(": ", "=")}");
        }
        File.WriteAllLines($"{GlobalSettings.commonTempFilePath}", content);
        IniFile _ = new($"{GlobalSettings.commonTempFilePath}", System.Text.Encoding.UTF8);
        ret.Add("loca", _.ReadString(".", "Location", ""));
        ret.Add("rq-by_pkg", _.ReadString(".", "Required-by", ""));
        ret.Add("rq_pkg", _.ReadString(".", "Requires", ""));
        ret.Add("sum", _.ReadString(".", "Summary", ""));
        ret.Add("ver", _.ReadString(".", "Version", ""));
        ret.Add("status", GetPackageStatus(name));
        ret.Add("aut", _.ReadString(".", "Author", ""));
        ret.Add("lic", _.ReadString(".", "License", ""));
        ret.Add("name", _.ReadString(".", "Name", ""));
        pip.StandardOutput.Dispose();
        pip.Dispose();
        return ret;
    }

    private Bitmap GetSuitableIcon(string status)
    {
        return status switch
        {
            "nf" => Properties.Resources.install_line,
            "i" => Properties.Resources.plugin_uninst,
            _ => null,
        };
    }

    private string GetStatusRawText(string status)
    {
        return "text.ppmm.status." + status;
    }

    private void ClickSearchButton(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Search(sender, e);
        }
    }

    private void Search(object sender, EventArgs e)
    {
        var containsKeyword = false;
        var startswithKeyword = false;
        var matchedItem = "";
        foreach (var item in packageNames)
        {
            if (item.ToLower().StartsWith(uiTextBox1.Text.ToLower()))
            {
                startswithKeyword = true;
                matchedItem = item;
                break;
            }
        }
        if (!startswithKeyword)
        {
            foreach (var item in packageNames)
            {
                if (item.ToLower().Contains(uiTextBox1.Text.ToLower()))
                {
                    containsKeyword = true;
                    matchedItem = item;
                    break;
                }
            }
        }
        if (startswithKeyword || containsKeyword)
        {
            uiListBox1.SelectedItem = matchedItem;
        }
        else
        {
            var res = MessageBoxEX.Show(_I18nFile.Localize("text.ppmm.pkg.notfound"), _I18nFile.Localize("text.ppmm.pkg.tip"), MessageBoxButtons.AbortRetryIgnore, [_I18nFile.Localize("text.ppmm.pkg.notfound.import"), _I18nFile.Localize("text.ppmm.pkg.notfound.search"), _I18nFile.Localize("text.ppmm.pkg.notfound.cancel")]);
            if (res == DialogResult.Abort)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var pip = new Process()
                    {
                        StartInfo = new()
                        {
                            Arguments = "install " + openFileDialog1.FileName,
                            FileName = "pip",
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            UseShellExecute = false,
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden,
                        }
                    };
                    pip.Start();
                    var output = pip.StandardOutput.ReadToEnd();
                    var error = pip.StandardError.ReadToEnd();
                    if (error.IsNullOrEmpty() & (output.Contains("Successfully installed") || output.Contains("Requirement already satisfied")))
                    {
                        MessageBox.Show(string.Format(_I18nFile.Localize("text.ppmm.pkg.inst.suc"), Path.GetFileNameWithoutExtension(openFileDialog1.FileName)), "tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"{_I18nFile.Localize("text.ppmm.pkg.inst.fail")} \n{error}", "tip", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    pip.Close();
                    var handler = new Action(() => pw.ShowDialog());
                    handler.BeginInvoke(null, null);
                    InitPkg();
                }
            }
            else if (res == DialogResult.Retry)
            {
                var pkgname = uiTextBox1.Text;
                psui.query = pkgname;
                psui.Show();
                InitPkg();
            }
        }
    }

    private void PackageManagerMain_Shown(object sender, EventArgs e)
    {
        psui = new();
        pw = new(0, packageNames.Count, true, _I18nFile.Localize("text.ppmm.pkg.processing"));
        pw.progressBar1.Hide();
        var handler = new Action(() => pw.ShowDialog());
        handler.BeginInvoke(null, null);
        pw.TopMost = true;
        GetAllPackages();
        InitPkg();
        this.Focus();
    }

    internal void InitPkg()
    {
        var si = uiListBox1.SelectedIndex;
        GetAllPackages();
        uiListBox1.Items.Clear();
        if (si == -1)
        {
            si = 0;
        }
        pw.uiProcessBar1.Maximum = packageNames.Count;
        for (var i = 0; i < packageNames.Count; i++)
        {
            uiListBox1.Items.Add(packageNames[i]);
            pw.uiProcessBar1.Value = i+1;
        }
        uiListBox1.SelectedIndex = si;
    }

    private void PackageManagerMain_Load(object sender, EventArgs e)
    {
        uiListBox1.Items.Clear();
    }

    private void ChangeStatus(object sender, EventArgs e)
    {
        if (MessageBox.Show("text.ppmm.pkg.uninstconfirm", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            try
            {
                pw.Update(0, 100, true, _I18nFile.Localize("text.ppmm.pkg.uninst"));
                pw.uiProcessBar1.Hide();
                var handler = new Action(() => pw.ShowDialog());
                handler.BeginInvoke(null, null);
            }
            catch
            {
                var pw = new FrmPackageManagerProgressWindow();
                pw.Update(0, 100, true, _I18nFile.Localize("text.ppmm.pkg.uninst"));
                pw.uiProcessBar1.Hide();
                var handler = new Action(() => pw.ShowDialog());
                handler.BeginInvoke(null, null);
            }
            pw.progressBar1.Show();
            var pip = new Process
            {
                StartInfo = new()
                {
                    Arguments = $"uninstall {uiListBox1.SelectedItem}",
                    FileName = "pip",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                },
            };
            pip.Start();
            pip.StandardInput.WriteLine("y");
            if (pip.StandardOutput.ReadToEnd().Contains("Successfully uninstalled"))
            {
                MessageBox.Show(string.Format(_I18nFile.Localize("text.ppmm.pkg.uninst.suc"), uiListBox1.SelectedItem));
            }
            pw.Hide();
            InitPkg();
        }
    }

    private void PackageManagerMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.Hide();
        e.Cancel = true;
    }

    private void Refresh(object sender, EventArgs e)
    {
        InitPkg();
    }

    private void GetPkgInfo(object sender, EventArgs e)
    {
        if (packageNames.Count == uiListBox1.Items.Count)
        {
            Dictionary<string, string> res;
            if (uiListBox1.SelectedItem.ToString().Equals("ConfigParser", StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }
            if (packageInfo.ContainsKey(uiListBox1.SelectedItem.ToString()))
            {
                res = packageInfo[uiListBox1.SelectedItem.ToString()];
            }
            else
            {
                res = AnalyzePackageInfo(packageNames[uiListBox1.SelectedIndex]);
                try
                {
                    packageInfo.Add(uiListBox1.SelectedItem.ToString(), res);
                }
                catch { }
            }
            uiTextBox2.Text = res["name"];
            uiTextBox4.Text = res["aut"];
            uiTextBox5.Text = res["ver"];
            uiTextBox6.Text = res["sum"];
            uiTextBox3.Text = res["lic"];
            uiTextBox7.Text = res["rq_pkg"];
            uiTextBox8.Text = res["rq-by_pkg"];
            uiTextBox9.Text = res["loca"];
            label4.Text = _I18nFile.Localize(GetStatusRawText(res["status"]));
        }
        else
        {
            try
            {
                Dictionary<string, string> res;
                if (packageInfo.ContainsKey(uiListBox1.SelectedItem.ToString()))
                {
                    res = packageInfo[uiListBox1.SelectedItem.ToString()];
                }
                else
                {
                    res = AnalyzePackageInfo(packageNames[uiListBox1.SelectedIndex]);
                    if (res.ContainsKey("Error")) { return; }
                    packageInfo.Add(uiListBox1.SelectedItem.ToString(), res);
                }
                uiTextBox2.Text = res["name"];
                uiTextBox4.Text = res["aut"];
                uiTextBox5.Text = res["ver"];
                uiTextBox6.Text = res["sum"];
                uiTextBox3.Text = res["lic"];
                uiTextBox7.Text = res["rq_pkg"];
                uiTextBox8.Text = res["rq-by_pkg"];
                uiTextBox9.Text = res["loca"];
                label4.Text = _I18nFile.Localize(GetStatusRawText(res["status"]));
            }
            catch (Exception ex)
            {
                FrmMain.LOGGER.Err(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
            }
        }
    }

    private void CfgPypiSource(object sender, EventArgs e)
    {
        var res = "-1";
        Regex uri = new("^http(s)://([\\w-]+\\.)+[\\w-]+(/[\\w-./?%&=]*)?$");
        UIInputDialog.InputStringDialog(ref res, true, _I18nFile.Localize("text.ppmm.cfgpypisource.title"));
        if (uri.IsMatch(res))
        {
            var myRequest = (HttpWebRequest)WebRequest.Create(res);
            myRequest.UseDefaultCredentials = true;
            myRequest.Method = "HEAD";
            myRequest.Timeout = 1000;
            myRequest.AllowAutoRedirect = false;
            var myResponse = (HttpWebResponse)myRequest.GetResponse();
            var canAccess = myResponse.StatusCode == HttpStatusCode.OK;
            if (!canAccess) { MessageBox.Show(_I18nFile.Localize("text.ppmm.cfgpypisource.illegal"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand); return; }
            if (!res.EndsWith("simple"))
            {
                res += "/simple";
            }
            Process.Start("pip config set global.index-url " + res);
            var pip = new Process()
            {
                StartInfo = new()
                {
                    Arguments = "config list",
                    FileName = "pip",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                }
            };
            pip.Start();
            var output = pip.StandardOutput.ReadToEnd();
            Program.reConf.Write("Python", "Pypi.Source", output.Replace("'", "").Split("=", true)[1]);
            myRequest.Abort();
            myResponse.Close();
            pip.StandardOutput.Close();
        }
        else
        {
            MessageBox.Show(_I18nFile.Localize("text.ppmm.cfgpypisource.illegal"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand); return;
        }
    }

    private void ResetPypiSource(object sender, EventArgs e)
    {
        Process.Start("pip config unset global.index-url");
    }

    private void OpenConsole(object sender, EventArgs e)
    {
        Process.Start("cmd");
    }

    private void ImportPackages(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            var pip = new Process()
            {
                StartInfo = new()
                {
                    Arguments = "install -r " + openFileDialog1.FileName,
                    FileName = "pip",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                }
            };
            pip.Start();
            var output = pip.StandardOutput.ReadToEnd();
            var error = pip.StandardError.ReadToEnd();
            if (error.IsNullOrEmpty() & (output.Contains("Successfully installed") || output.Contains("Requirement already satisfied")))
            {
                MessageBox.Show(string.Format(_I18nFile.Localize("text.ppmm.pkg.inst.rtxt.suc"), Path.GetFileName(openFileDialog1.FileName)), "tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"{_I18nFile.Localize("text.ppmm.pkg.inst.fail")} \n{error}", "tip", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            pip.Close();
        }
    }

    private void SearchPypi(object sender, EventArgs e)
    {
        try
        {
            psui.Show();
        }
        catch
        {
            psui = new();
            psui.Show();
        }
    }
}
