using System;
using System.Collections.Generic;
using System.Linq;
using Sunny.UI;

namespace IDE.Init;
public partial class FrmFirstBootStep3 : UIForm
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
        this.next.ShowDialog();
    }

    public FrmFirstBootStep3(IEnumerable<UIForm> previousForms, UIForm previous)
    {
        InitializeComponent();
        InitializeLocalization();
        this.previous = previous;
        this.next = new FrmFirstBootStep4(new UIForm[] { this.previous, this }.Concat(previousForms));
    }
}
