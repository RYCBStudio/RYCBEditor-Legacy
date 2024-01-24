using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        i = 4;
        previousForms = previous;
    }

    private void FirstBootStep4_Shown(object sender, EventArgs e)
    {
        timer1.Start();
    }

    private void CountDown(object sender, EventArgs e)
    {
        uiLabel2.Text = i.ToString();
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
