using Sunny.UI;
using System.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace IDE
{
    public partial class CustomSettings : UIForm
    {
        private static string _path, _path_oringin;

        public CustomSettings(string path)
        {
            InitializeComponent();
            _path = path + "\\Xshd";
            _path_oringin = path + "\\Xshd";
            //SettingsHandler.SetSettings(path, 0);
            var language = GlobalSuppressions.language_set.FirstOrDefault(q => q.Value == GlobalSuppressions.language).Key;
            uiComboBox1.SelectedItem = language;
            uiComboBox1.Text = language;
        }

        private void ChooseXshdFile(object sender, System.EventArgs e)
        {
            if (XshdFileFinder.ShowDialog() == DialogResult.OK)
            {
                CBoxXshdFile.Items.Add(XshdFileFinder.FileName);
                File.Copy(XshdFileFinder.FileName, _path + XshdFileFinder.FileName.SplitLast("\\"), true);
            }
        }

        private void PickDiretory(object sender, System.EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ChangeCachePath(sender, e);
            }
        }

        private void ChangeLanguage(object sender, EventArgs e)
        {
            string selectedLanguage = uiComboBox1.Text;
            if (selectedLanguage != GlobalSuppressions.language)
            {
                GlobalSuppressions.language = GlobalSuppressions.language_set[selectedLanguage];
                Program.reConf.Write("general", "language", GlobalSuppressions.language_set[selectedLanguage]);
                errorProvider1.SetError(uiComboBox1, "重启应用程序后生效");
            }
        }


        private void ChangeCachePath(object sender, System.EventArgs e)
        {
            try
            {
                foreach (var item in Directory.EnumerateFiles(_path_oringin))
                {
                    File.Copy(item,
                        folderBrowserDialog1.SelectedPath + '\\' + item.Split('\\')[item.Split('\\').Length - 1],
                        true);
                }
            }
            catch (Exception ex)
            {
                Main.LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                return;
            }
            txtBoxXshdCache.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
