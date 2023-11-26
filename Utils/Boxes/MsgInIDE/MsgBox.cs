using System;
using System.Threading.Tasks;
using Markdig;
using Microsoft.Web.WebView2.Core;
using Sunny.UI;

namespace IDE;
public partial class MsgBox : UIForm
{

    private MsgType CurrentMsgType { get; set; }
    public string MarkdownText { get; set; }
    private string htmlText;
    private bool webView2Initialized;

    public MsgBox(MsgType type, string markdownText)
    {
        InitializeComponent();
        CurrentMsgType = type;
        MarkdownText = markdownText;
    }

    public enum MsgType
    {
        Normal,
        Warning,
        Error,
        Fatal,
    }

    

    private void PreInit(object sender, EventArgs e)
    {
        if (!MarkdownText.IsNullOrEmpty())
        {
            switch (CurrentMsgType)
            {
                case MsgType.Normal:
                    this.Style = UIStyle.Green;
                    break;
                case MsgType.Warning:
                    this.Style = UIStyle.LayuiGreen;
                    break;
                case MsgType.Error:
                    this.Style = UIStyle.LayuiRed;
                    break;
                case MsgType.Fatal:
                    this.Style = UIStyle.Red;
                    break;
            }
        }
    }

    private bool GetHtmlText()
    {
        try
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            htmlText = Markdown.ToHtml(MarkdownText, pipeline);
            return true;
        }
        catch { return false; }
    }

    private void PostInit(object sender, EventArgs e)
    {
        
    }

    private void MsgBox_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
        e.Cancel = true;
        this.Hide();
    }

    private void Next(object sender, CoreWebView2InitializationCompletedEventArgs e)
    {
        webView2Initialized = true;
    }
}
