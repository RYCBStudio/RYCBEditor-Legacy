using System;
using System.Drawing;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Editing;
using Sunny.UI;

namespace IDE;
public partial class RYCBSearchPanel :  UIForm
{
    private static readonly string up = "⋀";
    private static readonly string down = "⋁";
    private static readonly Size onlyFind = new(418, 56);
    private static readonly Size FindAndReplace = new(418, 150);
    private static bool isInCase = false;
    private static bool isInRegex = false;
    private static bool isInFullWords = false;
    private TextArea _textArea;
    private TextEditor _textEditor;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="textEditor">编辑器控件</param>
    public RYCBSearchPanel(TextEditor textEditor)
    {
        InitializeComponent();
        this.Size = onlyFind;
        _textEditor = textEditor;
        _textArea = textEditor.TextArea;
    }

    private void Switch(object sender, EventArgs e)
    {
        this.Size = FindAndReplace;
        ((UIButton)sender).Hide();
    }

    private void FindInCase(object sender, EventArgs e)
    {
        isInCase = !isInCase;
        CBoxCase.Checked = isInCase;
    }

    private void FindInRegex(object sender, EventArgs e)
    {
        isInRegex = !isInRegex;
        CBoxRegex.Checked = isInRegex;
    }

    private void FindInFullWords(object sender, EventArgs e)
    {
        isInFullWords = !isInFullWords;
        CBoxFull.Checked = isInFullWords;
    }

    private void Clear(object sender, EventArgs e)
    {
        uiTextBox1.Text = "";
    }

    private void Yes(object sender, EventArgs e)
    {

    }

    private void Cancel(object sender, EventArgs e)
    {
        this.Close();
    }

    private void Find(object sender, EventArgs e)
    {
        
    }
}
