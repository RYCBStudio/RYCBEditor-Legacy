using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sunny.UI;
using IDE.Utils.Boxes.PackageManager;

namespace IDE.Utils;
public partial class PackageManagerMain : UIForm
{

    private List<string> packageNames = new();
    private PackageManagerProgressWindow pw;

    public PackageManagerMain()
    {
        InitializeComponent();
        InitializeLocalization();
    }
    private Dictionary<string, string> AnalyzePackageInfoFile(string path)
    {
        Dictionary<string, string> ret = new Dictionary<string, string>();
        var _ = File.ReadAllLines(path + "\\package.info");
        try
        {

            ret.Add("Name", _[0]);
            ret.Add("Author", _[1]);
            ret.Add("Copyright", _[2]);
            ret.Add("Desc", _[3]);
        }
        catch
        {
            if (!ret.ContainsKey("Name"))
            {
                ret.Add("Name", "None");
            }
            if (!ret.ContainsKey("Author"))
            {
                ret.Add("Author", "None");
            }
            if (!ret.ContainsKey("Copyright"))
            {
                ret.Add("Copyright", "None");
            }
            if (!ret.ContainsKey("Desc"))
            {
                ret.Add("Desc", "This package has no description");
            }
        }
        return ret;
    }

    private void GetAllPackages()
    {
        foreach (var item in Directory.EnumerateDirectories(GlobalSettings.packagePath))
        {
            packageNames.Add(item);
        }
    }

    private string GetPackageStatus(string path)
    {
        var fileRootPath = path;
        if (File.Exists(fileRootPath + "\\ENABLED.FLAG")) { return "Enabled"; }
        else if (File.Exists(fileRootPath + "\\DISABLED.FLAG")) { return "Disabled"; }
        else { return "Not sure"; }
    }

