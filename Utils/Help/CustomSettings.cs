using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Search;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Windows.Forms.Integration;

namespace IDE
{
    public partial class CustomSettings : Form
    {
        Main MainWindow;
        List<string> files = new List<string>() { };
        List<ElementHost> hosts = new List<ElementHost> { };

        public CustomSettings()
        {
            InitializeComponent();
            MainWindow = (Main) this.Owner;
        }

        private void FindFile(object sender, System.EventArgs e)
        {
            if (XshdFileFinder.ShowDialog() == DialogResult.OK)
            {
                XshdCBox.Items.Add($"[语言：{XshdFileFinder.FileName.Split('\\')[XshdFileFinder.FileName.Split('\\').Length - 1].Split('.')[0]}] "+XshdFileFinder.FileName);
                files.Add(XshdFileFinder.FileName);
            }
        }

        private void addXshdToIDE(object sender, System.EventArgs e)
        {
            foreach (var item in files)
            {
                TextEditor txtEditor = new TextEditor();
                SearchPanel.Install(txtEditor.TextArea);
                //设置语法规则
                string name = item.ToString();
                using (Stream s = new FileStream(name, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    using (XmlTextReader reader = new XmlTextReader(s))
                    {
                        var xshd = HighlightingLoader.LoadXshd(reader);
                        txtEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                    }
                }
                ElementHost tmpEHost = new ElementHost();
                tmpEHost.Child = txtEditor;
                hosts.Add(tmpEHost);
            }
        }
    }
}
