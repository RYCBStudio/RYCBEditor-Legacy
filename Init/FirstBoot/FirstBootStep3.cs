using System;
using System.Collections.Generic;
using System.Linq;
using Sunny.UI;

namespace IDE.Init;
public partial class FirstBootStep3 : UIForm
{
    private UIForm previous, next;

    private void Previous(object sender, EventArgs e)
    {
        this.Hide();
        this.previous.ShowDialog();
    }

    private void Next(object sender, EventArgs e)
    {
        this.Hide();
        this.next.ShowDialog();
    }

    public FirstBootStep3(IEnumerable<UIForm> previousForms, UIForm previous)
    {
        InitializeComponent();
        this.previous = previous;
        this.next = new FirstBootStep4(new UIForm[] { this.previous, this }.Concat(previousForms));
    }
}
