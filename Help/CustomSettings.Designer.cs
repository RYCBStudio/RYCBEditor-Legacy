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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomSettings));
            this.XshdFileFinder = new System.Windows.Forms.OpenFileDialog();
            this.MainTabCtrl = new Sunny.UI.UITabControlMenu();
            this.General = new System.Windows.Forms.TabPage();
            this.XshdFilePanel = new Sunny.UI.UITitlePanel();
            this.XshdFileChooser = new Sunny.UI.UIButton();
            this.CBoxXshdFile = new Sunny.UI.UIComboBox();
            this.ShortCutKeys = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.MainTabCtrl.SuspendLayout();
            this.General.SuspendLayout();
            this.XshdFilePanel.SuspendLayout();
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
            this.MainTabCtrl.Controls.Add(this.ShortCutKeys);
            this.MainTabCtrl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.MainTabCtrl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainTabCtrl.Location = new System.Drawing.Point(3, 39);
            this.MainTabCtrl.Multiline = true;
            this.MainTabCtrl.Name = "MainTabCtrl";
            this.MainTabCtrl.SelectedIndex = 0;
            this.MainTabCtrl.Size = new System.Drawing.Size(836, 358);
            this.MainTabCtrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainTabCtrl.Style = Sunny.UI.UIStyle.Custom;
            this.MainTabCtrl.TabIndex = 0;
            this.MainTabCtrl.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // General
            // 
            this.General.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.General.Controls.Add(this.XshdFilePanel);
            this.General.Location = new System.Drawing.Point(201, 0);
            this.General.Name = "General";
            this.General.Size = new System.Drawing.Size(635, 358);
            this.General.TabIndex = 0;
            this.General.Text = "常规";
            // 
            // XshdFilePanel
            // 
            this.XshdFilePanel.Controls.Add(this.XshdFileChooser);
            this.XshdFilePanel.Controls.Add(this.CBoxXshdFile);
            this.XshdFilePanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.XshdFilePanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.XshdFilePanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.XshdFilePanel.ForeColor = System.Drawing.Color.White;
            this.XshdFilePanel.Location = new System.Drawing.Point(4, 5);
            this.XshdFilePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.XshdFilePanel.MinimumSize = new System.Drawing.Size(1, 1);
            this.XshdFilePanel.Name = "XshdFilePanel";
            this.XshdFilePanel.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.XshdFilePanel.ShowText = false;
            this.XshdFilePanel.Size = new System.Drawing.Size(627, 83);
            this.XshdFilePanel.Style = Sunny.UI.UIStyle.Custom;
            this.XshdFilePanel.StyleCustomMode = true;
            this.XshdFilePanel.TabIndex = 4;
            this.XshdFilePanel.Text = "Xshd文件设置";
            this.XshdFilePanel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.XshdFilePanel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // XshdFileChooser
            // 
            this.XshdFileChooser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XshdFileChooser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XshdFileChooser.Location = new System.Drawing.Point(515, 40);
            this.XshdFileChooser.MinimumSize = new System.Drawing.Size(1, 1);
            this.XshdFileChooser.Name = "XshdFileChooser";
            this.XshdFileChooser.Size = new System.Drawing.Size(109, 35);
            this.XshdFileChooser.Style = Sunny.UI.UIStyle.Custom;
            this.XshdFileChooser.TabIndex = 3;
            this.XshdFileChooser.Text = "选择文件";
            this.XshdFileChooser.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XshdFileChooser.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.CBoxXshdFile.Location = new System.Drawing.Point(4, 40);
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
            this.CBoxXshdFile.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ShortCutKeys
            // 
            this.ShortCutKeys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ShortCutKeys.Location = new System.Drawing.Point(201, 0);
            this.ShortCutKeys.Name = "ShortCutKeys";
            this.ShortCutKeys.Size = new System.Drawing.Size(635, 358);
            this.ShortCutKeys.TabIndex = 1;
            this.ShortCutKeys.Text = "快捷键";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(624, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "保存(Enter)";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(741, 403);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "取消(Esc)";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // CustomSettings
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(842, 446);
            this.ControlBoxFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "自定义";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 842, 400);
            this.MainTabCtrl.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.XshdFilePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog XshdFileFinder;
        private Sunny.UI.UITabControlMenu MainTabCtrl;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.TabPage ShortCutKeys;
        private Sunny.UI.UITitlePanel XshdFilePanel;
        private Sunny.UI.UIButton XshdFileChooser;
        private Sunny.UI.UIComboBox CBoxXshdFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}