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
public partial class MsgBox : UIForm
{
    public MsgBox()
    {
        InitializeComponent();
    }

    public enum MsgType
    {
        Normal,
        Warning,
        Error,
        Fatal,
    }
}
