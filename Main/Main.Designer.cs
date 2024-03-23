using System.Drawing;
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
            this.新建NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤消UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重复RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全选AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查找替换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置运行器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.应用程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.快速工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清理缓存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.鸣谢ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.许可与版权声明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.百宝箱ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.捐助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开发者选项DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.崩溃测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.autoSaveController = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭CtrlF4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackgroundWorker_GetFileType = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Blank = new System.Windows.Forms.ToolStripStatusLabel();
            this.MemoryChecker = new System.Windows.Forms.Timer(this.components);
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this.UpdateIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel11 = new System.Windows.Forms.ToolStripStatusLabel();
            this.CanUpdateIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel12 = new System.Windows.Forms.ToolStripStatusLabel();
            this.WorkingIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.CurrentWorkTip = new System.Windows.Forms.ToolStripStatusLabel();
            this.FileSavingIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.FileSavingTip = new System.Windows.Forms.ToolStripStatusLabel();
            this.SizeController = new System.Windows.Forms.Timer(this.components);
            this.SyntaxErrorChecker = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.webView1 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.ErrorAndExceptionsPage = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.appContainer1 = new SmileWei.EmbeddedApp.AppContainer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.HelpButton = new System.Windows.Forms.Button();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.Downloading = new System.Windows.Forms.ToolStripStatusLabel();
            this.ReceivedBytes = new System.Windows.Forms.ToolStripStatusLabel();
            this.ReceivedBytesSeparatorSign = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToReceiveBytes = new System.Windows.Forms.ToolStripStatusLabel();
            this.UpdateProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.DownloadProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.Percent = new System.Windows.Forms.ToolStripStatusLabel();
            this.DownloadSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView1)).BeginInit();
            this.uiTabControl1.SuspendLayout();
            this.ErrorAndExceptionsPage.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip3.SuspendLayout();
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
            this.开发者选项DToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 30);
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
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(95, 26);
            this.文件FToolStripMenuItem.Text = "text.ts.file";
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
            this.新建NToolStripMenuItem.Size = new System.Drawing.Size(388, 26);
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
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(388, 26);
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
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(388, 26);
            this.保存SToolStripMenuItem.Text = "text.ts.file.save";
            this.保存SToolStripMenuItem.Click += new System.EventHandler(this.QuietSave);
            // 
            // 另存为AToolStripMenuItem
            // 
            this.另存为AToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.另存为AToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.另存为AToolStripMenuItem.Name = "另存为AToolStripMenuItem";
            this.另存为AToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.另存为AToolStripMenuItem.Size = new System.Drawing.Size(388, 26);
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
            this.全选AToolStripMenuItem,
            this.查找替换ToolStripMenuItem});
            this.编辑EToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(102, 26);
            this.编辑EToolStripMenuItem.Text = "text.ts.edit";
            // 
            // 撤消UToolStripMenuItem
            // 
            this.撤消UToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.撤消UToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.撤消UToolStripMenuItem.Image = global::IDE.Properties.Resources.iconundo_2x;
            this.撤消UToolStripMenuItem.Name = "撤消UToolStripMenuItem";
            this.撤消UToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.撤消UToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.撤消UToolStripMenuItem.Text = "text.ts.edit.undo";
            // 
            // 重复RToolStripMenuItem
            // 
            this.重复RToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.重复RToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.重复RToolStripMenuItem.Image = global::IDE.Properties.Resources.iconredo_2x;
            this.重复RToolStripMenuItem.Name = "重复RToolStripMenuItem";
            this.重复RToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.重复RToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.重复RToolStripMenuItem.Text = "text.ts.edit.redo";
            // 
            // 剪切TToolStripMenuItem
            // 
            this.剪切TToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.剪切TToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.剪切TToolStripMenuItem.Image = global::IDE.Properties.Resources.edit_cut1;
            this.剪切TToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.剪切TToolStripMenuItem.Name = "剪切TToolStripMenuItem";
            this.剪切TToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.剪切TToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
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
            this.复制CToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
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
            this.粘贴PToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.粘贴PToolStripMenuItem.Text = "text.ts.edit.paste";
            // 
            // 全选AToolStripMenuItem
            // 
            this.全选AToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.全选AToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.全选AToolStripMenuItem.Image = global::IDE.Properties.Resources.select;
            this.全选AToolStripMenuItem.Name = "全选AToolStripMenuItem";
            this.全选AToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.全选AToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.全选AToolStripMenuItem.Text = "text.ts.edit.selectall";
            this.全选AToolStripMenuItem.Click += new System.EventHandler(this.SelectAll);
            // 
            // 查找替换ToolStripMenuItem
            // 
            this.查找替换ToolStripMenuItem.Name = "查找替换ToolStripMenuItem";
            this.查找替换ToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.查找替换ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.查找替换ToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.查找替换ToolStripMenuItem.Text = "查找/替换";
            this.查找替换ToolStripMenuItem.Visible = false;
            this.查找替换ToolStripMenuItem.Click += new System.EventHandler(this.Find);
            // 
            // 运行RToolStripMenuItem
            // 
            this.运行RToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.运行ToolStripMenuItem,
            this.配置运行器ToolStripMenuItem});
            this.运行RToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.运行RToolStripMenuItem.Name = "运行RToolStripMenuItem";
            this.运行RToolStripMenuItem.Size = new System.Drawing.Size(97, 26);
            this.运行RToolStripMenuItem.Text = "text.ts.run";
            // 
            // 运行ToolStripMenuItem
            // 
            this.运行ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.运行ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.运行ToolStripMenuItem.Image = global::IDE.Properties.Resources.Run1;
            this.运行ToolStripMenuItem.Name = "运行ToolStripMenuItem";
            this.运行ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.运行ToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.运行ToolStripMenuItem.Text = "text.ts.run.run";
            this.运行ToolStripMenuItem.Click += new System.EventHandler(this.Run);
            // 
            // 配置运行器ToolStripMenuItem
            // 
            this.配置运行器ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.配置运行器ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.配置运行器ToolStripMenuItem.Image = global::IDE.Properties.Resources.runnerconfig;
            this.配置运行器ToolStripMenuItem.Name = "配置运行器ToolStripMenuItem";
            this.配置运行器ToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.配置运行器ToolStripMenuItem.Text = "text.ts.run.configrunners";
            this.配置运行器ToolStripMenuItem.Click += new System.EventHandler(this.ConfigRunners);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自定义CToolStripMenuItem,
            this.选项OToolStripMenuItem,
            this.应用程序ToolStripMenuItem,
            this.快速工具ToolStripMenuItem});
            this.工具TToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(103, 26);
            this.工具TToolStripMenuItem.Text = "text.ts.tool";
            // 
            // 自定义CToolStripMenuItem
            // 
            this.自定义CToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.自定义CToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.自定义CToolStripMenuItem.Image = global::IDE.Properties.Resources.Settings;
            this.自定义CToolStripMenuItem.Name = "自定义CToolStripMenuItem";
            this.自定义CToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.自定义CToolStripMenuItem.Size = new System.Drawing.Size(317, 26);
            this.自定义CToolStripMenuItem.Text = "text.ts.tool.custom";
            this.自定义CToolStripMenuItem.Click += new System.EventHandler(this.CustomSet);
            // 
            // 选项OToolStripMenuItem
            // 
            this.选项OToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.选项OToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.选项OToolStripMenuItem.Name = "选项OToolStripMenuItem";
            this.选项OToolStripMenuItem.Size = new System.Drawing.Size(317, 26);
            this.选项OToolStripMenuItem.Text = "text.ts.tool.options";
            // 
            // 应用程序ToolStripMenuItem
            // 
            this.应用程序ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.应用程序ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem,
            this.重启ToolStripMenuItem});
            this.应用程序ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.应用程序ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("应用程序ToolStripMenuItem.Image")));
            this.应用程序ToolStripMenuItem.Name = "应用程序ToolStripMenuItem";
            this.应用程序ToolStripMenuItem.Size = new System.Drawing.Size(317, 26);
            this.应用程序ToolStripMenuItem.Text = "text.ts.tool.application";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.退出ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.退出ToolStripMenuItem.Image = global::IDE.Properties.Resources.logout;
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.End)));
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(361, 26);
            this.退出ToolStripMenuItem.Text = "text.ts.tool.application.exit";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // 重启ToolStripMenuItem
            // 
            this.重启ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.重启ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.重启ToolStripMenuItem.Image = global::IDE.Properties.Resources.refresh;
            this.重启ToolStripMenuItem.Name = "重启ToolStripMenuItem";
            this.重启ToolStripMenuItem.Size = new System.Drawing.Size(361, 26);
            this.重启ToolStripMenuItem.Text = "text.ts.tool.application.restart";
            this.重启ToolStripMenuItem.Click += new System.EventHandler(this.Restart);
            // 
            // 快速工具ToolStripMenuItem
            // 
            this.快速工具ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.快速工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清理缓存ToolStripMenuItem});
            this.快速工具ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.快速工具ToolStripMenuItem.Image = global::IDE.Properties.Resources.ToolKit;
            this.快速工具ToolStripMenuItem.Name = "快速工具ToolStripMenuItem";
            this.快速工具ToolStripMenuItem.Size = new System.Drawing.Size(317, 26);
            this.快速工具ToolStripMenuItem.Text = "text.ts.tool.quick";
            // 
            // 清理缓存ToolStripMenuItem
            // 
            this.清理缓存ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.清理缓存ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.清理缓存ToolStripMenuItem.Image = global::IDE.Properties.Resources.Dark_ClearCache;
            this.清理缓存ToolStripMenuItem.Name = "清理缓存ToolStripMenuItem";
            this.清理缓存ToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.清理缓存ToolStripMenuItem.Text = "text.ts.tool.quick.clearcache";
            this.清理缓存ToolStripMenuItem.Click += new System.EventHandler(this.ClearCache);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem,
            this.鸣谢ToolStripMenuItem,
            this.许可与版权声明ToolStripMenuItem,
            this.百宝箱ToolStripMenuItem,
            this.捐助ToolStripMenuItem});
            this.帮助HToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(105, 26);
            this.帮助HToolStripMenuItem.Text = "text.ts.help";
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
            // 捐助ToolStripMenuItem
            // 
            this.捐助ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.捐助ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.捐助ToolStripMenuItem.Image = global::IDE.Properties.Resources.donate;
            this.捐助ToolStripMenuItem.Name = "捐助ToolStripMenuItem";
            this.捐助ToolStripMenuItem.Size = new System.Drawing.Size(326, 26);
            this.捐助ToolStripMenuItem.Text = "text.ts.help.donate";
            this.捐助ToolStripMenuItem.Click += new System.EventHandler(this.DonateLink);
            // 
            // 开发者选项DToolStripMenuItem
            // 
            this.开发者选项DToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.崩溃测试ToolStripMenuItem});
            this.开发者选项DToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.开发者选项DToolStripMenuItem.Name = "开发者选项DToolStripMenuItem";
            this.开发者选项DToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.开发者选项DToolStripMenuItem.Text = "text.ts.devmode";
            this.开发者选项DToolStripMenuItem.Visible = false;
            // 
            // 崩溃测试ToolStripMenuItem
            // 
            this.崩溃测试ToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.崩溃测试ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.崩溃测试ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.崩溃测试ToolStripMenuItem.Name = "崩溃测试ToolStripMenuItem";
            this.崩溃测试ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.崩溃测试ToolStripMenuItem.Size = new System.Drawing.Size(421, 26);
            this.崩溃测试ToolStripMenuItem.Text = "text.ts.devmode.crashtest";
            this.崩溃测试ToolStripMenuItem.Click += new System.EventHandler(this.TestCrash);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "code";
            // 
            // autoSaveController
            // 
            this.autoSaveController.Enabled = true;
            this.autoSaveController.Interval = 1000;
            this.autoSaveController.Tick += new System.EventHandler(this.Save);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pycn";
            this.saveFileDialog1.FileName = "code";
            this.saveFileDialog1.Filter = "Py-CN文件|*.pycn|Py-CN编译后文件|*.py";
            this.saveFileDialog1.InitialDirectory = "C:\\Windows\\System32";
            this.saveFileDialog1.Title = "选择保存的文件:";
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
            // BackgroundWorker_GetFileType
            // 
            this.BackgroundWorker_GetFileType.Enabled = true;
            this.BackgroundWorker_GetFileType.Interval = 1000;
            this.BackgroundWorker_GetFileType.Tick += new System.EventHandler(this.GetFileType);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(166, 20);
            this.toolStripStatusLabel2.Text = "text.st.editprohibited";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Black;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel8,
            this.Blank});
            this.statusStrip1.Location = new System.Drawing.Point(0, 685);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1064, 26);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::IDE.Properties.Resources._48x48_Warn;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 20);
            this.toolStripStatusLabel1.Text = "    ";
            this.toolStripStatusLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(858, 20);
            this.toolStripStatusLabel8.Spring = true;
            // 
            // Blank
            // 
            this.Blank.Name = "Blank";
            this.Blank.Size = new System.Drawing.Size(0, 20);
            // 
            // MemoryChecker
            // 
            this.MemoryChecker.Enabled = true;
            this.MemoryChecker.Interval = 1100;
            this.MemoryChecker.Tick += new System.EventHandler(this.WriteDownMem);
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.Black;
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel10,
            this.UpdateIcon,
            this.toolStripStatusLabel11,
            this.CanUpdateIcon,
            this.toolStripStatusLabel9,
            this.toolStripStatusLabel12,
            this.WorkingIcon,
            this.CurrentWorkTip,
            this.FileSavingIcon,
            this.FileSavingTip});
            this.statusStrip2.Location = new System.Drawing.Point(0, 659);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1064, 26);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 4;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(96, 20);
            this.toolStripStatusLabel3.Text = "text.st.mem";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(97, 20);
            this.toolStripStatusLabel6.Text = "text.st.input";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel10
            // 
            this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
            this.toolStripStatusLabel10.Size = new System.Drawing.Size(427, 20);
            this.toolStripStatusLabel10.Spring = true;
            // 
            // UpdateIcon
            // 
            this.UpdateIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UpdateIcon.Image = global::IDE.Properties.Resources.Update_can_update;
            this.UpdateIcon.Name = "UpdateIcon";
            this.UpdateIcon.Size = new System.Drawing.Size(20, 20);
            // 
            // toolStripStatusLabel11
            // 
            this.toolStripStatusLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            this.toolStripStatusLabel11.Name = "toolStripStatusLabel11";
            this.toolStripStatusLabel11.Size = new System.Drawing.Size(17, 20);
            this.toolStripStatusLabel11.Text = " |";
            // 
            // CanUpdateIcon
            // 
            this.CanUpdateIcon.Image = global::IDE.Properties.Resources.select;
            this.CanUpdateIcon.Name = "CanUpdateIcon";
            this.CanUpdateIcon.Size = new System.Drawing.Size(20, 20);
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(231, 20);
            this.toolStripStatusLabel9.Text = "There are new updates for IDE.";
            // 
            // toolStripStatusLabel12
            // 
            this.toolStripStatusLabel12.IsLink = true;
            this.toolStripStatusLabel12.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.toolStripStatusLabel12.LinkColor = System.Drawing.Color.Turquoise;
            this.toolStripStatusLabel12.Name = "toolStripStatusLabel12";
            this.toolStripStatusLabel12.Size = new System.Drawing.Size(141, 20);
            this.toolStripStatusLabel12.Text = "Download Update";
            this.toolStripStatusLabel12.VisitedLinkColor = System.Drawing.Color.DarkOrchid;
            this.toolStripStatusLabel12.Click += new System.EventHandler(this.DownloadUpdate);
            this.toolStripStatusLabel12.DoubleClick += new System.EventHandler(this.DownloadUpdate);
            // 
            // WorkingIcon
            // 
            this.WorkingIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.WorkingIcon.Image = global::IDE.Properties.Resources.loading_;
            this.WorkingIcon.Name = "WorkingIcon";
            this.WorkingIcon.Size = new System.Drawing.Size(20, 20);
            this.WorkingIcon.Visible = false;
            // 
            // CurrentWorkTip
            // 
            this.CurrentWorkTip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CurrentWorkTip.Name = "CurrentWorkTip";
            this.CurrentWorkTip.Size = new System.Drawing.Size(137, 20);
            this.CurrentWorkTip.Text = "Show some work.";
            this.CurrentWorkTip.Visible = false;
            // 
            // FileSavingIcon
            // 
            this.FileSavingIcon.Image = global::IDE.Properties.Resources.file_ready_to_save_dark;
            this.FileSavingIcon.Name = "FileSavingIcon";
            this.FileSavingIcon.Size = new System.Drawing.Size(20, 20);
            this.FileSavingIcon.Visible = false;
            // 
            // FileSavingTip
            // 
            this.FileSavingTip.Name = "FileSavingTip";
            this.FileSavingTip.Size = new System.Drawing.Size(170, 20);
            this.FileSavingTip.Text = "text.st.filereadytosave";
            this.FileSavingTip.Visible = false;
            // 
            // SizeController
            // 
            this.SizeController.Interval = 1000;
            this.SizeController.Tick += new System.EventHandler(this.LayoutForConsole);
            // 
            // SyntaxErrorChecker
            // 
            this.SyntaxErrorChecker.Interval = 1000;
            this.SyntaxErrorChecker.Tick += new System.EventHandler(this.CheckSyntaxError);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiTabControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 61);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1064, 572);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.MainPage = "tabPage1";
            this.tabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowCloseButton = true;
            this.tabControl1.Size = new System.Drawing.Size(1058, 423);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.StyleCustomMode = true;
            this.tabControl1.TabBackColor = System.Drawing.Color.Black;
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.BeforeRemoveTabPage += new Sunny.UI.UITabControl.OnBeforeRemoveTabPage(this.TabControl1_BeforeRemoveTabPage);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.Layout);
            this.tabControl1.Validating += new System.ComponentModel.CancelEventHandler(this.Validating_Layout);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Controls.Add(this.webView1);
            this.tabPage1.Location = new System.Drawing.Point(0, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1058, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "text.tc.tp.tmp";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.elementHost1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1058, 393);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(3, 3);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1052, 387);
            this.elementHost1.TabIndex = 1;
            this.elementHost1.Validating += new System.ComponentModel.CancelEventHandler(this.LayoutTextEditor);
            this.elementHost1.Child = null;
            // 
            // webView1
            // 
            this.webView1.AllowExternalDrop = true;
            this.webView1.CreationProperties = null;
            this.webView1.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView1.Location = new System.Drawing.Point(11, 11);
            this.webView1.Name = "webView1";
            this.webView1.Size = new System.Drawing.Size(1044, 405);
            this.webView1.TabIndex = 1;
            this.webView1.ZoomFactor = 1D;
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.uiTabControl1.Controls.Add(this.ErrorAndExceptionsPage);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 25);
            this.uiTabControl1.Location = new System.Drawing.Point(3, 432);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(1058, 137);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTabControl1.StyleCustomMode = true;
            this.uiTabControl1.TabBackColor = System.Drawing.Color.Black;
            this.uiTabControl1.TabIndex = 4;
            this.uiTabControl1.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiTabControl1.TabSelectedHighColor = System.Drawing.Color.Gray;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // ErrorAndExceptionsPage
            // 
            this.ErrorAndExceptionsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ErrorAndExceptionsPage.Controls.Add(this.listView1);
            this.ErrorAndExceptionsPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.ErrorAndExceptionsPage.Location = new System.Drawing.Point(0, 0);
            this.ErrorAndExceptionsPage.Name = "ErrorAndExceptionsPage";
            this.ErrorAndExceptionsPage.Size = new System.Drawing.Size(1058, 112);
            this.ErrorAndExceptionsPage.TabIndex = 1;
            this.ErrorAndExceptionsPage.Text = "text.bottom.errors";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Black;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1058, 112);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.GotoLine);
            this.listView1.DoubleClick += new System.EventHandler(this.GetExceptionHelp);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "                 ";
            this.columnHeader5.Width = 127;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "text.bottom.errors.sub.type";
            this.columnHeader1.Width = 147;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "text.bottom.errors.sub.description";
            this.columnHeader2.Width = 473;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "text.bottom.errors.sub.line";
            this.columnHeader4.Width = 47;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "exception");
            this.imageList1.Images.SetKeyName(1, "warning");
            this.imageList1.Images.SetKeyName(2, "EII");
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tabPage2.Controls.Add(this.appContainer1);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(200, 60);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "text.bottom.console";
            // 
            // appContainer1
            // 
            this.appContainer1.AppFilename = "";
            this.appContainer1.AppProcess = null;
            this.appContainer1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.appContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appContainer1.Location = new System.Drawing.Point(0, 0);
            this.appContainer1.Name = "appContainer1";
            this.appContainer1.Size = new System.Drawing.Size(200, 60);
            this.appContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1058, 118);
            this.panel1.TabIndex = 0;
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HelpButton.BackgroundImage = global::IDE.Properties.Resources.help2;
            this.HelpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpButton.FlatAppearance.BorderSize = 0;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Location = new System.Drawing.Point(1023, 9);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(20, 20);
            this.HelpButton.TabIndex = 5;
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.help);
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
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Black;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1064, 31);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::IDE.Properties.Resources.Run;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.Run);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.BackgroundImage = global::IDE.Properties.Resources.Stop;
            this.toolStripButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.ForceStop);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::IDE.Properties.Resources.Debug_Color;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // statusStrip3
            // 
            this.statusStrip3.BackColor = System.Drawing.Color.Black;
            this.statusStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Downloading,
            this.ReceivedBytes,
            this.ReceivedBytesSeparatorSign,
            this.ToReceiveBytes,
            this.UpdateProgress,
            this.DownloadProgress,
            this.Percent,
            this.DownloadSpeed});
            this.statusStrip3.Location = new System.Drawing.Point(0, 633);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(1064, 26);
            this.statusStrip3.SizingGrip = false;
            this.statusStrip3.TabIndex = 1;
            // 
            // Downloading
            // 
            this.Downloading.Name = "Downloading";
            this.Downloading.Size = new System.Drawing.Size(168, 20);
            this.Downloading.Text = "Downloading Update:";
            // 
            // ReceivedBytes
            // 
            this.ReceivedBytes.Name = "ReceivedBytes";
            this.ReceivedBytes.Size = new System.Drawing.Size(0, 20);
            this.ReceivedBytes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReceivedBytesSeparatorSign
            // 
            this.ReceivedBytesSeparatorSign.Name = "ReceivedBytesSeparatorSign";
            this.ReceivedBytesSeparatorSign.Size = new System.Drawing.Size(15, 20);
            this.ReceivedBytesSeparatorSign.Text = "/";
            // 
            // ToReceiveBytes
            // 
            this.ToReceiveBytes.Name = "ToReceiveBytes";
            this.ToReceiveBytes.Size = new System.Drawing.Size(0, 20);
            // 
            // UpdateProgress
            // 
            this.UpdateProgress.MarqueeAnimationSpeed = 200;
            this.UpdateProgress.Name = "UpdateProgress";
            this.UpdateProgress.Size = new System.Drawing.Size(200, 18);
            this.UpdateProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // DownloadProgress
            // 
            this.DownloadProgress.Name = "DownloadProgress";
            this.DownloadProgress.Size = new System.Drawing.Size(0, 20);
            // 
            // Percent
            // 
            this.Percent.Name = "Percent";
            this.Percent.Size = new System.Drawing.Size(22, 20);
            this.Percent.Text = "%";
            // 
            // DownloadSpeed
            // 
            this.DownloadSpeed.Name = "DownloadSpeed";
            this.DownloadSpeed.Size = new System.Drawing.Size(0, 20);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1064, 711);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.statusStrip3);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.Text = "RYCB Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitByClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ForceExit);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.FirstInit);
            this.Resize += new System.EventHandler(this.ResizeControls);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView1)).EndInit();
            this.uiTabControl1.ResumeLayout(false);
            this.ErrorAndExceptionsPage.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal MenuStrip menuStrip1;
        internal ToolStripMenuItem 文件FToolStripMenuItem;
        internal ToolStripMenuItem 新建NToolStripMenuItem;
        internal ToolStripMenuItem 打开OToolStripMenuItem;
        internal ToolStripMenuItem 保存SToolStripMenuItem;
        internal ToolStripMenuItem 另存为AToolStripMenuItem;
        internal ToolStripMenuItem 编辑EToolStripMenuItem;
        internal ToolStripMenuItem 撤消UToolStripMenuItem;
        internal ToolStripMenuItem 剪切TToolStripMenuItem;
        internal ToolStripMenuItem 复制CToolStripMenuItem;
        internal ToolStripMenuItem 粘贴PToolStripMenuItem;
        internal ToolStripMenuItem 工具TToolStripMenuItem;
        internal ToolStripMenuItem 自定义CToolStripMenuItem;
        internal ToolStripMenuItem 选项OToolStripMenuItem;
        internal ToolStripMenuItem 帮助HToolStripMenuItem;
        internal ToolStripMenuItem 关于AToolStripMenuItem;
        internal OpenFileDialog openFileDialog1;
        internal Timer autoSaveController;
        internal SaveFileDialog saveFileDialog1;
        internal Timer BackgroundWorker_GetFileType;
        internal ContextMenuStrip contextMenuStrip1;
        internal ToolStripMenuItem 刷新RToolStripMenuItem;
        internal ToolStripMenuItem 关闭CtrlF4ToolStripMenuItem;
        internal ToolStripStatusLabel toolStripStatusLabel2;
        internal StatusStrip statusStrip1;
        internal Timer MemoryChecker;
        internal StatusStrip statusStrip2;
        internal ToolStripStatusLabel toolStripStatusLabel3;
        internal Button HelpButton;
        internal ToolStripMenuItem 配置ToolStripMenuItem;
        internal ToolStripMenuItem 鸣谢ToolStripMenuItem;
        internal ToolStripMenuItem 许可与版权声明ToolStripMenuItem;
        internal Timer SizeController;
        internal ToolStripStatusLabel toolStripStatusLabel1;
        internal ToolStripStatusLabel toolStripStatusLabel4;
        internal ToolStripStatusLabel toolStripStatusLabel5;
        internal ToolStripMenuItem 重复RToolStripMenuItem;
        internal ToolStripMenuItem 全选AToolStripMenuItem;
        internal ToolStripStatusLabel toolStripStatusLabel6;
        internal ToolStripStatusLabel toolStripStatusLabel7;
        internal ToolStripMenuItem 项目ToolStripMenuItem;
        internal ToolStripMenuItem 文件ToolStripMenuItem;
        internal Timer SyntaxErrorChecker;
        internal ToolStripMenuItem 开发者选项DToolStripMenuItem;
        internal ToolStripMenuItem 崩溃测试ToolStripMenuItem;
        internal ToolStripMenuItem 运行RToolStripMenuItem;
        internal ToolStripMenuItem 运行ToolStripMenuItem;
        internal ToolStripMenuItem 百宝箱ToolStripMenuItem;
        internal ToolStripMenuItem 应用程序ToolStripMenuItem;
        internal ToolStripMenuItem 退出ToolStripMenuItem;
        internal ToolStripMenuItem 重启ToolStripMenuItem;
        internal ToolStripMenuItem 捐助ToolStripMenuItem;
        internal TableLayoutPanel tableLayoutPanel1;
        internal Sunny.UI.UITabControl tabControl1;
        internal TabPage tabPage1;
        internal TableLayoutPanel tableLayoutPanel2;
        internal System.Windows.Forms.Integration.ElementHost elementHost1;
        internal ToolStripMenuItem 查找替换ToolStripMenuItem;
        internal ToolStripStatusLabel FileSavingIcon;
        internal ToolStripStatusLabel FileSavingTip;
        internal ToolStripMenuItem 快速工具ToolStripMenuItem;
        internal ToolStripMenuItem 清理缓存ToolStripMenuItem;
        internal Sunny.UI.UITabControl uiTabControl1;
        internal TabPage ErrorAndExceptionsPage;
        internal ListView listView1;
        internal ColumnHeader columnHeader1;
        internal ColumnHeader columnHeader2;
        internal ColumnHeader columnHeader4;
        internal ColumnHeader columnHeader5;
        internal ImageList imageList1;
        internal TabPage tabPage2;
        internal Panel panel1;
        internal SmileWei.EmbeddedApp.AppContainer appContainer1;
        internal Microsoft.Web.WebView2.WinForms.WebView2 webView1;
        internal ToolStrip toolStrip1;
        internal ToolStripButton toolStripButton1;
        internal ToolStripButton toolStripButton2;
        internal ToolStripButton toolStripButton3;
        internal ToolStripSeparator toolStripSeparator1;
        internal ToolStripStatusLabel WorkingIcon;
        internal ToolStripStatusLabel CurrentWorkTip;
        internal ToolStripMenuItem 配置运行器ToolStripMenuItem;
        internal ToolStripStatusLabel toolStripStatusLabel8;
        internal ToolStripStatusLabel Blank;
        internal ToolStripStatusLabel UpdateIcon;
        internal ToolStripStatusLabel toolStripStatusLabel11;
        internal ToolStripStatusLabel CanUpdateIcon;
        internal ToolStripStatusLabel toolStripStatusLabel10;
        internal ToolStripStatusLabel toolStripStatusLabel12;
        internal StatusStrip statusStrip3;
        internal ToolStripStatusLabel ReceivedBytes;
        internal ToolStripStatusLabel ReceivedBytesSeparatorSign;
        internal ToolStripStatusLabel ToReceiveBytes;
        internal ToolStripProgressBar UpdateProgress;
        internal ToolStripStatusLabel DownloadProgress;
        internal ToolStripStatusLabel Percent;
        internal ToolStripStatusLabel Downloading;
        internal ToolStripStatusLabel DownloadSpeed;
        internal ToolStripStatusLabel toolStripStatusLabel9;
    }
}

