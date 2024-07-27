namespace IDE
{
    partial class FrmCustomSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomSettings));
            this.XshdFileFinder = new System.Windows.Forms.OpenFileDialog();
            this.MainTabCtrl = new Sunny.UI.UITabControlMenu();
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CBoxFont = new Sunny.UI.UIComboBox();
            this.LbMainFont = new System.Windows.Forms.Label();
            this.LbPDC = new System.Windows.Forms.Label();
            this.SwtchAutoParallelDownloadCount = new Sunny.UI.UISwitch();
            this.LbAutoPC = new System.Windows.Forms.Label();
            this.uiLine5 = new Sunny.UI.UILine();
            this.uiLine1 = new Sunny.UI.UILine();
            this.LbXshdPath = new Sunny.UI.UILabel();
            this.LbGLanguage = new Sunny.UI.UILabel();
            this.LbGTheme = new Sunny.UI.UILabel();
            this.CBoxLanguage = new Sunny.UI.UIComboBox();
            this.CBoxTheme = new Sunny.UI.UIComboBox();
            this.TBoxXshdCache = new Sunny.UI.UITextBox();
            this.XshdCachePathChooser = new Sunny.UI.UIButton();
            this.SwtchParallelDownload = new Sunny.UI.UISwitch();
            this.LbUsePD = new System.Windows.Forms.Label();
            this.TBPC = new Sunny.UI.UITrackBar();
            this.NUDDPC = new Sunny.UI.UIIntegerUpDown();
            this.TabEdit = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.uiLine2 = new Sunny.UI.UILine();
            this.CBoxEditorXshd = new Sunny.UI.UIComboBox();
            this.uiLine3 = new Sunny.UI.UILine();
            this.LbEditorFont = new Sunny.UI.UILabel();
            this.CBoxEditorFont = new Sunny.UI.UIComboBox();
            this.NUDFontSize = new Sunny.UI.UIIntegerUpDown();
            this.LbWriteText = new Sunny.UI.UILine();
            this.CkBoxShowLN = new Sunny.UI.UICheckBox();
            this.LbTextColors = new Sunny.UI.UILabel();
            this.EHostForEditor = new System.Windows.Forms.Integration.ElementHost();
            this.uiLine4 = new Sunny.UI.UILine();
            this.LbFontSize = new Sunny.UI.UILabel();
            this.Lb_EditorText_Normal = new Sunny.UI.UILabel();
            this.Lb_EditorText_Keyword = new Sunny.UI.UILabel();
            this.Lb_EditorText_Method = new Sunny.UI.UILabel();
            this.Lb_EditorText_Num = new Sunny.UI.UILabel();
            this.Lb_EditorText_Comment = new Sunny.UI.UILabel();
            this.BtnColor_Normal = new System.Windows.Forms.Button();
            this.BtnColor_Keyword = new System.Windows.Forms.Button();
            this.BtnColor_Method = new System.Windows.Forms.Button();
            this.BtnColor_Num = new System.Windows.Forms.Button();
            this.BtnColor_Com = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TabRunning = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.TabFileFormat = new System.Windows.Forms.TabPage();
            this.TLPFFMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.LbEnablePylintCheck = new System.Windows.Forms.Label();
            this.SwtchEnablePylintCheck = new Sunny.UI.UISwitch();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.LbPoweredBy = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.TLPPyLintRC = new System.Windows.Forms.TableLayoutPanel();
            this.SearchBox = new Sunny.UI.UITextBox();
            this.PylintrcLists = new Sunny.UI.UIListBox();
            this.uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            this.LbPylintrcValue = new System.Windows.Forms.Label();
            this.TBChineseName = new Sunny.UI.UITextBox();
            this.LbChineseName = new System.Windows.Forms.Label();
            this.LbKeyName = new System.Windows.Forms.Label();
            this.TBOriginName = new Sunny.UI.UITextBox();
            this.CBoxOptions = new Sunny.UI.UIComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.TBPylintValue = new Sunny.UI.UITextBox();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.uiTableLayoutPanel3 = new Sunny.UI.UITableLayoutPanel();
            this.SearchStatus = new Sunny.UI.UITextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.editreconfFileEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.InfoTips = new System.Windows.Forms.ToolTip(this.components);
            this.WarnTips = new System.Windows.Forms.ToolTip(this.components);
            this.MainTabCtrl.SuspendLayout();
            this.TabGeneral.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.TabEdit.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.TabRunning.SuspendLayout();
            this.TabFileFormat.SuspendLayout();
            this.TLPFFMain.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.uiTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.TLPPyLintRC.SuspendLayout();
            this.uiTableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.uiTableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.uiContextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // XshdFileFinder
            // 
            this.XshdFileFinder.DefaultExt = "xshd";
            this.XshdFileFinder.Filter = "语法高亮文件|*.xshd";
            this.XshdFileFinder.Title = "查找Xshd文件";
            // 
            // MainTabCtrl
            // 
            this.MainTabCtrl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.MainTabCtrl.Controls.Add(this.TabGeneral);
            this.MainTabCtrl.Controls.Add(this.TabEdit);
            this.MainTabCtrl.Controls.Add(this.TabRunning);
            this.MainTabCtrl.Controls.Add(this.TabFileFormat);
            this.MainTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabCtrl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.MainTabCtrl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainTabCtrl.ItemSize = new System.Drawing.Size(400, 40);
            this.MainTabCtrl.Location = new System.Drawing.Point(0, 35);
            this.MainTabCtrl.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.MainTabCtrl.Multiline = true;
            this.MainTabCtrl.Name = "MainTabCtrl";
            this.MainTabCtrl.SelectedIndex = 0;
            this.MainTabCtrl.Size = new System.Drawing.Size(1343, 752);
            this.MainTabCtrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainTabCtrl.Style = Sunny.UI.UIStyle.Custom;
            this.MainTabCtrl.StyleCustomMode = true;
            this.MainTabCtrl.TabIndex = 0;
            this.MainTabCtrl.TabUnSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // TabGeneral
            // 
            this.TabGeneral.AutoScroll = true;
            this.TabGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TabGeneral.Controls.Add(this.tableLayoutPanel1);
            this.TabGeneral.Location = new System.Drawing.Point(401, 0);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Size = new System.Drawing.Size(942, 752);
            this.TabGeneral.TabIndex = 0;
            this.TabGeneral.Text = "text.settings.page.general.title";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.CBoxFont, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.LbMainFont, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LbPDC, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.SwtchAutoParallelDownloadCount, 8, 5);
            this.tableLayoutPanel1.Controls.Add(this.LbAutoPC, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.uiLine5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiLine1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LbXshdPath, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LbGLanguage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LbGTheme, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.CBoxLanguage, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.CBoxTheme, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.TBoxXshdCache, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.XshdCachePathChooser, 9, 2);
            this.tableLayoutPanel1.Controls.Add(this.SwtchParallelDownload, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.LbUsePD, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.TBPC, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.NUDDPC, 9, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 20;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.791502F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.321263F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.321263F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.316678F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.81662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(942, 752);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // CBoxFont
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.CBoxFont, 3);
            this.CBoxFont.DataSource = null;
            this.CBoxFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBoxFont.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CBoxFont.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxFont.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBoxFont.ForeColor = System.Drawing.Color.Silver;
            this.errorProvider1.SetIconAlignment(this.CBoxFont, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.errorProvider1.SetIconPadding(this.CBoxFont, 10);
            this.CBoxFont.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxFont.ItemForeColor = System.Drawing.Color.Silver;
            this.CBoxFont.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CBoxFont.Items.AddRange(new object[] {
            "简体中文",
            "繁體中文",
            "English",
            "日本語"});
            this.CBoxFont.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CBoxFont.Location = new System.Drawing.Point(192, 153);
            this.CBoxFont.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxFont.MaxDropDownItems = 5;
            this.CBoxFont.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxFont.Name = "CBoxFont";
            this.CBoxFont.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CBoxFont.Size = new System.Drawing.Size(274, 43);
            this.CBoxFont.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxFont.StyleCustomMode = true;
            this.CBoxFont.SymbolSize = 24;
            this.CBoxFont.TabIndex = 31;
            this.CBoxFont.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBoxFont.Watermark = "";
            // 
            // LbMainFont
            // 
            this.LbMainFont.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.LbMainFont, 2);
            this.LbMainFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbMainFont.Location = new System.Drawing.Point(3, 148);
            this.LbMainFont.Name = "LbMainFont";
            this.LbMainFont.Size = new System.Drawing.Size(182, 53);
            this.LbMainFont.TabIndex = 30;
            this.LbMainFont.Text = "text.settings.page.general.basicsettings.mainfont";
            // 
            // LbPDC
            // 
            this.LbPDC.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.LbPDC, 3);
            this.LbPDC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbPDC.Location = new System.Drawing.Point(3, 271);
            this.LbPDC.Name = "LbPDC";
            this.LbPDC.Size = new System.Drawing.Size(276, 35);
            this.LbPDC.TabIndex = 26;
            this.LbPDC.Text = "text.settings.page.general.downloading.pc";
            // 
            // SwtchAutoParallelDownloadCount
            // 
            this.SwtchAutoParallelDownloadCount.ActiveText = "text.switch.on";
            this.SwtchAutoParallelDownloadCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SwtchAutoParallelDownloadCount.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.SwtchAutoParallelDownloadCount.InActiveText = "text.switch.off";
            this.SwtchAutoParallelDownloadCount.Location = new System.Drawing.Point(755, 239);
            this.SwtchAutoParallelDownloadCount.MinimumSize = new System.Drawing.Size(1, 1);
            this.SwtchAutoParallelDownloadCount.Name = "SwtchAutoParallelDownloadCount";
            this.SwtchAutoParallelDownloadCount.Size = new System.Drawing.Size(88, 29);
            this.SwtchAutoParallelDownloadCount.TabIndex = 24;
            this.SwtchAutoParallelDownloadCount.Text = "uiSwitch2";
            // 
            // LbAutoPC
            // 
            this.LbAutoPC.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.LbAutoPC, 3);
            this.LbAutoPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbAutoPC.Location = new System.Drawing.Point(473, 236);
            this.LbAutoPC.Name = "LbAutoPC";
            this.LbAutoPC.Size = new System.Drawing.Size(276, 35);
            this.LbAutoPC.TabIndex = 25;
            this.LbAutoPC.Text = "text.settings.page.general.downloading.autopc";
            // 
            // uiLine5
            // 
            this.uiLine5.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.uiLine5, 10);
            this.uiLine5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLine5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.uiLine5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiLine5.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.uiLine5.LineColorGradient = true;
            this.uiLine5.LineSize = 5;
            this.uiLine5.Location = new System.Drawing.Point(3, 204);
            this.uiLine5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(936, 29);
            this.uiLine5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine5.StyleCustomMode = true;
            this.uiLine5.TabIndex = 21;
            this.uiLine5.Text = "text.settings.page.general.downloading.title";
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.uiLine1, 10);
            this.uiLine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLine1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiLine1.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.uiLine1.LineColorGradient = true;
            this.uiLine1.LineSize = 5;
            this.uiLine1.Location = new System.Drawing.Point(3, 3);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(936, 36);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.StyleCustomMode = true;
            this.uiLine1.TabIndex = 20;
            this.uiLine1.Text = "text.settings.page.general.basicsettings.title";
            // 
            // LbXshdPath
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.LbXshdPath, 2);
            this.LbXshdPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbXshdPath.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbXshdPath.ForeColor = System.Drawing.Color.Silver;
            this.LbXshdPath.Location = new System.Drawing.Point(3, 95);
            this.LbXshdPath.Name = "LbXshdPath";
            this.LbXshdPath.Size = new System.Drawing.Size(182, 53);
            this.LbXshdPath.Style = Sunny.UI.UIStyle.Custom;
            this.LbXshdPath.StyleCustomMode = true;
            this.LbXshdPath.TabIndex = 16;
            this.LbXshdPath.Text = "text.settings.page.general.basicsettings.xshdpath";
            this.LbXshdPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbGLanguage
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.LbGLanguage, 2);
            this.LbGLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbGLanguage.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbGLanguage.ForeColor = System.Drawing.Color.Silver;
            this.LbGLanguage.Location = new System.Drawing.Point(3, 42);
            this.LbGLanguage.Name = "LbGLanguage";
            this.LbGLanguage.Size = new System.Drawing.Size(182, 53);
            this.LbGLanguage.Style = Sunny.UI.UIStyle.Custom;
            this.LbGLanguage.StyleCustomMode = true;
            this.LbGLanguage.TabIndex = 14;
            this.LbGLanguage.Text = "text.settings.page.general.basicsettings.lang";
            this.LbGLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbGTheme
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.LbGTheme, 2);
            this.LbGTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbGTheme.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbGTheme.ForeColor = System.Drawing.Color.Silver;
            this.LbGTheme.Location = new System.Drawing.Point(473, 42);
            this.LbGTheme.Name = "LbGTheme";
            this.LbGTheme.Size = new System.Drawing.Size(182, 53);
            this.LbGTheme.Style = Sunny.UI.UIStyle.Custom;
            this.LbGTheme.StyleCustomMode = true;
            this.LbGTheme.TabIndex = 19;
            this.LbGTheme.Text = "text.settings.page.general.basicsettings.theme";
            this.LbGTheme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CBoxLanguage
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.CBoxLanguage, 3);
            this.CBoxLanguage.DataSource = null;
            this.CBoxLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBoxLanguage.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CBoxLanguage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxLanguage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBoxLanguage.ForeColor = System.Drawing.Color.Silver;
            this.errorProvider1.SetIconAlignment(this.CBoxLanguage, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.errorProvider1.SetIconPadding(this.CBoxLanguage, 10);
            this.CBoxLanguage.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxLanguage.ItemForeColor = System.Drawing.Color.Silver;
            this.CBoxLanguage.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CBoxLanguage.Items.AddRange(new object[] {
            "简体中文",
            "繁體中文",
            "English",
            "日本語"});
            this.CBoxLanguage.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CBoxLanguage.Location = new System.Drawing.Point(192, 47);
            this.CBoxLanguage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxLanguage.MaxDropDownItems = 5;
            this.CBoxLanguage.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxLanguage.Name = "CBoxLanguage";
            this.CBoxLanguage.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CBoxLanguage.Size = new System.Drawing.Size(274, 43);
            this.CBoxLanguage.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxLanguage.StyleCustomMode = true;
            this.CBoxLanguage.SymbolSize = 24;
            this.CBoxLanguage.TabIndex = 13;
            this.CBoxLanguage.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBoxLanguage.Watermark = "";
            this.CBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.ChangeLanguage);
            this.CBoxLanguage.SelectedValueChanged += new System.EventHandler(this.ChangeLanguage);
            // 
            // CBoxTheme
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.CBoxTheme, 3);
            this.CBoxTheme.DataSource = null;
            this.CBoxTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBoxTheme.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CBoxTheme.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxTheme.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBoxTheme.ForeColor = System.Drawing.Color.Silver;
            this.errorProvider1.SetIconAlignment(this.CBoxTheme, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.errorProvider1.SetIconPadding(this.CBoxTheme, 10);
            this.CBoxTheme.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxTheme.ItemForeColor = System.Drawing.Color.Silver;
            this.CBoxTheme.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CBoxTheme.Items.AddRange(new object[] {
            "text.item.theme.light",
            "text.item.theme.dark",
            "text.item.theme.IDEA",
            "text.item.theme.custom"});
            this.CBoxTheme.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CBoxTheme.Location = new System.Drawing.Point(662, 47);
            this.CBoxTheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxTheme.MaxDropDownItems = 5;
            this.CBoxTheme.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxTheme.Name = "CBoxTheme";
            this.CBoxTheme.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CBoxTheme.Size = new System.Drawing.Size(276, 43);
            this.CBoxTheme.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxTheme.StyleCustomMode = true;
            this.CBoxTheme.SymbolSize = 24;
            this.CBoxTheme.TabIndex = 18;
            this.CBoxTheme.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBoxTheme.Watermark = "";
            this.CBoxTheme.SelectedIndexChanged += new System.EventHandler(this.ChangeTheme);
            // 
            // TBoxXshdCache
            // 
            this.TBoxXshdCache.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.SetColumnSpan(this.TBoxXshdCache, 7);
            this.TBoxXshdCache.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBoxXshdCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBoxXshdCache.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TBoxXshdCache.FillReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TBoxXshdCache.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TBoxXshdCache.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.TBoxXshdCache.ForeReadOnlyColor = System.Drawing.Color.WhiteSmoke;
            this.TBoxXshdCache.Location = new System.Drawing.Point(192, 100);
            this.TBoxXshdCache.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBoxXshdCache.MinimumSize = new System.Drawing.Size(1, 16);
            this.TBoxXshdCache.Name = "TBoxXshdCache";
            this.TBoxXshdCache.Padding = new System.Windows.Forms.Padding(5);
            this.TBoxXshdCache.ReadOnly = true;
            this.TBoxXshdCache.RectReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.TBoxXshdCache.ShowText = false;
            this.TBoxXshdCache.Size = new System.Drawing.Size(650, 43);
            this.TBoxXshdCache.Style = Sunny.UI.UIStyle.Custom;
            this.TBoxXshdCache.StyleCustomMode = true;
            this.TBoxXshdCache.TabIndex = 17;
            this.TBoxXshdCache.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TBoxXshdCache.Watermark = "";
            // 
            // XshdCachePathChooser
            // 
            this.XshdCachePathChooser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XshdCachePathChooser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XshdCachePathChooser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XshdCachePathChooser.Location = new System.Drawing.Point(849, 98);
            this.XshdCachePathChooser.MinimumSize = new System.Drawing.Size(1, 1);
            this.XshdCachePathChooser.Name = "XshdCachePathChooser";
            this.XshdCachePathChooser.Size = new System.Drawing.Size(90, 47);
            this.XshdCachePathChooser.Style = Sunny.UI.UIStyle.Custom;
            this.XshdCachePathChooser.TabIndex = 15;
            this.XshdCachePathChooser.Text = "text.settings.page.general.basicsettings.xshdpath.choose";
            this.XshdCachePathChooser.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XshdCachePathChooser.Click += new System.EventHandler(this.ChangeCachePath);
            // 
            // SwtchParallelDownload
            // 
            this.SwtchParallelDownload.ActiveText = "text.switch.on";
            this.SwtchParallelDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SwtchParallelDownload.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.SwtchParallelDownload.InActiveText = "text.switch.off";
            this.SwtchParallelDownload.Location = new System.Drawing.Point(285, 239);
            this.SwtchParallelDownload.MinimumSize = new System.Drawing.Size(1, 1);
            this.SwtchParallelDownload.Name = "SwtchParallelDownload";
            this.SwtchParallelDownload.Size = new System.Drawing.Size(88, 29);
            this.SwtchParallelDownload.TabIndex = 22;
            this.SwtchParallelDownload.ActiveChanged += new System.EventHandler(this.UpdateDownloadSettings);
            // 
            // LbUsePD
            // 
            this.LbUsePD.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.LbUsePD, 3);
            this.LbUsePD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbUsePD.Location = new System.Drawing.Point(3, 236);
            this.LbUsePD.Name = "LbUsePD";
            this.LbUsePD.Size = new System.Drawing.Size(276, 35);
            this.LbUsePD.TabIndex = 23;
            this.LbUsePD.Text = "text.settings.page.general.downloading.pd";
            // 
            // TBPC
            // 
            this.TBPC.BarSize = 25;
            this.tableLayoutPanel1.SetColumnSpan(this.TBPC, 6);
            this.TBPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBPC.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TBPC.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TBPC.Location = new System.Drawing.Point(285, 274);
            this.TBPC.Maximum = 512;
            this.TBPC.Minimum = 1;
            this.TBPC.MinimumSize = new System.Drawing.Size(1, 1);
            this.TBPC.Name = "TBPC";
            this.TBPC.Size = new System.Drawing.Size(558, 29);
            this.TBPC.TabIndex = 28;
            this.WarnTips.SetToolTip(this.TBPC, "Normally a maximum of 32 threads is already sufficient.\r\nToo many threads will ca" +
        "use lags and even memory leaks.\r\n");
            this.TBPC.Value = 16;
            this.TBPC.ValueChanged += new System.EventHandler(this.uiTrackBar1_ValueChanged);
            // 
            // NUDDPC
            // 
            this.NUDDPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NUDDPC.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.NUDDPC.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.NUDDPC.ForeColor = System.Drawing.Color.White;
            this.NUDDPC.Location = new System.Drawing.Point(850, 276);
            this.NUDDPC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NUDDPC.Maximum = 1024;
            this.NUDDPC.Minimum = 1;
            this.NUDDPC.MinimumSize = new System.Drawing.Size(100, 0);
            this.NUDDPC.Name = "NUDDPC";
            this.NUDDPC.ShowText = false;
            this.NUDDPC.Size = new System.Drawing.Size(100, 25);
            this.NUDDPC.TabIndex = 29;
            this.NUDDPC.Text = "uiIntegerUpDown1";
            this.NUDDPC.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.NUDDPC.Value = 16;
            this.NUDDPC.ValueChanged += new Sunny.UI.UIIntegerUpDown.OnValueChanged(this.NUDDPC_ValueChanged);
            // 
            // TabEdit
            // 
            this.TabEdit.AutoScroll = true;
            this.TabEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TabEdit.Controls.Add(this.tableLayoutPanel2);
            this.TabEdit.Location = new System.Drawing.Point(401, 0);
            this.TabEdit.Name = "TabEdit";
            this.TabEdit.Size = new System.Drawing.Size(942, 752);
            this.TabEdit.TabIndex = 2;
            this.TabEdit.Text = "text.settings.page.edit.title";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 20;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Controls.Add(this.uiLine2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.CBoxEditorXshd, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.uiLine3, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.LbEditorFont, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.CBoxEditorFont, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.NUDFontSize, 18, 2);
            this.tableLayoutPanel2.Controls.Add(this.LbWriteText, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.CkBoxShowLN, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.LbTextColors, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.EHostForEditor, 10, 4);
            this.tableLayoutPanel2.Controls.Add(this.uiLine4, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.LbFontSize, 16, 2);
            this.tableLayoutPanel2.Controls.Add(this.Lb_EditorText_Normal, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.Lb_EditorText_Keyword, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.Lb_EditorText_Method, 0, 13);
            this.tableLayoutPanel2.Controls.Add(this.Lb_EditorText_Num, 0, 15);
            this.tableLayoutPanel2.Controls.Add(this.Lb_EditorText_Comment, 0, 17);
            this.tableLayoutPanel2.Controls.Add(this.BtnColor_Normal, 5, 9);
            this.tableLayoutPanel2.Controls.Add(this.BtnColor_Keyword, 5, 11);
            this.tableLayoutPanel2.Controls.Add(this.BtnColor_Method, 5, 13);
            this.tableLayoutPanel2.Controls.Add(this.BtnColor_Num, 5, 15);
            this.tableLayoutPanel2.Controls.Add(this.BtnColor_Com, 5, 17);
            this.tableLayoutPanel2.Controls.Add(this.button1, 9, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 20;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.585106F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.319149F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.388298F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.388298F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(942, 752);
            this.tableLayoutPanel2.TabIndex = 46;
            // 
            // uiLine2
            // 
            this.uiLine2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.SetColumnSpan(this.uiLine2, 20);
            this.uiLine2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLine2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiLine2.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.uiLine2.LineColorGradient = true;
            this.uiLine2.LineSize = 5;
            this.uiLine2.Location = new System.Drawing.Point(3, 3);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(936, 31);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.StyleCustomMode = true;
            this.uiLine2.TabIndex = 43;
            this.uiLine2.Text = "text.settings.page.edit.appearance.title";
            // 
            // CBoxEditorXshd
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.CBoxEditorXshd, 10);
            this.CBoxEditorXshd.DataSource = null;
            this.CBoxEditorXshd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBoxEditorXshd.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CBoxEditorXshd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxEditorXshd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBoxEditorXshd.ForeColor = System.Drawing.Color.Silver;
            this.CBoxEditorXshd.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxEditorXshd.ItemForeColor = System.Drawing.Color.Silver;
            this.CBoxEditorXshd.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CBoxEditorXshd.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CBoxEditorXshd.Location = new System.Drawing.Point(4, 264);
            this.CBoxEditorXshd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxEditorXshd.MaxDropDownItems = 5;
            this.CBoxEditorXshd.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxEditorXshd.Name = "CBoxEditorXshd";
            this.CBoxEditorXshd.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.tableLayoutPanel2.SetRowSpan(this.CBoxEditorXshd, 2);
            this.CBoxEditorXshd.Size = new System.Drawing.Size(462, 64);
            this.CBoxEditorXshd.Sorted = true;
            this.CBoxEditorXshd.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxEditorXshd.StyleCustomMode = true;
            this.CBoxEditorXshd.SymbolSize = 24;
            this.CBoxEditorXshd.TabIndex = 26;
            this.CBoxEditorXshd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBoxEditorXshd.Watermark = "";
            this.CBoxEditorXshd.SelectedIndexChanged += new System.EventHandler(this.ChangeXshdColor);
            this.CBoxEditorXshd.SelectedValueChanged += new System.EventHandler(this.ChangeXshdColor);
            // 
            // uiLine3
            // 
            this.uiLine3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.SetColumnSpan(this.uiLine3, 9);
            this.uiLine3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLine3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiLine3.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(2)))), ((int)(((byte)(52)))));
            this.uiLine3.LineSize = 3;
            this.uiLine3.Location = new System.Drawing.Point(3, 225);
            this.uiLine3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(417, 31);
            this.uiLine3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine3.StyleCustomMode = true;
            this.uiLine3.TabIndex = 44;
            this.uiLine3.Text = "text.settings.page.edit.appearance.choosexshd";
            // 
            // LbEditorFont
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.LbEditorFont, 3);
            this.LbEditorFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbEditorFont.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbEditorFont.ForeColor = System.Drawing.Color.Silver;
            this.LbEditorFont.Location = new System.Drawing.Point(3, 74);
            this.LbEditorFont.Name = "LbEditorFont";
            this.LbEditorFont.Size = new System.Drawing.Size(135, 42);
            this.LbEditorFont.Style = Sunny.UI.UIStyle.Custom;
            this.LbEditorFont.StyleCustomMode = true;
            this.LbEditorFont.TabIndex = 26;
            this.LbEditorFont.Text = "text.settings.page.edit.appearance.font";
            this.LbEditorFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CBoxEditorFont
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.CBoxEditorFont, 11);
            this.CBoxEditorFont.DataSource = null;
            this.CBoxEditorFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBoxEditorFont.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CBoxEditorFont.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxEditorFont.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CBoxEditorFont.ForeColor = System.Drawing.Color.Silver;
            this.CBoxEditorFont.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxEditorFont.ItemForeColor = System.Drawing.Color.Silver;
            this.CBoxEditorFont.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CBoxEditorFont.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CBoxEditorFont.Location = new System.Drawing.Point(145, 79);
            this.CBoxEditorFont.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxEditorFont.MaxDropDownItems = 5;
            this.CBoxEditorFont.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxEditorFont.Name = "CBoxEditorFont";
            this.CBoxEditorFont.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CBoxEditorFont.Size = new System.Drawing.Size(509, 32);
            this.CBoxEditorFont.Sorted = true;
            this.CBoxEditorFont.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxEditorFont.StyleCustomMode = true;
            this.CBoxEditorFont.SymbolSize = 24;
            this.CBoxEditorFont.TabIndex = 25;
            this.CBoxEditorFont.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBoxEditorFont.Watermark = "";
            this.CBoxEditorFont.SelectedIndexChanged += new System.EventHandler(this.Update);
            this.CBoxEditorFont.SelectedValueChanged += new System.EventHandler(this.Update);
            // 
            // NUDFontSize
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.NUDFontSize, 2);
            this.NUDFontSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NUDFontSize.FillColor = System.Drawing.Color.Transparent;
            this.NUDFontSize.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NUDFontSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.NUDFontSize.Location = new System.Drawing.Point(850, 79);
            this.NUDFontSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NUDFontSize.Maximum = 144;
            this.NUDFontSize.Minimum = 1;
            this.NUDFontSize.MinimumSize = new System.Drawing.Size(100, 0);
            this.NUDFontSize.Name = "NUDFontSize";
            this.NUDFontSize.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
            this.NUDFontSize.ShowText = false;
            this.NUDFontSize.Size = new System.Drawing.Size(100, 32);
            this.NUDFontSize.Style = Sunny.UI.UIStyle.Custom;
            this.NUDFontSize.StyleCustomMode = true;
            this.NUDFontSize.TabIndex = 29;
            this.NUDFontSize.Text = null;
            this.NUDFontSize.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.NUDFontSize.Value = 12;
            this.NUDFontSize.ValueChanged += new Sunny.UI.UIIntegerUpDown.OnValueChanged(this.Update);
            // 
            // LbWriteText
            // 
            this.LbWriteText.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.SetColumnSpan(this.LbWriteText, 20);
            this.LbWriteText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbWriteText.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.LbWriteText.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbWriteText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.LbWriteText.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(2)))), ((int)(((byte)(52)))));
            this.LbWriteText.LineSize = 3;
            this.LbWriteText.Location = new System.Drawing.Point(3, 119);
            this.LbWriteText.MinimumSize = new System.Drawing.Size(1, 1);
            this.LbWriteText.Name = "LbWriteText";
            this.LbWriteText.Size = new System.Drawing.Size(936, 34);
            this.LbWriteText.Style = Sunny.UI.UIStyle.Custom;
            this.LbWriteText.StyleCustomMode = true;
            this.LbWriteText.TabIndex = 27;
            this.LbWriteText.Text = "text.settings.page.edit.appearance.font.writetesttexts";
            this.LbWriteText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LbWriteText.TextInterval = 20;
            // 
            // CkBoxShowLN
            // 
            this.CkBoxShowLN.Checked = true;
            this.tableLayoutPanel2.SetColumnSpan(this.CkBoxShowLN, 7);
            this.CkBoxShowLN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CkBoxShowLN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CkBoxShowLN.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CkBoxShowLN.ForeColor = System.Drawing.Color.Silver;
            this.CkBoxShowLN.Location = new System.Drawing.Point(3, 159);
            this.CkBoxShowLN.MinimumSize = new System.Drawing.Size(1, 1);
            this.CkBoxShowLN.Name = "CkBoxShowLN";
            this.CkBoxShowLN.Size = new System.Drawing.Size(323, 27);
            this.CkBoxShowLN.Style = Sunny.UI.UIStyle.Custom;
            this.CkBoxShowLN.StyleCustomMode = true;
            this.CkBoxShowLN.TabIndex = 30;
            this.CkBoxShowLN.Text = "text.settings.page.edit.appearance.editor.showlinenum";
            this.CkBoxShowLN.CheckedChanged += new System.EventHandler(this.UpdateSettings);
            // 
            // LbTextColors
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.LbTextColors, 10);
            this.LbTextColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbTextColors.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbTextColors.ForeColor = System.Drawing.Color.Silver;
            this.LbTextColors.Location = new System.Drawing.Point(3, 189);
            this.LbTextColors.Name = "LbTextColors";
            this.LbTextColors.Size = new System.Drawing.Size(464, 33);
            this.LbTextColors.Style = Sunny.UI.UIStyle.Custom;
            this.LbTextColors.StyleCustomMode = true;
            this.LbTextColors.TabIndex = 32;
            this.LbTextColors.Text = "text.settings.page.edit.appearance.font.color";
            this.LbTextColors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EHostForEditor
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.EHostForEditor, 10);
            this.EHostForEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EHostForEditor.Location = new System.Drawing.Point(473, 159);
            this.EHostForEditor.Name = "EHostForEditor";
            this.tableLayoutPanel2.SetRowSpan(this.EHostForEditor, 16);
            this.EHostForEditor.Size = new System.Drawing.Size(466, 590);
            this.EHostForEditor.TabIndex = 31;
            this.EHostForEditor.Child = null;
            // 
            // uiLine4
            // 
            this.uiLine4.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.SetColumnSpan(this.uiLine4, 16);
            this.uiLine4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLine4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.uiLine4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiLine4.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.uiLine4.LineColorGradient = true;
            this.uiLine4.LineSize = 5;
            this.uiLine4.Location = new System.Drawing.Point(97, 40);
            this.uiLine4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(746, 31);
            this.uiLine4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine4.StyleCustomMode = true;
            this.uiLine4.TabIndex = 45;
            this.uiLine4.Text = "text.settings.page.edit.appearance.general.title";
            // 
            // LbFontSize
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.LbFontSize, 2);
            this.LbFontSize.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbFontSize.ForeColor = System.Drawing.Color.Silver;
            this.LbFontSize.Location = new System.Drawing.Point(755, 74);
            this.LbFontSize.Name = "LbFontSize";
            this.LbFontSize.Size = new System.Drawing.Size(88, 32);
            this.LbFontSize.Style = Sunny.UI.UIStyle.Custom;
            this.LbFontSize.StyleCustomMode = true;
            this.LbFontSize.TabIndex = 28;
            this.LbFontSize.Text = "text.settings.page.edit.appearance.font.size";
            this.LbFontSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lb_EditorText_Normal
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.Lb_EditorText_Normal, 4);
            this.Lb_EditorText_Normal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lb_EditorText_Normal.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_EditorText_Normal.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Normal.Location = new System.Drawing.Point(3, 333);
            this.Lb_EditorText_Normal.Name = "Lb_EditorText_Normal";
            this.tableLayoutPanel2.SetRowSpan(this.Lb_EditorText_Normal, 2);
            this.Lb_EditorText_Normal.Size = new System.Drawing.Size(182, 74);
            this.Lb_EditorText_Normal.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Normal.StyleCustomMode = true;
            this.Lb_EditorText_Normal.TabIndex = 38;
            this.Lb_EditorText_Normal.Text = "text.settings.page.edit.appearance.font.color.normal";
            this.Lb_EditorText_Normal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lb_EditorText_Keyword
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.Lb_EditorText_Keyword, 4);
            this.Lb_EditorText_Keyword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lb_EditorText_Keyword.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_EditorText_Keyword.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Keyword.Location = new System.Drawing.Point(3, 407);
            this.Lb_EditorText_Keyword.Name = "Lb_EditorText_Keyword";
            this.tableLayoutPanel2.SetRowSpan(this.Lb_EditorText_Keyword, 2);
            this.Lb_EditorText_Keyword.Size = new System.Drawing.Size(182, 74);
            this.Lb_EditorText_Keyword.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Keyword.StyleCustomMode = true;
            this.Lb_EditorText_Keyword.TabIndex = 34;
            this.Lb_EditorText_Keyword.Text = "text.settings.page.edit.appearance.font.color.keyword";
            this.Lb_EditorText_Keyword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lb_EditorText_Method
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.Lb_EditorText_Method, 4);
            this.Lb_EditorText_Method.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lb_EditorText_Method.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_EditorText_Method.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Method.Location = new System.Drawing.Point(3, 481);
            this.Lb_EditorText_Method.Name = "Lb_EditorText_Method";
            this.tableLayoutPanel2.SetRowSpan(this.Lb_EditorText_Method, 2);
            this.Lb_EditorText_Method.Size = new System.Drawing.Size(182, 74);
            this.Lb_EditorText_Method.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Method.StyleCustomMode = true;
            this.Lb_EditorText_Method.TabIndex = 36;
            this.Lb_EditorText_Method.Text = "text.settings.page.edit.appearance.font.color.number";
            this.Lb_EditorText_Method.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lb_EditorText_Num
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.Lb_EditorText_Num, 4);
            this.Lb_EditorText_Num.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lb_EditorText_Num.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_EditorText_Num.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Num.Location = new System.Drawing.Point(3, 555);
            this.Lb_EditorText_Num.Name = "Lb_EditorText_Num";
            this.tableLayoutPanel2.SetRowSpan(this.Lb_EditorText_Num, 2);
            this.Lb_EditorText_Num.Size = new System.Drawing.Size(182, 74);
            this.Lb_EditorText_Num.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Num.StyleCustomMode = true;
            this.Lb_EditorText_Num.TabIndex = 40;
            this.Lb_EditorText_Num.Text = "text.settings.page.edit.appearance.font.color.method";
            this.Lb_EditorText_Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lb_EditorText_Comment
            // 
            this.Lb_EditorText_Comment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.tableLayoutPanel2.SetColumnSpan(this.Lb_EditorText_Comment, 4);
            this.Lb_EditorText_Comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lb_EditorText_Comment.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lb_EditorText_Comment.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Comment.Location = new System.Drawing.Point(3, 629);
            this.Lb_EditorText_Comment.Name = "Lb_EditorText_Comment";
            this.tableLayoutPanel2.SetRowSpan(this.Lb_EditorText_Comment, 2);
            this.Lb_EditorText_Comment.Size = new System.Drawing.Size(182, 74);
            this.Lb_EditorText_Comment.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Comment.StyleCustomMode = true;
            this.Lb_EditorText_Comment.TabIndex = 42;
            this.Lb_EditorText_Comment.Text = "text.settings.page.edit.appearance.font.color.comment";
            this.Lb_EditorText_Comment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnColor_Normal
            // 
            this.BtnColor_Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.tableLayoutPanel2.SetColumnSpan(this.BtnColor_Normal, 5);
            this.BtnColor_Normal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Normal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnColor_Normal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Normal.Location = new System.Drawing.Point(238, 336);
            this.BtnColor_Normal.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Normal.Name = "BtnColor_Normal";
            this.tableLayoutPanel2.SetRowSpan(this.BtnColor_Normal, 2);
            this.BtnColor_Normal.Size = new System.Drawing.Size(229, 68);
            this.BtnColor_Normal.TabIndex = 37;
            this.BtnColor_Normal.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Normal.UseVisualStyleBackColor = false;
            this.BtnColor_Normal.Click += new System.EventHandler(this.ChooseColor);
            // 
            // BtnColor_Keyword
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.BtnColor_Keyword, 5);
            this.BtnColor_Keyword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Keyword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnColor_Keyword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Keyword.Location = new System.Drawing.Point(238, 410);
            this.BtnColor_Keyword.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Keyword.Name = "BtnColor_Keyword";
            this.tableLayoutPanel2.SetRowSpan(this.BtnColor_Keyword, 2);
            this.BtnColor_Keyword.Size = new System.Drawing.Size(229, 68);
            this.BtnColor_Keyword.TabIndex = 33;
            this.BtnColor_Keyword.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Keyword.Click += new System.EventHandler(this.ChooseColor);
            // 
            // BtnColor_Method
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.BtnColor_Method, 5);
            this.BtnColor_Method.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Method.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnColor_Method.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Method.Location = new System.Drawing.Point(238, 484);
            this.BtnColor_Method.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Method.Name = "BtnColor_Method";
            this.tableLayoutPanel2.SetRowSpan(this.BtnColor_Method, 2);
            this.BtnColor_Method.Size = new System.Drawing.Size(229, 68);
            this.BtnColor_Method.TabIndex = 35;
            this.BtnColor_Method.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Method.Click += new System.EventHandler(this.ChooseColor);
            // 
            // BtnColor_Num
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.BtnColor_Num, 5);
            this.BtnColor_Num.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Num.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnColor_Num.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Num.Location = new System.Drawing.Point(238, 558);
            this.BtnColor_Num.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Num.Name = "BtnColor_Num";
            this.tableLayoutPanel2.SetRowSpan(this.BtnColor_Num, 2);
            this.BtnColor_Num.Size = new System.Drawing.Size(229, 68);
            this.BtnColor_Num.TabIndex = 39;
            this.BtnColor_Num.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Num.Click += new System.EventHandler(this.ChooseColor);
            // 
            // BtnColor_Com
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.BtnColor_Com, 5);
            this.BtnColor_Com.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Com.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnColor_Com.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Com.Location = new System.Drawing.Point(238, 632);
            this.BtnColor_Com.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Com.Name = "BtnColor_Com";
            this.tableLayoutPanel2.SetRowSpan(this.BtnColor_Com, 2);
            this.BtnColor_Com.Size = new System.Drawing.Size(229, 68);
            this.BtnColor_Com.TabIndex = 41;
            this.BtnColor_Com.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Com.Click += new System.EventHandler(this.ChooseColor);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::IDE.Properties.Resources.edit;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(426, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 31);
            this.button1.TabIndex = 46;
            this.InfoTips.SetToolTip(this.button1, "编辑所选Xshd文件");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.EditXshdFiles);
            // 
            // TabRunning
            // 
            this.TabRunning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TabRunning.Controls.Add(this.tableLayoutPanel3);
            this.TabRunning.Location = new System.Drawing.Point(401, 0);
            this.TabRunning.Name = "TabRunning";
            this.TabRunning.Size = new System.Drawing.Size(942, 752);
            this.TabRunning.TabIndex = 3;
            this.TabRunning.Text = "text.settings.page.run";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 10;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 20;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.54717F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.54717F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.716981F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(942, 752);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // TabFileFormat
            // 
            this.TabFileFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TabFileFormat.Controls.Add(this.TLPFFMain);
            this.TabFileFormat.Location = new System.Drawing.Point(401, 0);
            this.TabFileFormat.Name = "TabFileFormat";
            this.TabFileFormat.Size = new System.Drawing.Size(942, 752);
            this.TabFileFormat.TabIndex = 4;
            this.TabFileFormat.Text = "text.settings.page.fileformat.title";
            // 
            // TLPFFMain
            // 
            this.TLPFFMain.ColumnCount = 2;
            this.TLPFFMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPFFMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPFFMain.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.TLPFFMain.Controls.Add(this.uiTableLayoutPanel1, 1, 0);
            this.TLPFFMain.Controls.Add(this.TLPPyLintRC, 0, 1);
            this.TLPFFMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPFFMain.Location = new System.Drawing.Point(0, 0);
            this.TLPFFMain.Name = "TLPFFMain";
            this.TLPFFMain.RowCount = 3;
            this.TLPFFMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLPFFMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.TLPFFMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPFFMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPFFMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPFFMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPFFMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPFFMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPFFMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPFFMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPFFMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPFFMain.Size = new System.Drawing.Size(942, 752);
            this.TLPFFMain.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.45161F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.54839F));
            this.tableLayoutPanel5.Controls.Add(this.LbEnablePylintCheck, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.SwtchEnablePylintCheck, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(465, 67);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // LbEnablePylintCheck
            // 
            this.LbEnablePylintCheck.AutoSize = true;
            this.LbEnablePylintCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbEnablePylintCheck.Location = new System.Drawing.Point(3, 0);
            this.LbEnablePylintCheck.Name = "LbEnablePylintCheck";
            this.LbEnablePylintCheck.Size = new System.Drawing.Size(302, 67);
            this.LbEnablePylintCheck.TabIndex = 0;
            this.LbEnablePylintCheck.Text = "text.settings.page.fileformat.enable";
            this.LbEnablePylintCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SwtchEnablePylintCheck
            // 
            this.SwtchEnablePylintCheck.ActiveText = "text.switch.on";
            this.SwtchEnablePylintCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SwtchEnablePylintCheck.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.SwtchEnablePylintCheck.InActiveText = "text.switch.off";
            this.SwtchEnablePylintCheck.Location = new System.Drawing.Point(330, 19);
            this.SwtchEnablePylintCheck.MinimumSize = new System.Drawing.Size(1, 1);
            this.SwtchEnablePylintCheck.Name = "SwtchEnablePylintCheck";
            this.SwtchEnablePylintCheck.Size = new System.Drawing.Size(112, 29);
            this.SwtchEnablePylintCheck.TabIndex = 1;
            this.SwtchEnablePylintCheck.Text = "uiSwitch1";
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 2;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.75269F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.24731F));
            this.uiTableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(474, 3);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 1;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(465, 67);
            this.uiTableLayoutPanel1.TabIndex = 1;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::IDE.Properties.Resources.pylint_dark;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(239, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 61);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.GotoPylint);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.LbPoweredBy, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.linkLabel1, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(230, 61);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // LbPoweredBy
            // 
            this.LbPoweredBy.AutoSize = true;
            this.LbPoweredBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbPoweredBy.Font = new System.Drawing.Font("Verdana", 16F);
            this.LbPoweredBy.Location = new System.Drawing.Point(3, 0);
            this.LbPoweredBy.Name = "LbPoweredBy";
            this.LbPoweredBy.Size = new System.Drawing.Size(224, 42);
            this.LbPoweredBy.TabIndex = 0;
            this.LbPoweredBy.Text = "Powered by";
            this.LbPoweredBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Firebrick;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(8, 21);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Aqua;
            this.linkLabel1.Location = new System.Drawing.Point(3, 42);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(224, 19);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "(Follows Python PEP8 Standard)";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Aqua;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GotoPEP8);
            // 
            // TLPPyLintRC
            // 
            this.TLPPyLintRC.ColumnCount = 2;
            this.TLPFFMain.SetColumnSpan(this.TLPPyLintRC, 2);
            this.TLPPyLintRC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPPyLintRC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPPyLintRC.Controls.Add(this.SearchBox, 0, 0);
            this.TLPPyLintRC.Controls.Add(this.PylintrcLists, 0, 1);
            this.TLPPyLintRC.Controls.Add(this.uiTableLayoutPanel2, 1, 1);
            this.TLPPyLintRC.Controls.Add(this.uiTableLayoutPanel3, 1, 0);
            this.TLPPyLintRC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPPyLintRC.Location = new System.Drawing.Point(3, 76);
            this.TLPPyLintRC.Name = "TLPPyLintRC";
            this.TLPPyLintRC.RowCount = 2;
            this.TLPPyLintRC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.129012F));
            this.TLPPyLintRC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.87099F));
            this.TLPPyLintRC.Size = new System.Drawing.Size(936, 652);
            this.TLPPyLintRC.TabIndex = 2;
            // 
            // SearchBox
            // 
            this.SearchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.SearchBox.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.SearchBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.SearchBox.Location = new System.Drawing.Point(4, 5);
            this.SearchBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Padding = new System.Windows.Forms.Padding(5);
            this.SearchBox.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.SearchBox.ShowText = false;
            this.SearchBox.Size = new System.Drawing.Size(460, 23);
            this.SearchBox.Symbol = 61442;
            this.SearchBox.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SearchBox.TabIndex = 0;
            this.SearchBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.SearchBox.Watermark = "Search...";
            this.SearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
            // 
            // PylintrcLists
            // 
            this.PylintrcLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PylintrcLists.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.PylintrcLists.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.PylintrcLists.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.PylintrcLists.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.PylintrcLists.ItemHeight = 30;
            this.PylintrcLists.Items.AddRange(new object[] {
            "analyse-fallback-blocks",
            "analyse-fallback-blocks",
            "analyse-fallback-blocks",
            "analyse-fallback-blocks",
            "analyse-fallback-blocks",
            "analyse-fallback-blocks",
            "analyse-fallback-blocks",
            "analyse-fallback-blocks",
            "analyse-fallback-blocks",
            "analyse-fallback-blocks",
            "analyse-fallback-blocks",
            "analyse-fallback-blocks",
            "analyse-fallback-blocks",
            "analyse-fallback-blocks"});
            this.PylintrcLists.ItemSelectForeColor = System.Drawing.Color.White;
            this.PylintrcLists.Location = new System.Drawing.Point(4, 38);
            this.PylintrcLists.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PylintrcLists.MinimumSize = new System.Drawing.Size(1, 1);
            this.PylintrcLists.Name = "PylintrcLists";
            this.PylintrcLists.Padding = new System.Windows.Forms.Padding(2);
            this.PylintrcLists.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.PylintrcLists.ShowText = false;
            this.PylintrcLists.Size = new System.Drawing.Size(460, 609);
            this.PylintrcLists.TabIndex = 1;
            this.PylintrcLists.Text = null;
            this.PylintrcLists.SelectedIndexChanged += new System.EventHandler(this.UpdateIndex);
            // 
            // uiTableLayoutPanel2
            // 
            this.uiTableLayoutPanel2.ColumnCount = 1;
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel2.Controls.Add(this.LbPylintrcValue, 0, 4);
            this.uiTableLayoutPanel2.Controls.Add(this.TBChineseName, 0, 3);
            this.uiTableLayoutPanel2.Controls.Add(this.LbChineseName, 0, 2);
            this.uiTableLayoutPanel2.Controls.Add(this.LbKeyName, 0, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.TBOriginName, 0, 1);
            this.uiTableLayoutPanel2.Controls.Add(this.CBoxOptions, 0, 5);
            this.uiTableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 6);
            this.uiTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel2.Location = new System.Drawing.Point(471, 36);
            this.uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            this.uiTableLayoutPanel2.RowCount = 10;
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel2.Size = new System.Drawing.Size(462, 613);
            this.uiTableLayoutPanel2.TabIndex = 2;
            this.uiTableLayoutPanel2.TagString = null;
            // 
            // LbPylintrcValue
            // 
            this.LbPylintrcValue.AutoSize = true;
            this.LbPylintrcValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbPylintrcValue.Location = new System.Drawing.Point(3, 244);
            this.LbPylintrcValue.Name = "LbPylintrcValue";
            this.LbPylintrcValue.Size = new System.Drawing.Size(456, 61);
            this.LbPylintrcValue.TabIndex = 4;
            this.LbPylintrcValue.Text = "text.settings.page.fileformat.pylintrc.currentvalue";
            this.LbPylintrcValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TBChineseName
            // 
            this.TBChineseName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBChineseName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBChineseName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TBChineseName.FillReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TBChineseName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TBChineseName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.TBChineseName.ForeReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.TBChineseName.Location = new System.Drawing.Point(4, 188);
            this.TBChineseName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBChineseName.MinimumSize = new System.Drawing.Size(1, 16);
            this.TBChineseName.Name = "TBChineseName";
            this.TBChineseName.Padding = new System.Windows.Forms.Padding(5);
            this.TBChineseName.ReadOnly = true;
            this.TBChineseName.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.TBChineseName.ShowText = false;
            this.TBChineseName.Size = new System.Drawing.Size(454, 51);
            this.TBChineseName.TabIndex = 3;
            this.TBChineseName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TBChineseName.Watermark = "";
            // 
            // LbChineseName
            // 
            this.LbChineseName.AutoSize = true;
            this.LbChineseName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbChineseName.Location = new System.Drawing.Point(3, 122);
            this.LbChineseName.Name = "LbChineseName";
            this.LbChineseName.Size = new System.Drawing.Size(456, 61);
            this.LbChineseName.TabIndex = 2;
            this.LbChineseName.Text = "text.settings.page.fileformat.pylintrc.chinesename";
            this.LbChineseName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbKeyName
            // 
            this.LbKeyName.AutoSize = true;
            this.LbKeyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbKeyName.Location = new System.Drawing.Point(3, 0);
            this.LbKeyName.Name = "LbKeyName";
            this.LbKeyName.Size = new System.Drawing.Size(456, 61);
            this.LbKeyName.TabIndex = 0;
            this.LbKeyName.Text = "text.settings.page.fileformat.pylintrc.originname";
            this.LbKeyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TBOriginName
            // 
            this.TBOriginName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBOriginName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBOriginName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TBOriginName.FillReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TBOriginName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TBOriginName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.TBOriginName.ForeReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.TBOriginName.Location = new System.Drawing.Point(4, 66);
            this.TBOriginName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBOriginName.MinimumSize = new System.Drawing.Size(1, 16);
            this.TBOriginName.Name = "TBOriginName";
            this.TBOriginName.Padding = new System.Windows.Forms.Padding(5);
            this.TBOriginName.ReadOnly = true;
            this.TBOriginName.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.TBOriginName.ShowText = false;
            this.TBOriginName.Size = new System.Drawing.Size(454, 51);
            this.TBOriginName.TabIndex = 1;
            this.TBOriginName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TBOriginName.Watermark = "";
            // 
            // CBoxOptions
            // 
            this.CBoxOptions.DataSource = null;
            this.CBoxOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBoxOptions.Enabled = false;
            this.CBoxOptions.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxOptions.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxOptions.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CBoxOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.CBoxOptions.ForeDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.CBoxOptions.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CBoxOptions.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CBoxOptions.Location = new System.Drawing.Point(4, 310);
            this.CBoxOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxOptions.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxOptions.Name = "CBoxOptions";
            this.CBoxOptions.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CBoxOptions.Size = new System.Drawing.Size(454, 51);
            this.CBoxOptions.SymbolSize = 24;
            this.CBoxOptions.TabIndex = 5;
            this.CBoxOptions.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.CBoxOptions.Watermark = "";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.TBPylintValue, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.uiTextBox1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 369);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.uiTableLayoutPanel2.SetRowSpan(this.tableLayoutPanel4, 4);
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.38589F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.61411F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(456, 241);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // TBPylintValue
            // 
            this.TBPylintValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBPylintValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBPylintValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TBPylintValue.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TBPylintValue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TBPylintValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.TBPylintValue.ForeDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TBPylintValue.Location = new System.Drawing.Point(4, 70);
            this.TBPylintValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBPylintValue.MinimumSize = new System.Drawing.Size(1, 16);
            this.TBPylintValue.Multiline = true;
            this.TBPylintValue.Name = "TBPylintValue";
            this.TBPylintValue.Padding = new System.Windows.Forms.Padding(5);
            this.TBPylintValue.ShowText = false;
            this.TBPylintValue.Size = new System.Drawing.Size(448, 166);
            this.TBPylintValue.TabIndex = 1;
            this.TBPylintValue.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TBPylintValue.Watermark = "";
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTextBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.uiTextBox1.FillReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.uiTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiTextBox1.ForeDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiTextBox1.ForeReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiTextBox1.Location = new System.Drawing.Point(4, 5);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox1.Multiline = true;
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.ReadOnly = true;
            this.uiTextBox1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(448, 55);
            this.uiTextBox1.Symbol = 112;
            this.uiTextBox1.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiTextBox1.TabIndex = 2;
            this.uiTextBox1.Text = "test.settings.page.fileformat.pylintrc.singlelinetip";
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.Watermark = "";
            // 
            // uiTableLayoutPanel3
            // 
            this.uiTableLayoutPanel3.ColumnCount = 2;
            this.uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.Controls.Add(this.SearchStatus, 0, 0);
            this.uiTableLayoutPanel3.Controls.Add(this.linkLabel2, 1, 0);
            this.uiTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel3.Location = new System.Drawing.Point(471, 3);
            this.uiTableLayoutPanel3.Name = "uiTableLayoutPanel3";
            this.uiTableLayoutPanel3.RowCount = 1;
            this.uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.Size = new System.Drawing.Size(462, 27);
            this.uiTableLayoutPanel3.TabIndex = 3;
            this.uiTableLayoutPanel3.TagString = null;
            // 
            // SearchStatus
            // 
            this.SearchStatus.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.SearchStatus.FillReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.SearchStatus.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.SearchStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.SearchStatus.ForeReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.SearchStatus.Location = new System.Drawing.Point(4, 5);
            this.SearchStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchStatus.MinimumSize = new System.Drawing.Size(1, 16);
            this.SearchStatus.Name = "SearchStatus";
            this.SearchStatus.Padding = new System.Windows.Forms.Padding(5);
            this.SearchStatus.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.SearchStatus.ReadOnly = true;
            this.SearchStatus.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.SearchStatus.ShowText = false;
            this.SearchStatus.Size = new System.Drawing.Size(223, 17);
            this.SearchStatus.Symbol = 61452;
            this.SearchStatus.SymbolColor = System.Drawing.Color.PaleGreen;
            this.SearchStatus.TabIndex = 0;
            this.SearchStatus.Text = "Found";
            this.SearchStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.SearchStatus.Visible = false;
            this.SearchStatus.Watermark = "";
            this.SearchStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.Aqua;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.Aqua;
            this.linkLabel2.Location = new System.Drawing.Point(234, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(225, 27);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Edit .pylintrc File";
            this.linkLabel2.VisitedLinkColor = System.Drawing.Color.Cyan;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EdtPylintrcFile);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiContextMenuStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editreconfFileEToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(270, 38);
            // 
            // editreconfFileEToolStripMenuItem
            // 
            this.editreconfFileEToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.editreconfFileEToolStripMenuItem.ForeColor = System.Drawing.Color.Silver;
            this.editreconfFileEToolStripMenuItem.Image = global::IDE.Properties.Resources.detail;
            this.editreconfFileEToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editreconfFileEToolStripMenuItem.Name = "editreconfFileEToolStripMenuItem";
            this.editreconfFileEToolStripMenuItem.Size = new System.Drawing.Size(269, 34);
            this.editreconfFileEToolStripMenuItem.Text = "Edit .reconf File (&E)";
            this.editreconfFileEToolStripMenuItem.Click += new System.EventHandler(this.OpenEditor);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 756);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1343, 31);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::IDE.Properties.Resources.Info_dark;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1328, 24);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "text.tip.editreconffile";
            // 
            // InfoTips
            // 
            this.InfoTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.InfoTips.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.InfoTips.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.InfoTips.ToolTipTitle = "Info";
            // 
            // WarnTips
            // 
            this.WarnTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.WarnTips.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.WarnTips.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // FrmCustomSettings
            // 
            this.AllowAddControlOnTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1343, 787);
            this.ControlBoxFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MainTabCtrl);
            this.EscClose = true;
            this.ExtendBox = true;
            this.ExtendMenu = this.uiContextMenuStrip1;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCustomSettings";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "text.settings.window.title";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.TitleFont = new System.Drawing.Font("微软雅黑", 12F);
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 842, 400);
            this.Load += new System.EventHandler(this.CustomSettings_Load);
            this.Shown += new System.EventHandler(this.FormUpdate);
            this.MainTabCtrl.ResumeLayout(false);
            this.TabGeneral.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.TabEdit.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.TabRunning.ResumeLayout(false);
            this.TabFileFormat.ResumeLayout(false);
            this.TLPFFMain.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.uiTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.TLPPyLintRC.ResumeLayout(false);
            this.uiTableLayoutPanel2.ResumeLayout(false);
            this.uiTableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.uiTableLayoutPanel3.ResumeLayout(false);
            this.uiTableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog XshdFileFinder;
        private Sunny.UI.UITabControlMenu MainTabCtrl;
        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage TabEdit;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UIComboBox CBoxTheme;
        private Sunny.UI.UILabel LbGTheme;
        private Sunny.UI.UITextBox TBoxXshdCache;
        private Sunny.UI.UILabel LbXshdPath;
        private Sunny.UI.UIButton XshdCachePathChooser;
        private Sunny.UI.UIComboBox CBoxLanguage;
        private Sunny.UI.UILabel LbGLanguage;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILabel Lb_EditorText_Comment;
        private Sunny.UI.UILabel Lb_EditorText_Num;
        private System.Windows.Forms.Button BtnColor_Com;
        private System.Windows.Forms.Button BtnColor_Num;
        private Sunny.UI.UILabel Lb_EditorText_Normal;
        private System.Windows.Forms.Button BtnColor_Normal;
        private Sunny.UI.UILabel Lb_EditorText_Method;
        private System.Windows.Forms.Button BtnColor_Method;
        private Sunny.UI.UILabel Lb_EditorText_Keyword;
        private System.Windows.Forms.Button BtnColor_Keyword;
        private Sunny.UI.UILabel LbTextColors;
        private System.Windows.Forms.Integration.ElementHost EHostForEditor;
        private Sunny.UI.UICheckBox CkBoxShowLN;
        private Sunny.UI.UIIntegerUpDown NUDFontSize;
        private Sunny.UI.UILabel LbFontSize;
        private Sunny.UI.UILine LbWriteText;
        private Sunny.UI.UIComboBox CBoxEditorFont;
        private Sunny.UI.UILabel LbEditorFont;
        private Sunny.UI.UILine uiLine4;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UIComboBox CBoxEditorXshd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editreconfFileEToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage TabRunning;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip InfoTips;
        private Sunny.UI.UILine uiLine5;
        private Sunny.UI.UISwitch SwtchParallelDownload;
        private Sunny.UI.UISwitch SwtchAutoParallelDownloadCount;
        private System.Windows.Forms.Label LbAutoPC;
        private System.Windows.Forms.Label LbUsePD;
        private System.Windows.Forms.Label LbPDC;
        private System.Windows.Forms.ToolTip WarnTips;
        private Sunny.UI.UITrackBar TBPC;
        private Sunny.UI.UIIntegerUpDown NUDDPC;
        private Sunny.UI.UIComboBox CBoxFont;
        private System.Windows.Forms.Label LbMainFont;
        private System.Windows.Forms.TabPage TabFileFormat;
        private System.Windows.Forms.TableLayoutPanel TLPFFMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label LbEnablePylintCheck;
        private Sunny.UI.UISwitch SwtchEnablePylintCheck;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private System.Windows.Forms.Label LbPoweredBy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel TLPPyLintRC;
        private Sunny.UI.UITextBox SearchBox;
        private Sunny.UI.UIListBox PylintrcLists;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private System.Windows.Forms.Label LbKeyName;
        private Sunny.UI.UITextBox TBOriginName;
        private System.Windows.Forms.Label LbPylintrcValue;
        private Sunny.UI.UITextBox TBChineseName;
        private System.Windows.Forms.Label LbChineseName;
        private Sunny.UI.UIComboBox CBoxOptions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Sunny.UI.UITextBox TBPylintValue;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel3;
        private Sunny.UI.UITextBox SearchStatus;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}