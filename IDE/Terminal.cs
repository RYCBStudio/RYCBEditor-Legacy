using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Win32;

namespace IDE
{
    public partial class Terminal : Form
    {
        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        string executePath, param, interpreter, interpreter_params;

        internal Terminal(string executePath, string param, string interpreter, string interpreter_params)
        {
            InitializeComponent();
            this.executePath = executePath;
            this.param = param;
            this.interpreter = interpreter;
            this.interpreter_params = interpreter_params;
        }

        internal void show()
        {
            ProcessStartInfo window = new()
            {
                FileName = interpreter,
                Arguments = GetArguments(),
                WindowStyle = ProcessWindowStyle.Normal,
            };
            Process.Start(window);
            while (User.FindWindow("Python", "Python") == 0) ;
            int handle = User.FindWindow("Python", "Python");
            User.SetParent((IntPtr)handle, this.panel1.Handle);
            //MessageBox.Show($"{interpreter} {GetArguments()}");
            //Process.Start(interpreter, GetArguments()).WaitForExit();
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Min(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private string GetArguments()
        {
            return $"{interpreter_params} \"{executePath}\" {param}";
        }
    }
}
