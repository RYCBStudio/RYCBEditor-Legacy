using Sunny.UI;
using System.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace IDE
{
    public partial class CustomSettings : UIForm
    {
        private static string _path, _path_oringin, tip_1;
        private bool isInitialized = false;

        public CustomSettings(string path)
        {
            InitializeComponent();
            _path = path + "\\Xshd";
            _path_oringin = path + "\\Xshd";
            //SettingsHandler.SetSettings(path, 0);
            var language = GlobalSettings.language_set.FirstOrDefault(q => q.Value == GlobalSettings.language).Key;
            uiComboBox1.SelectedItem = language;
            uiComboBox1.Text = language;
            isInitialized = true;
            errorProvider1.SetError(uiComboBox1, "");
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

        private void CustomSettings_Load(object sender, EventArgs e)
        {
            isInitialized = true;
        }

        private void ChangeLanguage(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                string selectedLanguage = uiComboBox1.Text;
                if (selectedLanguage != GlobalSettings.language)
                {
                    GlobalSettings.language = GlobalSettings.language_set[selectedLanguage];
                    Program.reConf.Write("General", "Language", GlobalSettings.language_set[selectedLanguage]);
                    errorProvider1.SetError(uiComboBox1, tip_1);
                }
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
