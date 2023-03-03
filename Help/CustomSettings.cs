using Sunny.UI;
using System.Windows.Forms;

namespace IDE
{
    public partial class CustomSettings : UIForm
    {
        private static string _path;

        public CustomSettings(string path)
        {
            InitializeComponent();
            _path = path;
            SettingsHandler.SetSettings(path, 0);
        }

        private void ChooseXshdFile(object sender, System.EventArgs e)
        {
            if (XshdFileFinder.ShowDialog() == DialogResult.OK)
            {
                CBoxXshdFile.Items.Add(XshdFileFinder.FileName);
                System.IO.File.Copy(XshdFileFinder.FileName, _path + XshdFileFinder.FileName.SplitLast("\\"), true);
            }
        }
    }
}
