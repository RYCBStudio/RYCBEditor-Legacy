using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE.Init;
public partial class FirstBootStep4 : UIForm
{
    private int i = 4;
    private IEnumerable<UIForm> previousForms;
    public FirstBootStep4(IEnumerable<UIForm> previous)
    {
        InitializeComponent();
        InitializeLocalization();
        i = 4;
        previousForms = previous;
    }

    private void FirstBootStep4_Shown(object sender, EventArgs e)
    {
        uiLabel3.Text = string.Format(uiLabel3.Text, (i + 1).ToString());
        timer1.Start();
    }

    private void CountDown(object sender, EventArgs e)
    {
        if (i == 0)
        {
            foreach (var item in previousForms)
            {
                item.Close();
            }
            this.Close();
        }
        i--;
    }

    private void FirstBootStep4_FormClosing(object sender, FormClosingEventArgs e)
    {
        Program.reConf.Write("FirstBoot", "IsFirstBoot", false);
    }
}
