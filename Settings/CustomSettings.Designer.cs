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
            this.Pl_BS = new Sunny.UI.UITitlePanel();
            this.CBoxLanguage = new Sunny.UI.UIComboBox();
            this.LbGLanguage = new Sunny.UI.UILabel();
            this.XshdFilePanel = new Sunny.UI.UITitlePanel();
            this.txtBoxXshdCache = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.XshdCachePathChooser = new Sunny.UI.UIButton();
            this.XshdFileChooser = new Sunny.UI.UIButton();
            this.CBoxXshdFile = new Sunny.UI.UIComboBox();
            this.Edit = new System.Windows.Forms.TabPage();
            this.Pl_E = new Sunny.UI.UITitlePanel();
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
            this.LbWriteText = new Sunny.UI.UILabel();
            this.CBoxEditorFont = new Sunny.UI.UIComboBox();
            this.LbEditorFont = new Sunny.UI.UILabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.MainTabCtrl.SuspendLayout();
            this.General.SuspendLayout();
            this.Pl_BS.SuspendLayout();
            this.XshdFilePanel.SuspendLayout();
            this.Edit.SuspendLayout();
            this.Pl_E.SuspendLayout();
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
            this.MainTabCtrl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.MainTabCtrl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainTabCtrl.Location = new System.Drawing.Point(3, 39);
            this.MainTabCtrl.Multiline = true;
            this.MainTabCtrl.Name = "MainTabCtrl";
            this.MainTabCtrl.SelectedIndex = 0;
            this.MainTabCtrl.Size = new System.Drawing.Size(854, 380);
            this.MainTabCtrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainTabCtrl.Style = Sunny.UI.UIStyle.Black;
            this.MainTabCtrl.TabIndex = 0;
            // 
            // General
            // 
            this.General.AutoScroll = true;
            this.General.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.General.Controls.Add(this.Pl_BS);
            this.General.Controls.Add(this.XshdFilePanel);
            this.General.Location = new System.Drawing.Point(201, 0);
            this.General.Name = "General";
            this.General.Size = new System.Drawing.Size(653, 380);
            this.General.TabIndex = 0;
            this.General.Text = "text.settings.page.general.title";
            // 
            // Pl_BS
            // 
            this.Pl_BS.AutoScroll = true;
            this.Pl_BS.Controls.Add(this.CBoxLanguage);
            this.Pl_BS.Controls.Add(this.LbGLanguage);
            this.Pl_BS.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Pl_BS.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Pl_BS.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.Pl_BS.ForeColor = System.Drawing.Color.White;
            this.Pl_BS.Location = new System.Drawing.Point(4, 9);
            this.Pl_BS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Pl_BS.MinimumSize = new System.Drawing.Size(1, 1);
            this.Pl_BS.Name = "Pl_BS";
            this.Pl_BS.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.Pl_BS.ShowText = false;
            this.Pl_BS.Size = new System.Drawing.Size(627, 118);
            this.Pl_BS.Style = Sunny.UI.UIStyle.Custom;
            this.Pl_BS.StyleCustomMode = true;
            this.Pl_BS.TabIndex = 8;
            this.Pl_BS.Text = "text.settings.page.general.basicsettings.title";
            this.Pl_BS.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CBoxLanguage
            // 
            this.CBoxLanguage.DataSource = null;
            this.CBoxLanguage.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.errorProvider1.SetError(this.CBoxLanguage, "重启应用程序后生效。");
            this.CBoxLanguage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxLanguage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBoxLanguage.ForeColor = System.Drawing.Color.Silver;
            this.errorProvider1.SetIconPadding(this.CBoxLanguage, 10);
            this.CBoxLanguage.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxLanguage.ItemForeColor = System.Drawing.Color.Silver;
            this.CBoxLanguage.Items.AddRange(new object[] {
            "简体中文",
            "繁體中文",
            "English",
            "日本語"});
            this.CBoxLanguage.Location = new System.Drawing.Point(112, 40);
            this.CBoxLanguage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxLanguage.MaxDropDownItems = 5;
            this.CBoxLanguage.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxLanguage.Name = "CBoxLanguage";
            this.CBoxLanguage.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CBoxLanguage.Size = new System.Drawing.Size(185, 35);
            this.CBoxLanguage.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxLanguage.StyleCustomMode = true;
            this.CBoxLanguage.TabIndex = 3;
            this.CBoxLanguage.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBoxLanguage.Watermark = "";
            this.CBoxLanguage.SelectedValueChanged += new System.EventHandler(this.ChangeLanguage);
            // 
            // LbGLanguage
            // 
            this.LbGLanguage.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbGLanguage.ForeColor = System.Drawing.Color.Silver;
            this.LbGLanguage.Location = new System.Drawing.Point(3, 43);
            this.LbGLanguage.Name = "LbGLanguage";
            this.LbGLanguage.Size = new System.Drawing.Size(102, 32);
            this.LbGLanguage.Style = Sunny.UI.UIStyle.Custom;
            this.LbGLanguage.StyleCustomMode = true;
            this.LbGLanguage.TabIndex = 7;
            this.LbGLanguage.Text = "text.settings.page.general.basicsettings.lang";
            this.LbGLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // XshdFilePanel
            // 
            this.XshdFilePanel.AutoScroll = true;
            this.XshdFilePanel.Controls.Add(this.txtBoxXshdCache);
            this.XshdFilePanel.Controls.Add(this.uiLabel1);
            this.XshdFilePanel.Controls.Add(this.XshdCachePathChooser);
            this.XshdFilePanel.Controls.Add(this.XshdFileChooser);
            this.XshdFilePanel.Controls.Add(this.CBoxXshdFile);
            this.XshdFilePanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.XshdFilePanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.XshdFilePanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.XshdFilePanel.ForeColor = System.Drawing.Color.White;
            this.XshdFilePanel.Location = new System.Drawing.Point(4, 137);
            this.XshdFilePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.XshdFilePanel.MinimumSize = new System.Drawing.Size(1, 1);
            this.XshdFilePanel.Name = "XshdFilePanel";
            this.XshdFilePanel.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.XshdFilePanel.ShowText = false;
            this.XshdFilePanel.Size = new System.Drawing.Size(627, 118);
            this.XshdFilePanel.Style = Sunny.UI.UIStyle.Custom;
            this.XshdFilePanel.StyleCustomMode = true;
            this.XshdFilePanel.TabIndex = 4;
            this.XshdFilePanel.Text = "text.settings.page.general.xshdfilesettings.title";
            this.XshdFilePanel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxXshdCache
            // 
            this.txtBoxXshdCache.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txtBoxXshdCache.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxXshdCache.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.txtBoxXshdCache.FillReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.txtBoxXshdCache.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxXshdCache.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtBoxXshdCache.ForeReadOnlyColor = System.Drawing.Color.WhiteSmoke;
            this.txtBoxXshdCache.Location = new System.Drawing.Point(165, 40);
            this.txtBoxXshdCache.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxXshdCache.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtBoxXshdCache.Name = "txtBoxXshdCache";
            this.txtBoxXshdCache.Padding = new System.Windows.Forms.Padding(5);
            this.txtBoxXshdCache.ReadOnly = true;
            this.txtBoxXshdCache.RectReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtBoxXshdCache.ShowText = false;
            this.txtBoxXshdCache.Size = new System.Drawing.Size(325, 34);
            this.txtBoxXshdCache.Style = Sunny.UI.UIStyle.Custom;
            this.txtBoxXshdCache.StyleCustomMode = true;
            this.txtBoxXshdCache.TabIndex = 7;
            this.txtBoxXshdCache.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtBoxXshdCache.Watermark = "";
            this.txtBoxXshdCache.TextChanged += new System.EventHandler(this.ChangeCachePath);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLabel1.ForeColor = System.Drawing.Color.Silver;
            this.uiLabel1.Location = new System.Drawing.Point(3, 40);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(178, 32);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.StyleCustomMode = true;
            this.uiLabel1.TabIndex = 6;
            this.uiLabel1.Text = "Xshd文件缓存路径：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // XshdCachePathChooser
            // 
            this.XshdCachePathChooser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XshdCachePathChooser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XshdCachePathChooser.Location = new System.Drawing.Point(497, 40);
            this.XshdCachePathChooser.MinimumSize = new System.Drawing.Size(1, 1);
            this.XshdCachePathChooser.Name = "XshdCachePathChooser";
            this.XshdCachePathChooser.Size = new System.Drawing.Size(127, 35);
            this.XshdCachePathChooser.Style = Sunny.UI.UIStyle.Custom;
            this.XshdCachePathChooser.TabIndex = 5;
            this.XshdCachePathChooser.Text = "选择文件夹";
            this.XshdCachePathChooser.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XshdCachePathChooser.Click += new System.EventHandler(this.PickDiretory);
            // 
            // XshdFileChooser
            // 
            this.XshdFileChooser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XshdFileChooser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XshdFileChooser.Location = new System.Drawing.Point(515, 78);
            this.XshdFileChooser.MinimumSize = new System.Drawing.Size(1, 1);
            this.XshdFileChooser.Name = "XshdFileChooser";
            this.XshdFileChooser.Size = new System.Drawing.Size(109, 35);
            this.XshdFileChooser.Style = Sunny.UI.UIStyle.Custom;
            this.XshdFileChooser.TabIndex = 3;
            this.XshdFileChooser.Text = "选择文件";
            this.XshdFileChooser.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XshdFileChooser.Click += new System.EventHandler(this.ChooseXshdFile);
            // 
            // CBoxXshdFile
            // 
            this.CBoxXshdFile.DataSource = null;
            this.CBoxXshdFile.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CBoxXshdFile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxXshdFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBoxXshdFile.ForeColor = System.Drawing.Color.Silver;
            this.CBoxXshdFile.ItemFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CBoxXshdFile.ItemForeColor = System.Drawing.Color.Silver;
            this.CBoxXshdFile.Location = new System.Drawing.Point(4, 78);
            this.CBoxXshdFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxXshdFile.MaxDropDownItems = 5;
            this.CBoxXshdFile.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxXshdFile.Name = "CBoxXshdFile";
            this.CBoxXshdFile.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CBoxXshdFile.Size = new System.Drawing.Size(504, 35);
            this.CBoxXshdFile.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxXshdFile.StyleCustomMode = true;
            this.CBoxXshdFile.TabIndex = 2;
            this.CBoxXshdFile.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBoxXshdFile.Watermark = "";
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Edit.Controls.Add(this.Pl_E);
            this.Edit.Location = new System.Drawing.Point(201, 0);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(653, 380);
            this.Edit.TabIndex = 2;
            this.Edit.Text = "text.settings.page.edit.title";
            // 
            // Pl_E
            // 
            this.Pl_E.Controls.Add(this.Lb_EditorText_Comment);
            this.Pl_E.Controls.Add(this.Lb_EditorText_Num);
            this.Pl_E.Controls.Add(this.BtnColor_Com);
            this.Pl_E.Controls.Add(this.BtnColor_Num);
            this.Pl_E.Controls.Add(this.Lb_EditorText_Normal);
            this.Pl_E.Controls.Add(this.BtnColor_Normal);
            this.Pl_E.Controls.Add(this.Lb_EditorText_Method);
            this.Pl_E.Controls.Add(this.BtnColor_Method);
            this.Pl_E.Controls.Add(this.Lb_EditorText_Keyword);
            this.Pl_E.Controls.Add(this.BtnColor_Keyword);
            this.Pl_E.Controls.Add(this.LbTextColors);
            this.Pl_E.Controls.Add(this.EHostForEditor);
            this.Pl_E.Controls.Add(this.CkBoxShowLN);
            this.Pl_E.Controls.Add(this.NUDFontSize);
            this.Pl_E.Controls.Add(this.LbFontSize);
            this.Pl_E.Controls.Add(this.LbWriteText);
            this.Pl_E.Controls.Add(this.CBoxEditorFont);
            this.Pl_E.Controls.Add(this.LbEditorFont);
            this.Pl_E.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Pl_E.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Pl_E.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.Pl_E.ForeColor = System.Drawing.Color.White;
            this.Pl_E.Location = new System.Drawing.Point(8, 5);
            this.Pl_E.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Pl_E.MinimumSize = new System.Drawing.Size(1, 1);
            this.Pl_E.Name = "Pl_E";
            this.Pl_E.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.Pl_E.ShowText = false;
            this.Pl_E.Size = new System.Drawing.Size(627, 370);
            this.Pl_E.Style = Sunny.UI.UIStyle.Custom;
            this.Pl_E.StyleCustomMode = true;
            this.Pl_E.TabIndex = 9;
            this.Pl_E.Text = "text.settings.page.edit.appearance.title";
            this.Pl_E.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lb_EditorText_Comment
            // 
            this.Lb_EditorText_Comment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Lb_EditorText_Comment.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Lb_EditorText_Comment.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Comment.Location = new System.Drawing.Point(3, 331);
            this.Lb_EditorText_Comment.Name = "Lb_EditorText_Comment";
            this.Lb_EditorText_Comment.Size = new System.Drawing.Size(82, 32);
            this.Lb_EditorText_Comment.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Comment.StyleCustomMode = true;
            this.Lb_EditorText_Comment.TabIndex = 24;
            this.Lb_EditorText_Comment.Text = "text.settings.page.edit.appearance.font.color.comment";
            this.Lb_EditorText_Comment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lb_EditorText_Num
            // 
            this.Lb_EditorText_Num.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Lb_EditorText_Num.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Num.Location = new System.Drawing.Point(3, 294);
            this.Lb_EditorText_Num.Name = "Lb_EditorText_Num";
            this.Lb_EditorText_Num.Size = new System.Drawing.Size(82, 32);
            this.Lb_EditorText_Num.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Num.StyleCustomMode = true;
            this.Lb_EditorText_Num.TabIndex = 22;
            this.Lb_EditorText_Num.Text = "text.settings.page.edit.appearance.font.color.number";
            this.Lb_EditorText_Num.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnColor_Com
            // 
            this.BtnColor_Com.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Com.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Com.Location = new System.Drawing.Point(91, 329);
            this.BtnColor_Com.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Com.Name = "BtnColor_Com";
            this.BtnColor_Com.Size = new System.Drawing.Size(137, 31);
            this.BtnColor_Com.TabIndex = 23;
            this.BtnColor_Com.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Com.Click += new System.EventHandler(this.ChooseColor);
            // 
            // BtnColor_Num
            // 
            this.BtnColor_Num.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Num.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Num.Location = new System.Drawing.Point(91, 292);
            this.BtnColor_Num.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Num.Name = "BtnColor_Num";
            this.BtnColor_Num.Size = new System.Drawing.Size(137, 31);
            this.BtnColor_Num.TabIndex = 21;
            this.BtnColor_Num.Text = "text.settings.page.edit.appearance.font.color.choose";
            // 
            // Lb_EditorText_Normal
            // 
            this.Lb_EditorText_Normal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Lb_EditorText_Normal.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Normal.Location = new System.Drawing.Point(3, 181);
            this.Lb_EditorText_Normal.Name = "Lb_EditorText_Normal";
            this.Lb_EditorText_Normal.Size = new System.Drawing.Size(82, 32);
            this.Lb_EditorText_Normal.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Normal.StyleCustomMode = true;
            this.Lb_EditorText_Normal.TabIndex = 20;
            this.Lb_EditorText_Normal.Text = "text.settings.page.edit.appearance.font.color.normal";
            this.Lb_EditorText_Normal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnColor_Normal
            // 
            this.BtnColor_Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.BtnColor_Normal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Normal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Normal.Location = new System.Drawing.Point(91, 179);
            this.BtnColor_Normal.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Normal.Name = "BtnColor_Normal";
            this.BtnColor_Normal.Size = new System.Drawing.Size(137, 33);
            this.BtnColor_Normal.TabIndex = 19;
            this.BtnColor_Normal.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Normal.UseVisualStyleBackColor = false;
            this.BtnColor_Normal.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Lb_EditorText_Method
            // 
            this.Lb_EditorText_Method.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Lb_EditorText_Method.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Method.Location = new System.Drawing.Point(3, 257);
            this.Lb_EditorText_Method.Name = "Lb_EditorText_Method";
            this.Lb_EditorText_Method.Size = new System.Drawing.Size(82, 32);
            this.Lb_EditorText_Method.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Method.StyleCustomMode = true;
            this.Lb_EditorText_Method.TabIndex = 18;
            this.Lb_EditorText_Method.Text = "text.settings.page.edit.appearance.font.color.method";
            this.Lb_EditorText_Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnColor_Method
            // 
            this.BtnColor_Method.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Method.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Method.Location = new System.Drawing.Point(91, 255);
            this.BtnColor_Method.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Method.Name = "BtnColor_Method";
            this.BtnColor_Method.Size = new System.Drawing.Size(137, 31);
            this.BtnColor_Method.TabIndex = 17;
            this.BtnColor_Method.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Method.Click += new System.EventHandler(this.ChooseColor);
            // 
            // Lb_EditorText_Keyword
            // 
            this.Lb_EditorText_Keyword.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Lb_EditorText_Keyword.ForeColor = System.Drawing.Color.Silver;
            this.Lb_EditorText_Keyword.Location = new System.Drawing.Point(3, 218);
            this.Lb_EditorText_Keyword.Name = "Lb_EditorText_Keyword";
            this.Lb_EditorText_Keyword.Size = new System.Drawing.Size(82, 32);
            this.Lb_EditorText_Keyword.Style = Sunny.UI.UIStyle.Custom;
            this.Lb_EditorText_Keyword.StyleCustomMode = true;
            this.Lb_EditorText_Keyword.TabIndex = 16;
            this.Lb_EditorText_Keyword.Text = "text.settings.page.edit.appearance.font.color.keyword";
            this.Lb_EditorText_Keyword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnColor_Keyword
            // 
            this.BtnColor_Keyword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnColor_Keyword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnColor_Keyword.Location = new System.Drawing.Point(91, 216);
            this.BtnColor_Keyword.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnColor_Keyword.Name = "BtnColor_Keyword";
            this.BtnColor_Keyword.Size = new System.Drawing.Size(137, 31);
            this.BtnColor_Keyword.TabIndex = 15;
            this.BtnColor_Keyword.Text = "text.settings.page.edit.appearance.font.color.choose";
            this.BtnColor_Keyword.Click += new System.EventHandler(this.ChooseColor);
            // 
            // LbTextColors
            // 
            this.LbTextColors.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbTextColors.ForeColor = System.Drawing.Color.Silver;
            this.LbTextColors.Location = new System.Drawing.Point(3, 144);
            this.LbTextColors.Name = "LbTextColors";
            this.LbTextColors.Size = new System.Drawing.Size(225, 32);
            this.LbTextColors.Style = Sunny.UI.UIStyle.Custom;
            this.LbTextColors.StyleCustomMode = true;
            this.LbTextColors.TabIndex = 14;
            this.LbTextColors.Text = "text.settings.page.edit.appearance.font.color";
            this.LbTextColors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EHostForEditor
            // 
            this.EHostForEditor.Location = new System.Drawing.Point(234, 107);
            this.EHostForEditor.Name = "EHostForEditor";
            this.EHostForEditor.Size = new System.Drawing.Size(388, 253);
            this.EHostForEditor.TabIndex = 13;
            this.EHostForEditor.Child = null;
            // 
            // CkBoxShowLN
            // 
            this.CkBoxShowLN.Checked = true;
            this.CkBoxShowLN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CkBoxShowLN.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CkBoxShowLN.ForeColor = System.Drawing.Color.Silver;
            this.CkBoxShowLN.Location = new System.Drawing.Point(7, 111);
            this.CkBoxShowLN.MinimumSize = new System.Drawing.Size(1, 1);
            this.CkBoxShowLN.Name = "CkBoxShowLN";
            this.CkBoxShowLN.Size = new System.Drawing.Size(215, 30);
            this.CkBoxShowLN.Style = Sunny.UI.UIStyle.Custom;
            this.CkBoxShowLN.StyleCustomMode = true;
            this.CkBoxShowLN.TabIndex = 12;
            this.CkBoxShowLN.Text = "text.settings.page.edit.appearance.editor.showlinenum";
            this.CkBoxShowLN.CheckedChanged += new System.EventHandler(this.UpdateSettings);
            // 
            // NUDFontSize
            // 
            this.NUDFontSize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.NUDFontSize.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NUDFontSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.NUDFontSize.Location = new System.Drawing.Point(523, 45);
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
            this.NUDFontSize.TabIndex = 11;
            this.NUDFontSize.Text = null;
            this.NUDFontSize.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.NUDFontSize.Value = 12;
            this.NUDFontSize.ValueChanged += new Sunny.UI.UIIntegerUpDown.OnValueChanged(this.Update);
            // 
            // LbFontSize
            // 
            this.LbFontSize.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbFontSize.ForeColor = System.Drawing.Color.Silver;
            this.LbFontSize.Location = new System.Drawing.Point(407, 45);
            this.LbFontSize.Name = "LbFontSize";
            this.LbFontSize.Size = new System.Drawing.Size(109, 32);
            this.LbFontSize.Style = Sunny.UI.UIStyle.Custom;
            this.LbFontSize.StyleCustomMode = true;
            this.LbFontSize.TabIndex = 10;
            this.LbFontSize.Text = "text.settings.page.edit.appearance.font.size";
            this.LbFontSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbWriteText
            // 
            this.LbWriteText.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbWriteText.ForeColor = System.Drawing.Color.Silver;
            this.LbWriteText.Location = new System.Drawing.Point(3, 76);
            this.LbWriteText.Name = "LbWriteText";
            this.LbWriteText.Size = new System.Drawing.Size(620, 32);
            this.LbWriteText.Style = Sunny.UI.UIStyle.Custom;
            this.LbWriteText.StyleCustomMode = true;
            this.LbWriteText.TabIndex = 9;
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
            this.CBoxEditorFont.Items.AddRange(new object[] {
            "English",
            "繁體中文",
            "简体中文",
            "日本語"});
            this.CBoxEditorFont.Location = new System.Drawing.Point(112, 40);
            this.CBoxEditorFont.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxEditorFont.MaxDropDownItems = 5;
            this.CBoxEditorFont.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxEditorFont.Name = "CBoxEditorFont";
            this.CBoxEditorFont.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CBoxEditorFont.Size = new System.Drawing.Size(288, 35);
            this.CBoxEditorFont.Sorted = true;
            this.CBoxEditorFont.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxEditorFont.StyleCustomMode = true;
            this.CBoxEditorFont.TabIndex = 3;
            this.CBoxEditorFont.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBoxEditorFont.Watermark = "";
            this.CBoxEditorFont.TextChanged += new System.EventHandler(this.Update);
            this.CBoxEditorFont.SelectedIndexChanged += new System.EventHandler(this.Update);
            this.CBoxEditorFont.SelectedValueChanged += new System.EventHandler(this.Update);
            // 
            // LbEditorFont
            // 
            this.LbEditorFont.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.LbEditorFont.ForeColor = System.Drawing.Color.Silver;
            this.LbEditorFont.Location = new System.Drawing.Point(3, 43);
            this.LbEditorFont.Name = "LbEditorFont";
            this.LbEditorFont.Size = new System.Drawing.Size(102, 32);
            this.LbEditorFont.Style = Sunny.UI.UIStyle.Custom;
            this.LbEditorFont.StyleCustomMode = true;
            this.LbEditorFont.TabIndex = 7;
            this.LbEditorFont.Text = "text.settings.page.edit.appearance.font";
            this.LbEditorFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 100;
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // CustomSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(879, 423);
            this.ControlBoxFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.MainTabCtrl);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomSettings";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = Sunny.UI.UIStyle.Black;
            this.StyleCustomMode = true;
            this.Text = "text.settings.window.title";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 842, 400);
            this.Load += new System.EventHandler(this.CustomSettings_Load);
            this.Shown += new System.EventHandler(this.FormUpdate);
            this.MainTabCtrl.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.Pl_BS.ResumeLayout(false);
            this.XshdFilePanel.ResumeLayout(false);
            this.Edit.ResumeLayout(false);
            this.Pl_E.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog XshdFileFinder;
        private Sunny.UI.UITabControlMenu MainTabCtrl;
        private System.Windows.Forms.TabPage General;
        private Sunny.UI.UITitlePanel XshdFilePanel;
        private Sunny.UI.UIButton XshdFileChooser;
        private Sunny.UI.UIComboBox CBoxXshdFile;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton XshdCachePathChooser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Sunny.UI.UITextBox txtBoxXshdCache;
        private Sunny.UI.UITitlePanel Pl_BS;
        private Sunny.UI.UIComboBox CBoxLanguage;
        private Sunny.UI.UILabel LbGLanguage;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage Edit;
        private Sunny.UI.UITitlePanel Pl_E;
        private Sunny.UI.UILabel LbWriteText;
        private Sunny.UI.UIComboBox CBoxEditorFont;
        private Sunny.UI.UILabel LbEditorFont;
        private Sunny.UI.UIIntegerUpDown NUDFontSize;
        private Sunny.UI.UILabel LbFontSize;
        private Sunny.UI.UICheckBox CkBoxShowLN;
        private System.Windows.Forms.Integration.ElementHost EHostForEditor;
        private System.Windows.Forms.Button BtnColor_Keyword;
        private Sunny.UI.UILabel LbTextColors;
        private Sunny.UI.UILabel Lb_EditorText_Keyword;
        private Sunny.UI.UILabel Lb_EditorText_Normal;
        private System.Windows.Forms.Button BtnColor_Normal;
        private Sunny.UI.UILabel Lb_EditorText_Method;
        private System.Windows.Forms.Button BtnColor_Method;
        private Sunny.UI.UILabel Lb_EditorText_Num;
        private System.Windows.Forms.Button BtnColor_Num;
        private Sunny.UI.UILabel Lb_EditorText_Comment;
        private System.Windows.Forms.Button BtnColor_Com;
    }
}