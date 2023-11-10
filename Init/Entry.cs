using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace IDE
{
    public partial class Entry : Form
    {
        private bool light = false;
        public Entry(bool light)
        {
            InitializeComponent();
            this.light = light;
        }

        public Entry()
        {
            InitializeComponent();
        }

        private void Entry_Load(object sender, EventArgs e)
        {
            if (light)
            {
                uiLabel4.Show();
            }
        }

        #region 执行CMD
        /// <summary>
        /// 执行带返回值的CMD
        /// </summary>
        /// <param name="command">命令</param>
        /// <param name="interpreter">解释器</param>
        /// <param name="interpreter_params">解释器参数</param>
        /// <returns></returns>
        private string ExecuteCMDWithOutput(string command, string interpreter, string interpreter_params)
        {
            ProcessStartInfo processInfo = new(interpreter, $"{interpreter_params} " + command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true
            };

            Process process = new() { StartInfo = processInfo };
            process.Start();
            var outpup = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return outpup;
        }
        #endregion

        #region No Frame Window Dragging Module
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();         //用来释放被当前线程中某个窗口捕获的光标

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwdn, int wMsg, int mParam, int lParam);    //向指定的窗体发送Windows消息
        public const int WM_SYSCOMMAND = 0x0112;                     //该变量表示将向Windows发送的消息类型
        public const int SC_MOVE = 0xF010;                              //该变量表示发送消息的附加消息
        public const int HTCAPTION = 0x0002;                                 //该变量表示发送消息的附加消息

        private void DragNoFrameWindow_MouseDown(object sender, MouseEventArgs e)

        {
            ReleaseCapture();                        //用来释放被当前线程中某个窗口捕获的光标
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);  //向Windows发送拖动窗体的消息
        }
        #endregion

        private void Entry_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Start();
        }

        private void Exit(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (metroProgressBar1.Value == metroProgressBar1.Maximum)
            {
                Close();
            }
        }

        private void Delay(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
