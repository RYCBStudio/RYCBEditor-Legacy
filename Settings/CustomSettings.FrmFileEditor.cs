using System;
using System.IO;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Highlighting;
using Sunny.UI;
using System.Xml;
using System.Runtime.InteropServices;
using System.Text;

namespace IDE;
public partial class CustomSettingsFileEditor : UIForm
{
    private TextEditor _editor;
    private struct Editor
    {
        public static System.Windows.Media.Color Fore;
        public static System.Windows.Media.Color Back;
    }

    public CustomSettingsFileEditor()
    {
        InitializeComponent();
        Editor.Fore = GlobalSettings.editor_color_set["Light"][0];
        Editor.Back = GlobalSettings.editor_color_set["Light"][1];
        _editor = new TextEditor()
        {
            Width = elementHost1.Width,
            Height = elementHost1.Height,
            FontFamily = new System.Windows.Media.FontFamily(Program.reConf.ReadString("Editor", "Font", "Consolas")),
            Background = new System.Windows.Media.SolidColorBrush(Editor.Back),
            Foreground = new System.Windows.Media.SolidColorBrush(Editor.Fore),
            FontSize = Program.reConf.ReadInt("Editor", "Size", 12),
            ShowLineNumbers = bool.Parse(Program.reConf.ReadString("Editor", "ShowLineNum", "true")),
            HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
            VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
        };
        toolStripStatusLabel4.Text = Program.reConf.FileName;
    }

    private void CustomSettingsFileEditor_Load(object sender, EventArgs e)
    {
        _editor.TextArea.TextEntered += TextArea_TextEntered;
        elementHost1.Child = _editor;
        _editor.Load(Program.reConf.FileName);
        using (Stream s = new FileStream(FrmMain.XshdFilePath + "\\Ini.xshd", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
        {
            using XmlTextReader reader = new(s);
            var xshd = HighlightingLoader.LoadXshd(reader);
            _editor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
        }
    }

    private void TextArea_TextEntered(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        FileSavingIcon.Image = Properties.Resources.file_ready_to_save_dark;
        FileSavingTip.Text = FrmMain.I18nFile.ReadString("I18n", "text.st.filereadytosave", "text.st.filereadytosave");
        FileSavingIcon.Visible = false;
        FileSavingTip.Visible = false;
        try
        {
            StreamWriter streamWriter = new(Program.reConf.FileName, false, Encoding.UTF8);
            streamWriter.Write(_editor.Text);
            streamWriter.Close();
            FileSavingIcon.Image = Properties.Resources.file_saved_dark;
            FileSavingTip.Text = FrmMain.I18nFile.Localize("text.st.filesaved");
        }
        catch (Exception ex)
        {
            FileSavingIcon.Image = Properties.Resources.file_save_failed_dark;
            FileSavingTip.Text = FrmMain.I18nFile.Localize("text.st.filesavefailed");
            FrmMain.LOGGER.Err(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
        }
        FileSavingIcon.Visible = true;
        FileSavingTip.Visible = true;
    }

    private void Close(object sender, EventArgs e)
    {
        this.Close();
    }

    private void statusStrip1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        //为当前应用程序释放鼠标捕获
        ReleaseCapture();
        //发送消息 让系统误以为在标题栏上按下鼠标
        SendMessage((IntPtr)this.Handle, VM_NCLBUTTONDOWN, HTCAPTION, 0);
    }

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    [DllImport("user32.dll")]
    public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

    private const int VM_NCLBUTTONDOWN = 0XA1;//定义鼠标左键按下
    private const int HTCAPTION = 2;
}
