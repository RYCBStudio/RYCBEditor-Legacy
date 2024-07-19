using System;
using Sunny.UI;

namespace IDE.Init;
public partial class FrmFirstBootStep1 : UIForm
{
    private UIForm next;

    public FrmFirstBootStep1()
    {
        InitializeComponent();
        InitializeLocalization();
        next = new FrmFirstBootStep2(this);
    }

    //UIForm IFirstBootWindow.previous => throw new NotImplementedException();

    //UIForm IFirstBootWindow.next => throw new NotImplementedException();

    private void Next(object sender, EventArgs e)
    {
        this.Hide();
        next.ShowDialog();
    }
}
