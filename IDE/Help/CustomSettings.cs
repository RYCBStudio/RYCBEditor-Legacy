using Sunny.UI;
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