    private void InitializePackage(string pkgPath)
    {
        Dictionary<string, string> pkgTags = new Dictionary<string, string>();
        pkgTags.Add("Path", pkgPath);
        var pkgName = Path.GetFileName(pkgPath).Split('.')[0];
        var pkgInfo = AnalyzePackageInfoFile(pkgPath);
        #region WinForms Auto-Generated Code
        TabPage newTab = new()
        {
            Text = pkgName,
            ToolTipText = pkgName,
        };
        TableLayoutPanel table = new()
        {
            ColumnCount = 3,
            Dock = DockStyle.Fill,
            Location = new Point(0, 0),
            Name = "tableLayoutPanel" + DateTime.Now.Millisecond,
            RowCount = 10,
            TabIndex = 0,
        };
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.86114F));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.20609F));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.932763F));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 11F));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 11F));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
        #endregion
        #region Custom Tabpage Controls
        Label l1 = new Label()
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            Location = new Point(3, 0),
            Name = "label1_" + DateTime.Now.Millisecond,
            Size = new Size(145, 40),
            TabIndex = 0,
            Text = _I18nFile.Localize("text.lpmm.pkg.name"),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        Label l2 = new Label()
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            Location = new Point(3, 40),
            Name = "label2",
            Size = new Size(145, 40),
            TabIndex = 1,
            Text = _I18nFile.Localize("text.lpmm.pkg.author"),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        Label l3 = new Label()
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            Location = new Point(3, 80),
            Name = "label3",
            Size = new Size(145, 40),
            TabIndex = 2,
            Text = _I18nFile.Localize("text.lpmm.pkg.desc"),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        Label l4 = new Label()
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            Location = new Point(154, 328),
            Name = "label4",
            Size = new Size(315, 40),
            TabIndex = 10,
            Text = GetPackageStatus(pkgPath),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        pkgTags.Add("Status", l4.Text);
        l4.Text = _I18nFile.Localize((l4.Text == "Not sure" ? "unknown" : l4.Text));
        Label l5 = new Label()
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            Location = new Point(3, 328),
            Name = "label5",
            Size = new Size(145, 40),
            TabIndex = 11,
            Text = _I18nFile.Localize("text.lpmm.pkg.status"),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        UITextBox uiTb1 = new UITextBox()
        {

            Cursor = Cursors.IBeam,
            Dock = DockStyle.Fill,
            Font = new Font("微软雅黑", 11F),
            Location = new Point(155, 45),
            Margin = new Padding(4, 5, 4, 5),
            MinimumSize = new Size(1, 16),
            Name = "uiTextBox4",
            Padding = new Padding(5),
            ReadOnly = true,
            RectSides = ToolStripStatusLabelBorderSides.None,
            ShowText = false,
            Size = new Size(350, 34),
            TabIndex = 9,
            Text = pkgInfo["Author"],
            TextAlignment = ContentAlignment.MiddleLeft,
            Watermark = "",
        };
        pkgTags.Add("Author", uiTb1.Text);
        if (GlobalSettings.TrustedAuthors.Contains(uiTb1.Text))
        {
            uiTb1.Symbol = 557716;
            pkgTags.Add("TrustedAuthor", "true");
        }
        else
        {
            uiTb1.Symbol = 362005;
            uiTb1.SymbolOffset = new(-3, 0);
            pkgTags.Add("TrustedAuthor", "false");
        }
        table.SetColumnSpan(uiTb1, 2);
        UITextBox uiTb2 = new UITextBox()
        {
            Cursor = Cursors.IBeam,
            Dock = DockStyle.Fill,
            Font = new Font("微软雅黑", 11F),
            Location = new Point(155, 85),
            Margin = new Padding(4, 5, 4, 5),
            MinimumSize = new Size(1, 16),
            Multiline = true,
            Name = "uiTextBox3",
            Padding = new Padding(5),
            ReadOnly = true,
            RectSides = ToolStripStatusLabelBorderSides.None,
            ShowText = false,
            Text = pkgInfo["Desc"],
            Size = new Size(350, 238),
            TabIndex = 8,
            TextAlignment = ContentAlignment.TopLeft,
            Watermark = "",
        };
        table.SetColumnSpan(uiTb2, 2);
        table.SetRowSpan(uiTb2, 6);
        pkgTags.Add("Desc", uiTb2.Text);
        UITextBox uiTb3 = new UITextBox()
        {
            Cursor = Cursors.IBeam,
            Dock = DockStyle.Fill,
            Font = new Font("微软雅黑", 11F),
            Location = new Point(155, 5),
            Margin = new Padding(4, 5, 4, 5),
            MinimumSize = new Size(1, 16),
            Name = "uiTextBox2",
            Padding = new Padding(5),
            ReadOnly = true,
            RectSides = ToolStripStatusLabelBorderSides.None,
            ShowText = false,
            Size = new Size(350, 34),
            Symbol = 559515,
            TabIndex = 7,
            Text = pkgInfo["Name"],
            TextAlignment = ContentAlignment.MiddleLeft,
            Watermark = "",
        };
        pkgTags.Add("Name", uiTb3.Text);
        table.SetColumnSpan(uiTb3, 2);
        newTab.ToolTipText += "\n" + uiTb3.Text;
        Button b1 = new Button()
        {
            Dock = DockStyle.Fill,
            Image = Properties.Resources.ABout1,
            Location = new Point(475, 371),
            Name = "button2",
            Size = new Size(31, 34),
            TabIndex = 6,
            Text = "  ",
            UseVisualStyleBackColor = true,

        };
        this.InfoTip.SetToolTip(b1, "Use this package");
        Button b2 = new Button()
        {
            BackgroundImage = Properties.Resources.plugin_ban,
            BackgroundImageLayout = ImageLayout.Stretch,
            Dock = DockStyle.Fill,
            Location = new Point(475, 331),
            Name = "button3",
            Size = new Size(31, 34),
            TabIndex = 12,
            Text = "  ",
            UseVisualStyleBackColor = true,
        };
        var enb = _I18nFile.Localize("Enabled");
        var dib = _I18nFile.Localize("Disabled");
        if (l4.Text.Equals(enb))
        {
            b2.BackgroundImage = Properties.Resources.plugin_ban;
        }
        else if (l4.Text.Equals(dib))
        {
            b2.BackgroundImage = Properties.Resources.plugin_enable;
        }
        b2.Click += ChangeStatus;
        table.Controls.Add(l5, 1, 7);
        table.Controls.Add(l4, 0, 8);
        table.Controls.Add(uiTb1, 1, 1);
        table.Controls.Add(uiTb2, 1, 2);
        table.Controls.Add(l1, 0, 0);
        table.Controls.Add(l2, 0, 1);
        table.Controls.Add(l3, 0, 2);
        table.Controls.Add(b1, 2, 9);
        table.Controls.Add(uiTb3, 1, 0);
        table.Controls.Add(b2, 2, 8);
        newTab.Controls.Add(table);
        newTab.Tag = pkgTags;
        #endregion
        uiTabControlMenu1.Controls.Add(newTab);
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
        var matchedItem = "";
        foreach (var item in packageNames)
        {
            if (item.ToLower().Contains(uiTextBox1.Text.ToLower()))
            {
                containsKeyword = true;
                matchedItem = item;
                break;
            }
        }
        if (containsKeyword)
        {
            uiTabControlMenu1.SelectedIndex = packageNames.IndexOf(matchedItem);
        }
        else
        {
            var res = MessageBoxEX.Show(_I18nFile.Localize("text.lpmm.pkg.notfound"), _I18nFile.Localize("text.lpmm.pkg.tip"), MessageBoxButtons.AbortRetryIgnore, [_I18nFile.Localize("text.lpmm.pkg.notfound.import"), _I18nFile.Localize("text.lpmm.pkg.notfound.search"), _I18nFile.Localize("text.lpmm.pkg.notfound.cancel")]);
            if (res == DialogResult.Abort)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) 
                {
                    Extensions.CopyFolder(folderBrowserDialog1.SelectedPath, Program.STARTUP_PATH + "\\Package\\"+Path.GetFileNameWithoutExtension(folderBrowserDialog1.SelectedPath));
                    InitPkg();
                }
            }
        }
    }

    private void PackageManagerMain_Shown(object sender, EventArgs e)
    {
        GetAllPackages();
        pw = new(0, packageNames.Count, true, _I18nFile.Localize("text.lpmm.pkg.processing"));
        pw.Show();
        pw.TopMost = true;
        //backgroundWorker1.RunWorkerAsync(); 
        InitPkg();
    }

    internal void InitPkg()
    {
        var si = uiTabControlMenu1.SelectedIndex;
        uiTabControlMenu1.Controls.Clear();
        for (int i = 0; i < packageNames.Count; i++)
        {
            InitializePackage(packageNames[i]);
            var _1 = (int)(Math.Round((double)(i + 1) / packageNames.Count, 2) * 100);
            var _2 = packageNames.Count * 100;
            pw.Update(_1, _2, true, _I18nFile.Localize("text.lpmm.pkg.processing"));
        }
        uiTabControlMenu1.SelectedIndex = si;
    }

    private void Init(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        foreach (var item in packageNames)
        {
            InitializePackage(item);
            worker.ReportProgress(packageNames.IndexOf(item) + 1);
        }
    }

    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        pw.Update(e.ProgressPercentage, packageNames.Count, true, _I18nFile.Localize("text.lpmm.pkg.processing"));
    }

    private void PackageManagerMain_Load(object sender, EventArgs e)
    {
        uiTabControlMenu1.Controls.Clear();
    }

    private void ChangeStatus(object sender, EventArgs e)
    {
        if (uiTabControlMenu1.SelectedTab.Tag is Dictionary<string, string> pkgTags)
        {
            if (pkgTags["Status"] == "Enabled")
            {
                try
                {
                    var si = uiTabControlMenu1.SelectedIndex;
                    File.Delete(pkgTags["Path"] + "\\ENABLED.FLAG");
                    File.Create(pkgTags["Path"] + "\\DISABLED.FLAG").Dispose();
                    InitPkg();
                    uiTabControlMenu1.SelectedIndex = si;
                }
                catch (Exception ex)
                {
                    Main.LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                }
            }
            else if (pkgTags["Status"] == "Disabled")
            {
                try
                {
                    var si = uiTabControlMenu1.SelectedIndex;
                    File.Create(pkgTags["Path"] + "\\ENABLED.FLAG").Dispose();
                    File.Delete(pkgTags["Path"] + "\\DISABLED.FLAG");
                    InitPkg();
                    uiTabControlMenu1.SelectedIndex = si;
                }
                catch (Exception ex)
                {
                    Main.LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                }
            }
            else
            {
                try
                {
                    var si = uiTabControlMenu1.SelectedIndex;
                    File.Create(pkgTags["Path"] + "\\ENABLED.FLAG").Dispose();
                    InitPkg();
                    uiTabControlMenu1.SelectedIndex = si;
                }
                catch (Exception ex)
                {
                    Main.LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                }

            }
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
}
