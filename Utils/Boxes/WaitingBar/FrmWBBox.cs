using System;
using Sunny.UI;

namespace IDE;
public partial class FrmWBBox : UIForm
{

    private int Value
    {
        get; set;
    }

    private bool isWaiting = true;
    private int max = 100;

    public FrmWBBox(int value, bool isWaiting = true, int max = 100)
    {
        InitializeComponent();
        Value = value;
        this.isWaiting = isWaiting;
        this.max = max;
        if (value > max) { Value = max; }
    }

    private void WBBox_Load(object sender, EventArgs e)
    {
        uiProcessBar1.Maximum = max;
        uiProcessBar1.Value = Value;
        if (isWaiting) { uiWaitingBar1.Show(); }
        else if (!isWaiting) { uiProcessBar1.Show(); }
        else { Close(); }
    }
}

