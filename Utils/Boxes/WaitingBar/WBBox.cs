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

namespace IDE;
public partial class WBBox : UIForm
{

    private int Value
    {
        get; set;
    }

    private bool isWaiting = true;
    private int max = 100;

    public WBBox(int value, bool isWaiting = true, int max = 100)
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
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
public partial class WBBox : UIForm
{

    private int Value
    {
        get; set;
    }

    private bool isWaiting = true;
    private int max = 100;

    public WBBox(int value, bool isWaiting = true, int max = 100)
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
>>>>>>> Stashed changes
