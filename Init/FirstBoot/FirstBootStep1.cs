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
public partial class FirstBootStep1 : UIForm
{
    private UIForm next;

    public FirstBootStep1()
    {
        InitializeComponent();
        next = new FirstBootStep2(this);
    }

    //UIForm IFirstBootWindow.previous => throw new NotImplementedException();

    //UIForm IFirstBootWindow.next => throw new NotImplementedException();

    private void Next(object sender, EventArgs e)
    {
        this.Hide();
        next.ShowDialog();
    }
}
