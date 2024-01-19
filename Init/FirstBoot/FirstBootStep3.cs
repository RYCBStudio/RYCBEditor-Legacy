using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Scripting.Utils;
using Sunny.UI;

namespace IDE.Init;
public partial class FirstBootStep3 : UIForm
{
    private UIForm previous, next;

    private void Previous(object sender, EventArgs e)
    {
        this.Hide();
        this.previous.Show();
    }

    private void Next(object sender, EventArgs e)
    {
        this.Hide();
        this.next.Show();
    }

    public FirstBootStep3(IEnumerable<UIForm> previousForms, UIForm previous)
    {
        InitializeComponent();
        this.previous = previous;
        this.next = new FirstBootStep4(new UIForm[] { this.previous, this }.Concat(previousForms));
    }
}
