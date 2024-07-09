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

namespace IDE.Utils.Boxes.PackageManager;
public partial class PackageManagerProgressWindow : UIForm
{

    public int value, total;
    public bool shouldAuto;
    public string tip;

    private void uiProcessBar1_ValueChanged(object sender, int value)
    {
        if (value == uiProcessBar1.Maximum)
        {
            uiProcessBar1.Value = 0;
            this.Close();
        }
    }

    public PackageManagerProgressWindow(int value = 0, int total = 100, bool shouldAuto = true, string tip = "正在处理，请稍候")
    {
        InitializeComponent();
        this.value = value;
        this.total = total;
        this.shouldAuto = shouldAuto;
        this.tip = tip;
        uiProcessBar1.Value = value;
        uiProcessBar1.Maximum = total;
        label1.Text = tip;
    }

    private void label1_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    public void Update(int value, int total, bool shouldAuto = true, string tip = "正在处理，请稍候")
    {
        uiProcessBar1.Value = value;
        uiProcessBar1.Maximum = total;
        label1.Text = tip;
    }
}
