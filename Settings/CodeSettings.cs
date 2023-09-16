using Microsoft.Win32;
using System;
using System.Collections;
using System.Windows.Forms;

namespace IDE
{
    public partial class CodeSettings : Form
    {
        private int i = 1;
        private int addY = 35;
        private bool ReadOnly = true;
        private Main main;
        public RegistryKey HKLM, software, IDE, IDE_cfg;

        public CodeSettings()
        {
            InitializeComponent();
            this.Owner = new Main();
            main = (Main)this.Owner;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            HKLM = Registry.LocalMachine;
            software = HKLM.OpenSubKey(@"SOFTWARE", true);
            IDE = software.CreateSubKey("RYCB", true).CreateSubKey("IDE", true);
            IDE_cfg = IDE.CreateSubKey("code_cfg");
        }

        private void addNewCS(object sender, EventArgs e)
        {
            listBox1.Items.Add($"新建配置{i}");
            textBox1.Text = $"新建配置{i}";
            listBox1.SelectedItem = $"新建配置{i}";
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            ReadOnly = false;
            i++;
        }

        private void minusCS(object sender, EventArgs e)
        {
            try
            {
                IDE_cfg.DeleteSubKey(textBox1.Text);
                listBox1.Items.Remove(listBox1.SelectedItem);
                i--;
            }
            catch (Exception)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                i--;
            }
        }

        private void copyCS(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Add(listBox1.SelectedItem);
            }
            catch (Exception)
            {

            }
        }

        private void CodeSettings_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (var settings in IDE_cfg.GetSubKeyNames())
                {
                    listBox1.Items.Add(settings);
                }
            }
            catch { }
        }

        private void changeText(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
                try
                {
                    foreach (var settings in IDE_cfg.GetSubKeyNames())
                    {
                        if (settings == listBox1.SelectedItem.ToString())
                        {
                            textBox2.Text = (string)IDE_cfg.OpenSubKey(settings).GetValue("path");
                            textBox3.Text = (string)IDE_cfg.OpenSubKey(settings).GetValue("params");
                            textBox4.Text = (string)IDE_cfg.OpenSubKey(settings).GetValue("interpreter");
                            textBox5.Text = (string)IDE_cfg.OpenSubKey(settings).GetValue("interpreter_params");
                        }
                    }
                }
                catch { }
                button5.Hide();
            }
            else
            {
                textBox1.Clear();
            }
        }

        private void Sync(object sender, EventArgs e)
        {

        }


        private void changeConfigName(object sender, EventArgs e)
        {
            button5.Show();
        }

        private void autoAddParam(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals("cmd") | textBox4.Text.Equals("cmd.exe"))
            {
                textBox5.Text = "/s /c";
                saveConfig(sender, e);
            }
            else if (textBox4.Text.Equals("python"))
            {
                saveConfig(sender, e);
            }
        }

        private void saveConfig(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                listBox1.Items[listBox1.SelectedIndex] = textBox1.Text;
                var cc = IDE_cfg.CreateSubKey(textBox1.Text);
                cc.SetValue("name", textBox1.Text);
                cc.SetValue("path", textBox2.Text);
                cc.SetValue("params", textBox3.Text);
                cc.SetValue("interpreter", textBox4.Text);
                cc.SetValue("interpreter_params", textBox5.Text);
            }
        }

        private void openScript(object sender, EventArgs e)
        {
            if (!ReadOnly)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = openFileDialog1.FileName;
                }
            }
        }

        private void tBox4_openScript(object sender, EventArgs e)
        {
            if (!ReadOnly)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox4.Text = openFileDialog1.FileName;
                }
            }
        }
    }
}
