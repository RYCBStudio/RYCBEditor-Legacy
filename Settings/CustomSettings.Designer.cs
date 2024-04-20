namespace IDE
{
    partial class CustomSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomSettings));
            this.XshdFileFinder = new System.Windows.Forms.OpenFileDialog();
            this.MainTabCtrl = new Sunny.UI.UITabControlMenu();
            this.General = new System.Windows.Forms.TabPage();
            this.uiLine1 = new Sunny.UI.UILine();
            this.CBoxTheme = new Sunny.UI.UIComboBox();
            this.LbGTheme = new Sunny.UI.UILabel();
            this.TBoxXshdCache = new Sunny.UI.UITextBox();
            this.LbXshdPath = new Sunny.UI.UILabel();
            this.XshdCachePathChooser = new Sunny.UI.UIButton();
            this.CBoxLanguage = new Sunny.UI.UIComboBox();
            this.LbGLanguage = new Sunny.UI.UILabel();
            this.Edit = new System.Windows.Forms.TabPage();
            this.CBoxEditorXshd = new Sunny.UI.UIComboBox();
            this.uiLine4 = new Sunny.UI.UILine();
            this.uiLine3 = new Sunny.UI.UILine();
            this.uiLine2 = new Sunny.UI.UILine();
            this.Lb_EditorText_Comment = new Sunny.UI.UILabel();
            this.Lb_EditorText_Num = new Sunny.UI.UILabel();
            this.BtnColor_Com = new System.Windows.Forms.Button();
            this.BtnColor_Num = new System.Windows.Forms.Button();
            this.Lb_EditorText_Normal = new Sunny.UI.UILabel();
            this.BtnColor_Normal = new System.Windows.Forms.Button();
            this.Lb_EditorText_Method = new Sunny.UI.UILabel();
            this.BtnColor_Method = new System.Windows.Forms.Button();
            this.Lb_EditorText_Keyword = new Sunny.UI.UILabel();
            this.BtnColor_Keyword = new System.Windows.Forms.Button();
            this.LbTextColors = new Sunny.UI.UILabel();
            this.EHostForEditor = new System.Windows.Forms.Integration.ElementHost();
            this.CkBoxShowLN = new Sunny.UI.UICheckBox();
            this.NUDFontSize = new Sunny.UI.UIIntegerUpDown();
            this.LbFontSize = new Sunny.UI.UILabel();
            this.LbWriteText = new Sunny.UI.UILine();
            this.CBoxEditorFont = new Sunny.UI.UIComboBox();
            this.LbEditorFont = new Sunny.UI.UILabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiButton1 = new System.Windows.Forms.Button();
            this.MainTabCtrl.SuspendLayout();
            this.General.SuspendLayout();
            this.Edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.MainTabCtrl.Controls.Add(this.General);
            this.MainTabCtrl.Controls.Add(this.Edit);
            this.MainTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabCtrl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.MainTabCtrl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainTabCtrl.Location = new System.Drawing.Point(0, 35);
            this.MainTabCtrl.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.MainTabCtrl.Multiline = true;
            this.MainTabCtrl.Name = "MainTabCtrl";
            this.MainTabCtrl.SelectedIndex = 0;
            this.MainTabCtrl.Size = new System.Drawing.Size(905, 887);
            this.MainTabCtrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainTabCtrl.Style = Sunny.UI.UIStyle.Custom;
            this.MainTabCtrl.StyleCustomMode = true;
            this.MainTabCtrl.TabIndex = 0;
            this.MainTabCtrl.TabUnSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // General
            // 
            this.General.AutoScroll = true;
            this.General.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.General.Controls.Add(this.uiLine1);
            this.General.Controls.Add(this.CBoxTheme);
            this.General.Controls.Add(this.LbGTheme);
            this.General.Controls.Add(this.TBoxXshdCache);
            this.General.Controls.Add(this.LbXshdPath);
            this.General.Controls.Add(this.XshdCachePathChooser);
            this.General.Controls.Add(this.CBoxLanguage);
            this.General.Controls.Add(this.LbGLanguage);
            this.General.Location = new System.Drawing.Point(201, 0);
            this.General.Name = "General";
            this.General.Size = new System.Drawing.Size(704, 887);
            this.General.TabIndex = 0;
            this.General.Text = "text.settings.page.general.title";
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiLine1.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.uiLine1.LineColorGradient = true;
            this.uiLine1.LineSize = 5;
            this.uiLine1.Location = new System.Drawing.Point(7, 3);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(656, 31);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.StyleCustomMode = true;
            this.uiLine1.TabIndex = 20;
            this.uiLine1.Text = "text.settings.page.general.basicsettings.title";
            // 
            // CBoxTheme
            // 
            this.CBoxTheme.DataSource = null;
            this.CBoxTheme.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CBoxTheme.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxTheme.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBoxTheme.ForeColor = System.Drawing.Color.Silver;
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
            this.CBoxTheme.Location = new System.Drawing.Point(440, 42);
            this.CBoxTheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxTheme.MaxDropDownItems = 5;
            this.CBoxTheme.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxTheme.Name = "CBoxTheme";
            this.CBoxTheme.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CBoxTheme.Size = new System.Drawing.Size(166, 35);
            this.CBoxTheme.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxTheme.StyleCustomMode = true;
            this.CBoxTheme.TabIndex = 18;
            this.CBoxTheme.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBoxTheme.Watermark = "";
            this.CBoxTheme.SelectedIndexChanged += new System.EventHandler(this.ChangeTheme);
            // 
            // LbGTheme
            // 
            this.LbGTheme.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbGTheme.ForeColor = System.Drawing.Color.Silver;
            this.LbGTheme.Location = new System.Drawing.Point(331, 45);
            this.LbGTheme.Name = "LbGTheme";
            this.LbGTheme.Size = new System.Drawing.Size(102, 32);
            this.LbGTheme.Style = Sunny.UI.UIStyle.Custom;
            this.LbGTheme.StyleCustomMode = true;
            this.LbGTheme.TabIndex = 19;
            this.LbGTheme.Text = "text.settings.page.general.basicsettings.theme";
            this.LbGTheme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TBoxXshdCache
            // 
            this.TBoxXshdCache.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.TBoxXshdCache.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBoxXshdCache.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TBoxXshdCache.FillReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.TBoxXshdCache.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TBoxXshdCache.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.TBoxXshdCache.ForeReadOnlyColor = System.Drawing.Color.WhiteSmoke;
            this.TBoxXshdCache.Location = new System.Drawing.Point(167, 87);
            this.TBoxXshdCache.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBoxXshdCache.MinimumSize = new System.Drawing.Size(1, 16);
            this.TBoxXshdCache.Name = "TBoxXshdCache";
            this.TBoxXshdCache.Padding = new System.Windows.Forms.Padding(5);
            this.TBoxXshdCache.ReadOnly = true;
            this.TBoxXshdCache.RectReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.TBoxXshdCache.ShowText = false;
            this.TBoxXshdCache.Size = new System.Drawing.Size(362, 34);
            this.TBoxXshdCache.Style = Sunny.UI.UIStyle.Custom;
            this.TBoxXshdCache.StyleCustomMode = true;
            this.TBoxXshdCache.TabIndex = 17;
            this.TBoxXshdCache.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TBoxXshdCache.Watermark = "";
            // 
            // LbXshdPath
            // 
            this.LbXshdPath.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbXshdPath.ForeColor = System.Drawing.Color.Silver;
            this.LbXshdPath.Location = new System.Drawing.Point(3, 89);
            this.LbXshdPath.Name = "LbXshdPath";
            this.LbXshdPath.Size = new System.Drawing.Size(157, 32);
            this.LbXshdPath.Style = Sunny.UI.UIStyle.Custom;
            this.LbXshdPath.StyleCustomMode = true;
            this.LbXshdPath.TabIndex = 16;
            this.LbXshdPath.Text = "text.settings.page.general.basicsettings.xshdpath";
            this.LbXshdPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // XshdCachePathChooser
            // 
            this.XshdCachePathChooser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XshdCachePathChooser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XshdCachePathChooser.Location = new System.Drawing.Point(536, 87);
            this.XshdCachePathChooser.MinimumSize = new System.Drawing.Size(1, 1);
            this.XshdCachePathChooser.Name = "XshdCachePathChooser";
            this.XshdCachePathChooser.Size = new System.Drawing.Size(127, 35);
            this.XshdCachePathChooser.Style = Sunny.UI.UIStyle.Custom;
            this.XshdCachePathChooser.TabIndex = 15;
            this.XshdCachePathChooser.Text = "text.settings.page.general.basicsettings.xshdpath.choose";
            this.XshdCachePathChooser.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XshdCachePathChooser.Click += new System.EventHandler(this.ChangeCachePath);
            // 
            // CBoxLanguage
            // 
            this.CBoxLanguage.DataSource = null;
            this.CBoxLanguage.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CBoxLanguage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxLanguage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBoxLanguage.ForeColor = System.Drawing.Color.Silver;
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
            this.CBoxLanguage.Location = new System.Drawing.Point(112, 42);
            this.CBoxLanguage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxLanguage.MaxDropDownItems = 5;
            this.CBoxLanguage.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxLanguage.Name = "CBoxLanguage";
            this.CBoxLanguage.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CBoxLanguage.Size = new System.Drawing.Size(185, 35);
            this.CBoxLanguage.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxLanguage.StyleCustomMode = true;
            this.CBoxLanguage.TabIndex = 13;
            this.CBoxLanguage.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBoxLanguage.Watermark = "";
            this.CBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.ChangeLanguage);
            this.CBoxLanguage.SelectedValueChanged += new System.EventHandler(this.ChangeLanguage);
            // 
            // LbGLanguage
            // 
            this.LbGLanguage.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbGLanguage.ForeColor = System.Drawing.Color.Silver;
            this.LbGLanguage.Location = new System.Drawing.Point(3, 45);
            this.LbGLanguage.Name = "LbGLanguage";
            this.LbGLanguage.Size = new System.Drawing.Size(102, 32);
            this.LbGLanguage.Style = Sunny.UI.UIStyle.Custom;
            this.LbGLanguage.StyleCustomMode = true;
            this.LbGLanguage.TabIndex = 14;
            this.LbGLanguage.Text = "text.settings.page.general.basicsettings.lang";
            this.LbGLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Edit
            // 
            this.Edit.AutoScroll = true;
            this.Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Edit.Controls.Add(this.CBoxEditorXshd);
            this.Edit.Controls.Add(this.uiLine4);
            this.Edit.Controls.Add(this.uiLine3);
            this.Edit.Controls.Add(this.uiLine2);
            this.Edit.Controls.Add(this.Lb_EditorText_Comment);
            this.Edit.Controls.Add(this.Lb_EditorText_Num);
            this.Edit.Controls.Add(this.BtnColor_Com);
            this.Edit.Controls.Add(this.BtnColor_Num);
            this.Edit.Controls.Add(this.Lb_EditorText_Normal);
            this.Edit.Controls.Add(this.BtnColor_Normal);
            this.Edit.Controls.Add(this.Lb_EditorText_Method);
            this.Edit.Controls.Add(this.BtnColor_Method);
            this.Edit.Controls.Add(this.Lb_EditorText_Keyword);
            this.Edit.Controls.Add(this.BtnColor_Keyword);
            this.Edit.Controls.Add(this.LbTextColors);
            this.Edit.Controls.Add(this.EHostForEditor);
            this.Edit.Controls.Add(this.CkBoxShowLN);
            this.Edit.Controls.Add(this.NUDFontSize);
            this.Edit.Controls.Add(this.LbFontSize);
            this.Edit.Controls.Add(this.LbWriteText);
            this.Edit.Controls.Add(this.CBoxEditorFont);
            this.Edit.Controls.Add(this.LbEditorFont);
            this.Edit.Location = new System.Drawing.Point(201, 0);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(704, 887);
            this.Edit.TabIndex = 2;
            this.Edit.Text = "text.settings.page.edit.title";
            // 
            // CBoxEditorXshd
            // 
            this.CBoxEditorXshd.DataSource = null;
            this.CBoxEditorXshd.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CBoxEditorXshd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxEditorXshd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBoxEditorXshd.ForeColor = System.Drawing.Color.Silver;
            this.CBoxEditorXshd.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxEditorXshd.ItemForeColor = System.Drawing.Color.Silver;
            this.CBoxEditorXshd.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CBoxEditorXshd.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CBoxEditorXshd.Location = new System.Drawing.Point(15, 266);
            this.CBoxEditorXshd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxEditorXshd.MaxDropDownItems = 5;
            this.CBoxEditorXshd.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxEditorXshd.Name = "CBoxEditorXshd";
            this.CBoxEditorXshd.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CBoxEditorXshd.Size = new System.Drawing.Size(221, 35);
            this.CBoxEditorXshd.Sorted = true;
            this.CBoxEditorXshd.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxEditorXshd.StyleCustomMode = true;
            this.CBoxEditorXshd.TabIndex = 26;
            this.CBoxEditorXshd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBoxEditorXshd.Watermark = "";
            this.CBoxEditorXshd.SelectedIndexChanged += new System.EventHandler(this.ChangeXshdColor);
            this.CBoxEditorXshd.SelectedValueChanged += new System.EventHandler(this.ChangeXshdColor);
            // 
            // uiLine4
            // 
            this.uiLine4.BackColor = System.Drawing.Color.Transparent;
            this.uiLine4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.uiLine4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiLine4.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.uiLine4.LineColorGradient = true;
            this.uiLine4.LineSize = 5;
            this.uiLine4.Location = new System.Drawing.Point(55, 40);
            this.uiLine4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(578, 31);
            this.uiLine4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine4.StyleCustomMode = true;
            this.uiLine4.TabIndex = 45;
            this.uiLine4.Text = "text.settings.page.edit.appearance.general.title";
            // 
            // uiLine3
            // 
            this.uiLine3.BackColor = System.Drawing.Color.Transparent;
            this.uiLine3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiLine3.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(2)))), ((int)(((byte)(52)))));
            this.uiLine3.LineSize = 3;
            this.uiLine3.Location = new System.Drawing.Point(21, 226);
            this.uiLine3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(221, 32);
            this.uiLine3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine3.StyleCustomMode = true;
            this.uiLine3.TabIndex = 44;
            this.uiLine3.Text = "text.settings.page.edit.appearance.choosexshd";
            // 
            // uiLine2
            // 
            this.uiLine2.BackColor = System.Drawing.Color.Transparent;
            this.uiLine2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiLine2.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.uiLine2.LineColorGradient = true;
            this.uiLine2.LineSize = 5;
            this.uiLine2.Location = new System.Drawing.Point(16, 3);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(656, 31);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.StyleCustomMode = true;
            this.uiLine2.TabIndex = 43;
            this.uiLine2.Text = "text.settings.page.edit.appearance.title";
            // 
            // Lb_EditorText_Comment
            // 
            this.Lb_EditorText_Comment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Lb_EditorText_Comment.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Lb_EditorText_Comment.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Comment.Location = new System.Drawing.Point(11, 513);
            this.Lb_EditorText_Comment.Name = "Lb_EditorText_Comment";
            this.Lb_EditorText_Comment.Size = new System.Drawing.Size(82, 32);
            this.Lb_EditorText_Comment.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Comment.StyleCustomMode = true;
            this.Lb_EditorText_Comment.TabIndex = 42;
            this.Lb_EditorText_Comment.Text = "text.settings.page.edit.appearance.font.color.comment";
            this.Lb_EditorText_Comment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lb_EditorText_Num
            // 
            this.Lb_EditorText_Num.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Lb_EditorText_Num.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Num.Location = new System.Drawing.Point(11, 415);
            this.Lb_EditorText_Num.Name = "Lb_EditorText_Num";
            this.Lb_EditorText_Num.Size = new System.Drawing.Size(82, 32);
            this.Lb_EditorText_Num.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Num.StyleCustomMode = true;
            this.Lb_EditorText_Num.TabIndex = 40;
            this.Lb_EditorText_Num.Text = "text.settings.page.edit.appearance.font.color.method";
            this.Lb_EditorText_Num.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnColor_Com
            // 
            this.BtnColor_Com.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Com.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Com.Location = new System.Drawing.Point(99, 507);
            this.BtnColor_Com.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Com.Name = "BtnColor_Com";
            this.BtnColor_Com.Size = new System.Drawing.Size(137, 43);
            this.BtnColor_Com.TabIndex = 41;
            this.BtnColor_Com.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Com.Click += new System.EventHandler(this.ChooseColor);
            // 
            // BtnColor_Num
            // 
            this.BtnColor_Num.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Num.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Num.Location = new System.Drawing.Point(99, 458);
            this.BtnColor_Num.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Num.Name = "BtnColor_Num";
            this.BtnColor_Num.Size = new System.Drawing.Size(137, 43);
            this.BtnColor_Num.TabIndex = 39;
            this.BtnColor_Num.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Num.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Lb_EditorText_Normal
            // 
            this.Lb_EditorText_Normal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Lb_EditorText_Normal.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Normal.Location = new System.Drawing.Point(11, 316);
            this.Lb_EditorText_Normal.Name = "Lb_EditorText_Normal";
            this.Lb_EditorText_Normal.Size = new System.Drawing.Size(82, 32);
            this.Lb_EditorText_Normal.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Normal.StyleCustomMode = true;
            this.Lb_EditorText_Normal.TabIndex = 38;
            this.Lb_EditorText_Normal.Text = "text.settings.page.edit.appearance.font.color.normal";
            this.Lb_EditorText_Normal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnColor_Normal
            // 
            this.BtnColor_Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.BtnColor_Normal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Normal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Normal.Location = new System.Drawing.Point(99, 309);
            this.BtnColor_Normal.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Normal.Name = "BtnColor_Normal";
            this.BtnColor_Normal.Size = new System.Drawing.Size(137, 45);
            this.BtnColor_Normal.TabIndex = 37;
            this.BtnColor_Normal.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Normal.UseVisualStyleBackColor = false;
            this.BtnColor_Normal.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Lb_EditorText_Method
            // 
            this.Lb_EditorText_Method.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Lb_EditorText_Method.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Method.Location = new System.Drawing.Point(11, 464);
            this.Lb_EditorText_Method.Name = "Lb_EditorText_Method";
            this.Lb_EditorText_Method.Size = new System.Drawing.Size(82, 32);
            this.Lb_EditorText_Method.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Method.StyleCustomMode = true;
            this.Lb_EditorText_Method.TabIndex = 36;
            this.Lb_EditorText_Method.Text = "text.settings.page.edit.appearance.font.color.number";
            this.Lb_EditorText_Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnColor_Method
            // 
            this.BtnColor_Method.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Method.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Method.Location = new System.Drawing.Point(99, 409);
            this.BtnColor_Method.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Method.Name = "BtnColor_Method";
            this.BtnColor_Method.Size = new System.Drawing.Size(137, 43);
            this.BtnColor_Method.TabIndex = 35;
            this.BtnColor_Method.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Method.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Lb_EditorText_Keyword
            // 
            this.Lb_EditorText_Keyword.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Lb_EditorText_Keyword.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Keyword.Location = new System.Drawing.Point(11, 366);
            this.Lb_EditorText_Keyword.Name = "Lb_EditorText_Keyword";
            this.Lb_EditorText_Keyword.Size = new System.Drawing.Size(82, 32);
            this.Lb_EditorText_Keyword.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Keyword.StyleCustomMode = true;
            this.Lb_EditorText_Keyword.TabIndex = 34;
            this.Lb_EditorText_Keyword.Text = "text.settings.page.edit.appearance.font.color.keyword";
            this.Lb_EditorText_Keyword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnColor_Keyword
            // 
            this.BtnColor_Keyword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Keyword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Keyword.Location = new System.Drawing.Point(99, 360);
            this.BtnColor_Keyword.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Keyword.Name = "BtnColor_Keyword";
            this.BtnColor_Keyword.Size = new System.Drawing.Size(137, 43);
            this.BtnColor_Keyword.TabIndex = 33;
            this.BtnColor_Keyword.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Keyword.Click += new System.EventHandler(this.ChooseColor);
            // 
            // LbTextColors
            // 
            this.LbTextColors.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbTextColors.ForeColor = System.Drawing.Color.Silver;
            this.LbTextColors.Location = new System.Drawing.Point(17, 198);
            this.LbTextColors.Name = "LbTextColors";
            this.LbTextColors.Size = new System.Drawing.Size(225, 32);
            this.LbTextColors.Style = Sunny.UI.UIStyle.Custom;
            this.LbTextColors.StyleCustomMode = true;
            this.LbTextColors.TabIndex = 32;
            this.LbTextColors.Text = "text.settings.page.edit.appearance.font.color";
            this.LbTextColors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EHostForEditor
            // 
            this.EHostForEditor.Location = new System.Drawing.Point(252, 148);
            this.EHostForEditor.Name = "EHostForEditor";
            this.EHostForEditor.Size = new System.Drawing.Size(413, 402);
            this.EHostForEditor.TabIndex = 31;
            this.EHostForEditor.Child = null;
            // 
            // CkBoxShowLN
            // 
            this.CkBoxShowLN.Checked = true;
            this.CkBoxShowLN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CkBoxShowLN.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CkBoxShowLN.ForeColor = System.Drawing.Color.Silver;
            this.CkBoxShowLN.Location = new System.Drawing.Point(21, 155);
            this.CkBoxShowLN.MinimumSize = new System.Drawing.Size(1, 1);
            this.CkBoxShowLN.Name = "CkBoxShowLN";
            this.CkBoxShowLN.Size = new System.Drawing.Size(215, 30);
            this.CkBoxShowLN.Style = Sunny.UI.UIStyle.Custom;
            this.CkBoxShowLN.StyleCustomMode = true;
            this.CkBoxShowLN.TabIndex = 30;
            this.CkBoxShowLN.Text = "text.settings.page.edit.appearance.editor.showlinenum";
            this.CkBoxShowLN.CheckedChanged += new System.EventHandler(this.UpdateSettings);
            // 
            // NUDFontSize
            // 
            this.NUDFontSize.FillColor = System.Drawing.Color.Transparent;
            this.NUDFontSize.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NUDFontSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.NUDFontSize.Location = new System.Drawing.Point(565, 86);
            this.NUDFontSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NUDFontSize.Maximum = 144;
            this.NUDFontSize.Minimum = 1;
            this.NUDFontSize.MinimumSize = new System.Drawing.Size(100, 0);
            this.NUDFontSize.Name = "NUDFontSize";
            this.NUDFontSize.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
            this.NUDFontSize.ShowText = false;
            this.NUDFontSize.Size = new System.Drawing.Size(100, 30);
            this.NUDFontSize.Style = Sunny.UI.UIStyle.Custom;
            this.NUDFontSize.StyleCustomMode = true;
            this.NUDFontSize.TabIndex = 29;
            this.NUDFontSize.Text = null;
            this.NUDFontSize.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.NUDFontSize.Value = 12;
            this.NUDFontSize.ValueChanged += new Sunny.UI.UIIntegerUpDown.OnValueChanged(this.Update);
            // 
            // LbFontSize
            // 
            this.LbFontSize.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbFontSize.ForeColor = System.Drawing.Color.Silver;
            this.LbFontSize.Location = new System.Drawing.Point(449, 86);
            this.LbFontSize.Name = "LbFontSize";
            this.LbFontSize.Size = new System.Drawing.Size(109, 32);
            this.LbFontSize.Style = Sunny.UI.UIStyle.Custom;
            this.LbFontSize.StyleCustomMode = true;
            this.LbFontSize.TabIndex = 28;
            this.LbFontSize.Text = "text.settings.page.edit.appearance.font.size";
            this.LbFontSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbWriteText
            // 
            this.LbWriteText.BackColor = System.Drawing.Color.Transparent;
            this.LbWriteText.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.LbWriteText.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbWriteText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.LbWriteText.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(2)))), ((int)(((byte)(52)))));
            this.LbWriteText.LineSize = 3;
            this.LbWriteText.Location = new System.Drawing.Point(21, 117);
            this.LbWriteText.MinimumSize = new System.Drawing.Size(1, 1);
            this.LbWriteText.Name = "LbWriteText";
            this.LbWriteText.Size = new System.Drawing.Size(644, 32);
            this.LbWriteText.Style = Sunny.UI.UIStyle.Custom;
            this.LbWriteText.StyleCustomMode = true;
            this.LbWriteText.TabIndex = 27;
            this.LbWriteText.Text = "text.settings.page.edit.appearance.font.writetesttexts";
            this.LbWriteText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CBoxEditorFont
            // 
            this.CBoxEditorFont.DataSource = null;
            this.CBoxEditorFont.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CBoxEditorFont.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxEditorFont.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBoxEditorFont.ForeColor = System.Drawing.Color.Silver;
            this.CBoxEditorFont.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxEditorFont.ItemForeColor = System.Drawing.Color.Silver;
            this.CBoxEditorFont.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CBoxEditorFont.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CBoxEditorFont.Location = new System.Drawing.Point(130, 81);
            this.CBoxEditorFont.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxEditorFont.MaxDropDownItems = 5;
            this.CBoxEditorFont.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxEditorFont.Name = "CBoxEditorFont";
            this.CBoxEditorFont.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CBoxEditorFont.Size = new System.Drawing.Size(288, 35);
            this.CBoxEditorFont.Sorted = true;
            this.CBoxEditorFont.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxEditorFont.StyleCustomMode = true;
            this.CBoxEditorFont.TabIndex = 25;
            this.CBoxEditorFont.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBoxEditorFont.Watermark = "";
            this.CBoxEditorFont.SelectedIndexChanged += new System.EventHandler(this.Update);
            this.CBoxEditorFont.SelectedValueChanged += new System.EventHandler(this.Update);
            // 
            // LbEditorFont
            // 
            this.LbEditorFont.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbEditorFont.ForeColor = System.Drawing.Color.Silver;
            this.LbEditorFont.Location = new System.Drawing.Point(21, 86);
            this.LbEditorFont.Name = "LbEditorFont";
            this.LbEditorFont.Size = new System.Drawing.Size(102, 32);
            this.LbEditorFont.Style = Sunny.UI.UIStyle.Custom;
            this.LbEditorFont.StyleCustomMode = true;
            this.LbEditorFont.TabIndex = 26;
            this.LbEditorFont.Text = "text.settings.page.edit.appearance.font";
            this.LbEditorFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // uiButton1
            // 
            this.uiButton1.BackColor = System.Drawing.Color.Transparent;
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiButton1.FlatAppearance.BorderSize = 0;
            this.uiButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.ForeColor = System.Drawing.Color.Transparent;
            this.uiButton1.Image = global::IDE.Properties.Resources.delete;
            this.uiButton1.Location = new System.Drawing.Point(848, 4);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(28, 28);
            this.uiButton1.TabIndex = 1;
            this.uiButton1.UseVisualStyleBackColor = false;
            this.uiButton1.Click += new System.EventHandler(this.Exit);
            // 
            // CustomSettings
            // 
            this.AllowAddControlOnTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(905, 922);
            this.ControlBox = false;
            this.ControlBoxFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.MainTabCtrl);
            this.EscClose = true;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomSettings";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "text.settings.window.title";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.TitleFont = new System.Drawing.Font("微软雅黑", 12F);
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 842, 400);
            this.Load += new System.EventHandler(this.CustomSettings_Load);
            this.Shown += new System.EventHandler(this.FormUpdate);
            this.MainTabCtrl.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.Edit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog XshdFileFinder;
        private Sunny.UI.UITabControlMenu MainTabCtrl;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage Edit;
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
        private System.Windows.Forms.Button uiButton1;
        private Sunny.UI.UILine uiLine4;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UIComboBox CBoxEditorXshd;
    }
}