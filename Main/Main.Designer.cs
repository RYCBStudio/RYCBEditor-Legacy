using System.Windows.Forms;

namespace IDE
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤消UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重复RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全选AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.开发者选项DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.崩溃测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成本地化示例文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new Sunny.UI.UITabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.SyntaxErrorChecker = new System.Windows.Forms.Timer(this.components);
            this.HelpButton = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.刷新RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭CtrlF4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.应用程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.鸣谢ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.许可与版权声明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.百宝箱ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.编辑EToolStripMenuItem,
            this.运行RToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.帮助HToolStripMenuItem,
            this.toolStripTextBox1,
            this.toolStripComboBox1,
            this.开发者选项DToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1902, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripMenuItem,
            this.打开OToolStripMenuItem,
            this.保存SToolStripMenuItem,
            this.另存为AToolStripMenuItem});
            this.文件FToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(95, 28);
            this.文件FToolStripMenuItem.Text = "text.ts.file";
            // 
            // 另存为AToolStripMenuItem
            // 
            this.另存为AToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.另存为AToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.另存为AToolStripMenuItem.Name = "另存为AToolStripMenuItem";
            this.另存为AToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.另存为AToolStripMenuItem.Text = "text.ts.file.saveanother";
            this.另存为AToolStripMenuItem.Click += new System.EventHandler(this.SaveFile);
            // 
            // 编辑EToolStripMenuItem
            // 
            this.编辑EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.撤消UToolStripMenuItem,
            this.重复RToolStripMenuItem,
            this.剪切TToolStripMenuItem,
            this.复制CToolStripMenuItem,
            this.粘贴PToolStripMenuItem,
            this.全选AToolStripMenuItem});
            this.编辑EToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(102, 28);
            this.编辑EToolStripMenuItem.Text = "text.ts.edit";
            // 
            // 撤消UToolStripMenuItem
            // 
            this.撤消UToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.撤消UToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.撤消UToolStripMenuItem.Name = "撤消UToolStripMenuItem";
            this.撤消UToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.撤消UToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.撤消UToolStripMenuItem.Text = "text.ts.edit.undo";
            // 
            // 重复RToolStripMenuItem
            // 
            this.重复RToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.重复RToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.重复RToolStripMenuItem.Name = "重复RToolStripMenuItem";
            this.重复RToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.重复RToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.重复RToolStripMenuItem.Text = "text.ts.edit.redo";
            // 
            // 全选AToolStripMenuItem
            // 
            this.全选AToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.全选AToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.全选AToolStripMenuItem.Name = "全选AToolStripMenuItem";
            this.全选AToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.全选AToolStripMenuItem.Text = "text.ts.edit.selectall";
            // 
            // 运行RToolStripMenuItem
            // 
            this.运行RToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.运行ToolStripMenuItem});
            this.运行RToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.运行RToolStripMenuItem.Name = "运行RToolStripMenuItem";
            this.运行RToolStripMenuItem.Size = new System.Drawing.Size(97, 28);
            this.运行RToolStripMenuItem.Text = "text.ts.run";
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自定义CToolStripMenuItem,
            this.选项OToolStripMenuItem,
            this.应用程序ToolStripMenuItem});
            this.工具TToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(103, 28);
            this.工具TToolStripMenuItem.Text = "text.ts.tool";
            // 
            // 选项OToolStripMenuItem
            // 
            this.选项OToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.选项OToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.选项OToolStripMenuItem.Name = "选项OToolStripMenuItem";
            this.选项OToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.选项OToolStripMenuItem.Text = "text.ts.tool.options";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem,
            this.鸣谢ToolStripMenuItem,
            this.许可与版权声明ToolStripMenuItem,
            this.百宝箱ToolStripMenuItem});
            this.帮助HToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(105, 28);
            this.帮助HToolStripMenuItem.Text = "text.ts.help";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.ControlText;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox1.Enabled = false;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.toolStripTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(250, 28);
            this.toolStripTextBox1.Text = "text.ts.langhighlighttype";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.BackColor = System.Drawing.Color.Black;
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStripComboBox1.ForeColor = System.Drawing.Color.White;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(135, 28);
            // 
            // 开发者选项DToolStripMenuItem
            // 
            this.开发者选项DToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.崩溃测试ToolStripMenuItem,
            this.生成本地化示例文件ToolStripMenuItem});
            this.开发者选项DToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.开发者选项DToolStripMenuItem.Name = "开发者选项DToolStripMenuItem";
            this.开发者选项DToolStripMenuItem.Size = new System.Drawing.Size(143, 28);
            this.开发者选项DToolStripMenuItem.Text = "text.ts.devmode";
            // 
            // 崩溃测试ToolStripMenuItem
            // 
            this.崩溃测试ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.崩溃测试ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.崩溃测试ToolStripMenuItem.Name = "崩溃测试ToolStripMenuItem";
            this.崩溃测试ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.崩溃测试ToolStripMenuItem.Size = new System.Drawing.Size(414, 26);
            this.崩溃测试ToolStripMenuItem.Text = "text.ts.devmode.crashtest";
            this.崩溃测试ToolStripMenuItem.Click += new System.EventHandler(this.TestCrash);
            // 
            // 生成本地化示例文件ToolStripMenuItem
            // 
            this.生成本地化示例文件ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.生成本地化示例文件ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.生成本地化示例文件ToolStripMenuItem.Name = "生成本地化示例文件ToolStripMenuItem";
            this.生成本地化示例文件ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.End)));
            this.生成本地化示例文件ToolStripMenuItem.Size = new System.Drawing.Size(414, 26);
            this.生成本地化示例文件ToolStripMenuItem.Text = "text.ts.devmode.genI18nfile";
            this.生成本地化示例文件ToolStripMenuItem.Click += new System.EventHandler(this.GenerateI18nExampleFile);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "code";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.Save);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pycn";
            this.saveFileDialog1.FileName = "code";
            this.saveFileDialog1.Filter = "Py-CN文件|*.pycn|Py-CN编译后文件|*.py";
            this.saveFileDialog1.InitialDirectory = "C:\\Windows\\System32";
            this.saveFileDialog1.Title = "选择保存的文件:";
            // 
            // tabControl1
            // 
            this.tabControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tabControl1.Frame = null;
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 35);
            this.tabControl1.MainPage = "";
            this.tabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowCloseButton = true;
            this.tabControl1.Size = new System.Drawing.Size(1902, 883);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.StyleCustomMode = true;
            this.tabControl1.TabBackColor = System.Drawing.Color.Black;
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tabControl1.BeforeRemoveTabPage += new Sunny.UI.UITabControl.OnBeforeRemoveTabPage(this.TabControl1_BeforeRemoveTabPage);
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.Layout);
            this.tabControl1.Validating += new System.ComponentModel.CancelEventHandler(this.Validating_Layout);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.Black;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新RToolStripMenuItem,
            this.关闭CtrlF4ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(269, 56);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.elementHost1);
            this.tabPage1.Location = new System.Drawing.Point(0, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1902, 853);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "text.tc.tp.tmp";
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(4, 4);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1872, 845);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Child = null;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.isExeFile);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(144, 20);
            this.toolStripStatusLabel2.Text = "文件：已禁止修改。";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Black;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 947);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1902, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(757, 20);
            this.toolStripStatusLabel4.Text = "                                                                                 " +
    "                                                                                " +
    "                          ";
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1100;
            this.timer3.Tick += new System.EventHandler(this.WriteDownMem);
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.Black;
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7});
            this.statusStrip2.Location = new System.Drawing.Point(0, 921);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1902, 26);
            this.statusStrip2.TabIndex = 4;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(47, 20);
            this.toolStripStatusLabel6.Text = "输入: ";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(0, 20);
            // 
            // timer4
            // 
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.SyncCC);
            // 
            // timer5
            // 
            this.timer5.Interval = 1000;
            this.timer5.Tick += new System.EventHandler(this.IsMaximized);
            // 
            // SyntaxErrorChecker
            // 
            this.SyntaxErrorChecker.Tick += new System.EventHandler(this.CheckSyntaxError);
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HelpButton.BackgroundImage = global::IDE.Properties.Resources.help2;
            this.HelpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpButton.FlatAppearance.BorderSize = 0;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Location = new System.Drawing.Point(1860, 12);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(30, 30);
            this.HelpButton.TabIndex = 5;
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.help);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::IDE.Properties.Resources._48x48_Warn;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 20);
            this.toolStripStatusLabel1.Text = "    ";
            this.toolStripStatusLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // 刷新RToolStripMenuItem
            // 
            this.刷新RToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.刷新RToolStripMenuItem.Image = global::IDE.Properties.Resources.refresh;
            this.刷新RToolStripMenuItem.Name = "刷新RToolStripMenuItem";
            this.刷新RToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.刷新RToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.刷新RToolStripMenuItem.Text = "text.cms.1.refresh";
            // 
            // 关闭CtrlF4ToolStripMenuItem
            // 
            this.关闭CtrlF4ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.关闭CtrlF4ToolStripMenuItem.Image = global::IDE.Properties.Resources.delete;
            this.关闭CtrlF4ToolStripMenuItem.Name = "关闭CtrlF4ToolStripMenuItem";
            this.关闭CtrlF4ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.关闭CtrlF4ToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.关闭CtrlF4ToolStripMenuItem.Text = "text.cms.1.close";
            this.关闭CtrlF4ToolStripMenuItem.Click += new System.EventHandler(this.CloseFile);
            // 
            // 新建NToolStripMenuItem
            // 
            this.新建NToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.新建NToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.项目ToolStripMenuItem,
            this.文件ToolStripMenuItem});
            this.新建NToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.新建NToolStripMenuItem.Image = global::IDE.Properties.Resources.edit;
            this.新建NToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新建NToolStripMenuItem.Name = "新建NToolStripMenuItem";
            this.新建NToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.新建NToolStripMenuItem.Text = "text.ts.file.new";
            // 
            // 项目ToolStripMenuItem
            // 
            this.项目ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.项目ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.项目ToolStripMenuItem.Image = global::IDE.Properties.Resources.Window;
            this.项目ToolStripMenuItem.Name = "项目ToolStripMenuItem";
            this.项目ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.项目ToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.项目ToolStripMenuItem.Text = "text.ts.file.new.proj";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.文件ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.文件ToolStripMenuItem.Image = global::IDE.Properties.Resources.file_common;
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.文件ToolStripMenuItem.Text = "text.ts.file.new.file";
            this.文件ToolStripMenuItem.Click += new System.EventHandler(this.New);
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.打开OToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.打开OToolStripMenuItem.Image = global::IDE.Properties.Resources._disabled_open_file;
            this.打开OToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.打开OToolStripMenuItem.Text = "text.ts.file.open";
            this.打开OToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.保存SToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.保存SToolStripMenuItem.Image = global::IDE.Properties.Resources.save;
            this.保存SToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.保存SToolStripMenuItem.Text = "text.ts.file.save";
            this.保存SToolStripMenuItem.Click += new System.EventHandler(this.QuietSave);
            // 
            // 剪切TToolStripMenuItem
            // 
            this.剪切TToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.剪切TToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.剪切TToolStripMenuItem.Image = global::IDE.Properties.Resources.edit_cut1;
            this.剪切TToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.剪切TToolStripMenuItem.Name = "剪切TToolStripMenuItem";
            this.剪切TToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.剪切TToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.剪切TToolStripMenuItem.Text = "text.ts.edit.cut";
            // 
            // 复制CToolStripMenuItem
            // 
            this.复制CToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.复制CToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.复制CToolStripMenuItem.Image = global::IDE.Properties.Resources.Copy;
            this.复制CToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.复制CToolStripMenuItem.Name = "复制CToolStripMenuItem";
            this.复制CToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.复制CToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.复制CToolStripMenuItem.Text = "text.ts.edit.copy";
            // 
            // 粘贴PToolStripMenuItem
            // 
            this.粘贴PToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.粘贴PToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.粘贴PToolStripMenuItem.Image = global::IDE.Properties.Resources.d_Paste;
            this.粘贴PToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.粘贴PToolStripMenuItem.Name = "粘贴PToolStripMenuItem";
            this.粘贴PToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.粘贴PToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.粘贴PToolStripMenuItem.Text = "text.ts.edit.paste";
            // 
            // 运行ToolStripMenuItem
            // 
            this.运行ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.运行ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.运行ToolStripMenuItem.Image = global::IDE.Properties.Resources.Run1;
            this.运行ToolStripMenuItem.Name = "运行ToolStripMenuItem";
            this.运行ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.运行ToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.运行ToolStripMenuItem.Text = "text.ts.run.run";
            this.运行ToolStripMenuItem.Click += new System.EventHandler(this.Run);
            // 
            // 自定义CToolStripMenuItem
            // 
            this.自定义CToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.自定义CToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.自定义CToolStripMenuItem.Image = global::IDE.Properties.Resources.Settings;
            this.自定义CToolStripMenuItem.Name = "自定义CToolStripMenuItem";
            this.自定义CToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.自定义CToolStripMenuItem.Text = "text.ts.tool.custom";
            this.自定义CToolStripMenuItem.Click += new System.EventHandler(this.CustomSet);
            // 
            // 应用程序ToolStripMenuItem
            // 
            this.应用程序ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.应用程序ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem,
            this.重启ToolStripMenuItem});
            this.应用程序ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.应用程序ToolStripMenuItem.Image = global::IDE.Properties.Resources.IDE_ico_1024x_;
            this.应用程序ToolStripMenuItem.Name = "应用程序ToolStripMenuItem";
            this.应用程序ToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.应用程序ToolStripMenuItem.Text = "text.ts.tool.application";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.退出ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.退出ToolStripMenuItem.Image = global::IDE.Properties.Resources.logout;
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.退出ToolStripMenuItem.Text = "text.ts.tool.application.exit";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // 重启ToolStripMenuItem
            // 
            this.重启ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.重启ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.重启ToolStripMenuItem.Image = global::IDE.Properties.Resources.refresh;
            this.重启ToolStripMenuItem.Name = "重启ToolStripMenuItem";
            this.重启ToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.重启ToolStripMenuItem.Text = "text.ts.tool.application.restart";
            this.重启ToolStripMenuItem.Click += new System.EventHandler(this.Restart);
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.关于AToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.关于AToolStripMenuItem.Image = global::IDE.Properties.Resources.help2;
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(326, 26);
            this.关于AToolStripMenuItem.Text = "text.ts.help.about";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.AboutThis);
            // 
            // 鸣谢ToolStripMenuItem
            // 
            this.鸣谢ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.鸣谢ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.鸣谢ToolStripMenuItem.Image = global::IDE.Properties.Resources.Info_dark;
            this.鸣谢ToolStripMenuItem.Name = "鸣谢ToolStripMenuItem";
            this.鸣谢ToolStripMenuItem.Size = new System.Drawing.Size(326, 26);
            this.鸣谢ToolStripMenuItem.Text = "text.ts.help.thanks";
            this.鸣谢ToolStripMenuItem.Click += new System.EventHandler(this.Thanks);
            // 
            // 许可与版权声明ToolStripMenuItem
            // 
            this.许可与版权声明ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.许可与版权声明ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.许可与版权声明ToolStripMenuItem.Image = global::IDE.Properties.Resources._48x48_check;
            this.许可与版权声明ToolStripMenuItem.Name = "许可与版权声明ToolStripMenuItem";
            this.许可与版权声明ToolStripMenuItem.Size = new System.Drawing.Size(326, 26);
            this.许可与版权声明ToolStripMenuItem.Text = "text.ts.help.licenseandcopyright";
            this.许可与版权声明ToolStripMenuItem.Click += new System.EventHandler(this.copyrightsAndLicense);
            // 
            // 百宝箱ToolStripMenuItem
            // 
            this.百宝箱ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.百宝箱ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.百宝箱ToolStripMenuItem.Image = global::IDE.Properties.Resources.ender_pearl;
            this.百宝箱ToolStripMenuItem.Name = "百宝箱ToolStripMenuItem";
            this.百宝箱ToolStripMenuItem.Size = new System.Drawing.Size(326, 26);
            this.百宝箱ToolStripMenuItem.Text = "text.ts.help.treasurebox";
            this.百宝箱ToolStripMenuItem.Click += new System.EventHandler(this.OpenTheTBox);
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.配置ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.配置ToolStripMenuItem.Image = global::IDE.Properties.Resources.edit___副本;
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.配置ToolStripMenuItem.Text = "...配置";
            this.配置ToolStripMenuItem.Click += new System.EventHandler(this.CodeConfig);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1902, 973);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RYCB Py-CN Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitByClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ForceExit);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.FirstInit);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤消UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 剪切TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自定义CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选项OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Sunny.UI.UITabControl tabControl1;
        public System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭CtrlF4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        public System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.ToolStripMenuItem 鸣谢ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 许可与版权声明ToolStripMenuItem;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripMenuItem 重复RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全选AToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripMenuItem 项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.Timer SyntaxErrorChecker;
        private System.Windows.Forms.ToolStripMenuItem 开发者选项DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 崩溃测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成本地化示例文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行ToolStripMenuItem;
        private TabPage tabPage1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private ToolStripMenuItem 百宝箱ToolStripMenuItem;
        private ToolStripMenuItem 应用程序ToolStripMenuItem;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private ToolStripMenuItem 重启ToolStripMenuItem;
    }
}

