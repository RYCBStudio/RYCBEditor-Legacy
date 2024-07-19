using Sunny.UI;
using System;
using System.Text.RegularExpressions;

namespace IDE
{
    public partial class FrmNewFileBox : UIForm
    {

        private FileStatus Status;

        public FrmNewFileBox()
        {
            InitializeComponent();
            InitializeLocalizate();
        }

        public FrmNewFileBox(string title)
        {
            InitializeComponent();
            InitializeLocalizate();
            this.Text = title;
        }

        public string Lb_FileName
        {
            get; set;
        }

        public enum FileStatus
        {
            Successful,
            Failed
        }

        public FileStatus GetStatus()
        {
            return Status;
        }

        private void AddSuffix(object sender, EventArgs e)
        {
            Regex fileName = new("^\\w+\\.+\\w+");
            if (((UIListBox)sender).SelectedItem is string _text)
            {
                if (!fileName.IsMatch(uiTextBox1.Text))
                {
                    var _ = uiTextBox1.Text.Split('.')[0];
                    uiTextBox1.Text = _;
                    if (_text.Equals("Py-CN"))
                    {
                        if (!uiTextBox1.Text.EndsWith(".pycn", true, System.Globalization.CultureInfo.CurrentCulture))
                        {
                            uiTextBox1.Text += ".pycn";
                        }
                    }
                    else if (_text.Equals("Python"))
                    {
                        if ((!uiTextBox1.Text.EndsWith(".py", true, System.Globalization.CultureInfo.CurrentCulture)) || (!uiTextBox1.Text.EndsWith(".pyw", true, System.Globalization.CultureInfo.CurrentCulture)))
                        {
                            uiTextBox1.Text += ".py";
                        }
                    }
                    else if (_text.Equals("*"))
                    {
                        Regex regex = new("^\\w+\\.+\\w+");
                        if (!regex.IsMatch(uiTextBox1.Text))
                        {
                            uiTextBox1.Text += ".txt";
                        }
                    }
                    else if (_text.Equals("C#"))
                    {
                        if (!uiTextBox1.Text.EndsWith(".cs", true, System.Globalization.CultureInfo.CurrentCulture))
                        {
                            uiTextBox1.Text += ".cs";
                        }
                    }
                    else if (_text.Equals("Markdown"))
                    {
                        if ((!uiTextBox1.Text.EndsWith(".md", true, System.Globalization.CultureInfo.CurrentCulture)) || (!uiTextBox1.Text.EndsWith(".markdown", true, System.Globalization.CultureInfo.CurrentCulture)))
                        {
                            uiTextBox1.Text += ".md";
                        }
                    }
                }
                else
                {
                    if (_text.Equals("Py-CN"))
                    {
                        if (!uiTextBox1.Text.EndsWith(".pycn", true, System.Globalization.CultureInfo.CurrentCulture))
                        {
                            var tmpStr = uiTextBox1.Text;
                            uiTextBox1.Clear();
                            uiTextBox1.Text += tmpStr.Split('.')[0] + ".pycn";
                        }
                    }
                    else if (_text.Equals("Python"))
                    {
                        if ((!uiTextBox1.Text.EndsWith(".py", true, System.Globalization.CultureInfo.CurrentCulture)) || (!uiTextBox1.Text.EndsWith(".pyw", true, System.Globalization.CultureInfo.CurrentCulture)))
                        {
                            var tmpStr = uiTextBox1.Text;
                            uiTextBox1.Clear();
                            uiTextBox1.Text += tmpStr.Split('.')[0] + ".py";
                        }
                    }
                    else if (_text.Equals("*"))
                    {
                        Regex regex = new("^\\w+\\.+\\w+");
                        if (!regex.IsMatch(uiTextBox1.Text))
                        {
                            uiTextBox1.Text += ".txt";
                        }
                    }
                    else if (_text.Equals("C#"))
                    {
                        if (!uiTextBox1.Text.EndsWith(".cs", true, System.Globalization.CultureInfo.CurrentCulture))
                        {
                            var tmpStr = uiTextBox1.Text;
                            uiTextBox1.Clear();
                            uiTextBox1.Text += tmpStr.Split('.')[0] + ".cs";
                        }
                    }
                    else if (_text.Equals("Markdown"))
                    {
                        if ((!uiTextBox1.Text.EndsWith(".md", true, System.Globalization.CultureInfo.CurrentCulture)) || (!uiTextBox1.Text.EndsWith(".markdown", true, System.Globalization.CultureInfo.CurrentCulture)))
                        {
                            var tmpStr = uiTextBox1.Text;
                            uiTextBox1.Clear();
                            uiTextBox1.Text += tmpStr.Split('.')[0] + ".md";
                        }
                    }
                }
            }
        }

        public string GetFileName()
        {
            return uiTextBox1.Text;
        }

        private void Close(object sender, EventArgs e)
        {
            if (((UIButton)sender).Text == "确定"| ((UIButton)sender).Text == "Create")
            {
                Status = FileStatus.Successful;
            }
            else
            {
                Status = FileStatus.Failed;
            }

            Close();
        }
    }
}

