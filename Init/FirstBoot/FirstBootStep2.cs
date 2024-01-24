using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE.Init;
public partial class FirstBootStep2 : UIForm
{
    private UIForm previous, next;
    public FirstBootStep2(UIForm previous)
    {
        InitializeComponent();
        this.TopMost = true;
        this.previous = previous;
        this.next = new FirstBootStep3(new List<UIForm>{ this.previous},this);
        this.TopMost = false;
    }

    private void Next(object sender, EventArgs e)
    {
        this.Hide();
        next.ShowDialog();
    }

    private void Previous(object sender, EventArgs e)
    {
        this.Hide();
        previous.ShowDialog();
    }

    private void ChangeMainFont(object sender, EventArgs e)
    {
        fontDialog1.Font = uiButton3.Font;
        if (fontDialog1.ShowDialog() == DialogResult.OK)
        {
            textBox1.Font = fontDialog1.Font;
            uiButton3.Font = fontDialog1.Font;
            uiButton3.Text = fontDialog1.Font.Name;
            Program.reConf.Write("Display", "DisplayFont", fontDialog1.Font.Name);
        }
    }

    private void ChangeEditorText(object sender, EventArgs e)
    {
        fontDialog1.Font = uiButton4.Font;
        if (fontDialog1.ShowDialog() == DialogResult.OK)
        {
            textBox2.Font = fontDialog1.Font;
            uiButton4.Font = fontDialog1.Font;
            uiButton4.Text = fontDialog1.Font.Name;
            uiIntegerUpDown2.Value = (int)fontDialog1.Font.Size; 
            Program.reConf.Write("Editor", "Font", fontDialog1.Font.Name);
            Program.reConf.Write("Editor", "Size", uiIntegerUpDown2.Value);
        }
    }

    private void UpdateEditorFont(object sender, int value)
    {
        textBox2.Font = new(textBox1.Font.Name, uiIntegerUpDown2.Value); 
        Program.reConf.Write("Editor", "Size", uiIntegerUpDown2.Value);
    }
}
