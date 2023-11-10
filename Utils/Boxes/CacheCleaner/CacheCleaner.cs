<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
public partial class CacheCleaner : UIForm
{
    private struct ClearChoices
    {
        internal static bool LogFile = false;
        internal static bool PyCNFile = false;
        internal static bool TmpFile = false;
    }

    public CacheCleaner()
    {
        InitializeComponent();
        InitializeTranslation();
    }

    private void ChangeState_Log(object sender, EventArgs e)
    {
        ClearChoices.LogFile = ((UICheckBox)sender).Checked;
        GetFiles();
    }

    private void ChangeState_PyCN(object sender, EventArgs e)
    {
        ClearChoices.PyCNFile = ((UICheckBox)sender).Checked;
        GetFiles();
    }

    private void ChangeState_Tmp(object sender, EventArgs e)
    {
        ClearChoices.TmpFile = ((UICheckBox)sender).Checked;
        GetFiles();
    }

    private void GetFiles()
    {
        var total = 0;
        if (ClearChoices.LogFile)
        {
            total += System.IO.Directory.EnumerateFiles(Program.STARTUP_PATH + "\\logs").Count();
        }
        if (ClearChoices.PyCNFile)
        {
            //total += System.IO.Directory.EnumerateFiles(Program.STARTUP_PATH + "\\logs").Count();
        }
        if (ClearChoices.TmpFile)
        {
            total += System.IO.Directory.EnumerateFiles(Program.STARTUP_PATH + "\\$tmp_code").Count();
        }
        uiProcessBar1.Maximum = total;
    }

    private void Disable(object sender, EventArgs e)
    {
        if (!(ClearChoices.TmpFile && ClearChoices.PyCNFile && ClearChoices.LogFile)) { return; }
        BtnOk.Disabled();
        BtnCancel.Disabled(); 
        if (ClearChoices.TmpFile)
        {
            foreach (var file in System.IO.Directory.EnumerateFiles(Program.STARTUP_PATH + "\\$tmp_code"))
            {
                File.Delete(file);
                uiProcessBar1.StepIt();
            }
        }
        if (ClearChoices.LogFile)
        {
            var files = System.IO.Directory.EnumerateFiles(Program.STARTUP_PATH + "\\logs");
            foreach (var file in files)
            {
                if (isCurrentLogFile(file))
                    continue;
                File.Delete(file);
                uiProcessBar1.StepIt();
            }
        }
    }

    private bool isCurrentLogFile(string file)
    {
        if (Main.LOGGER.logPath.Contains(file))
        {
            return true;
        }
        return false;
    }

    private void IsOver(object sender, int value)
    {
        if (((UIProcessBar)sender).Value == ((UIProcessBar)sender).Maximum)
        {
            BtnOk.Enabled = true;
            BtnCancel.Enabled = true;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
public partial class CacheCleaner : UIForm
{
    private struct ClearChoices
    {
        internal static bool LogFile = false;
        internal static bool PyCNFile = false;
        internal static bool TmpFile = false;
    }

    public CacheCleaner()
    {
        InitializeComponent();
        InitializeTranslation();
    }

    private void ChangeState_Log(object sender, EventArgs e)
    {
        ClearChoices.LogFile = ((UICheckBox)sender).Checked;
        GetFiles();
    }

    private void ChangeState_PyCN(object sender, EventArgs e)
    {
        ClearChoices.PyCNFile = ((UICheckBox)sender).Checked;
        GetFiles();
    }

    private void ChangeState_Tmp(object sender, EventArgs e)
    {
        ClearChoices.TmpFile = ((UICheckBox)sender).Checked;
        GetFiles();
    }

    private void GetFiles()
    {
        var total = 0;
        if (ClearChoices.LogFile)
        {
            total += System.IO.Directory.EnumerateFiles(Program.STARTUP_PATH + "\\logs").Count();
        }
        if (ClearChoices.PyCNFile)
        {
            //total += System.IO.Directory.EnumerateFiles(Program.STARTUP_PATH + "\\logs").Count();
        }
        if (ClearChoices.TmpFile)
        {
            total += System.IO.Directory.EnumerateFiles(Program.STARTUP_PATH + "\\$tmp_code").Count();
        }
        uiProcessBar1.Maximum = total;
    }

    private void Disable(object sender, EventArgs e)
    {
        if (!(ClearChoices.TmpFile && ClearChoices.PyCNFile && ClearChoices.LogFile)) { return; }
        BtnOk.Disabled();
        BtnCancel.Disabled(); 
        if (ClearChoices.TmpFile)
        {
            foreach (var file in System.IO.Directory.EnumerateFiles(Program.STARTUP_PATH + "\\$tmp_code"))
            {
                File.Delete(file);
                uiProcessBar1.StepIt();
            }
        }
        if (ClearChoices.LogFile)
        {
            var files = System.IO.Directory.EnumerateFiles(Program.STARTUP_PATH + "\\logs");
            foreach (var file in files)
            {
                if (isCurrentLogFile(file))
                    continue;
                File.Delete(file);
                uiProcessBar1.StepIt();
            }
        }
    }

    private bool isCurrentLogFile(string file)
    {
        if (Main.LOGGER.logPath.Contains(file))
        {
            return true;
        }
        return false;
    }

    private void IsOver(object sender, int value)
    {
        if (((UIProcessBar)sender).Value == ((UIProcessBar)sender).Maximum)
        {
            BtnOk.Enabled = true;
            BtnCancel.Enabled = true;
        }
    }
}
>>>>>>> Stashed changes
