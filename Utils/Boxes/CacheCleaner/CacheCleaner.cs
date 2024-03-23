using System;
using System.IO;
using System.Linq;
using Sunny.UI;

namespace IDE;
public partial class CacheCleaner : UIForm
{

    private bool ClearStatus = false;

    private struct ClearChoices
    {
        internal static bool LogFile = false;
        internal static bool TmpFile = false;
        internal static bool UpdateArchive = false;
        internal static bool UpdateFile = false;
    }

    public CacheCleaner()
    {
        InitializeComponent();
        InitializeTranslation();
    }

    private void ChangeState_Log(object sender, EventArgs e)
    {
        ClearChoices.LogFile = ((UICheckBox)sender).Checked;
    }

    private void ChangeState_PyCN(object sender, EventArgs e)
    {
        //ClearChoices.PyCNFile = ((UICheckBox)sender).Checked;
        //GetFiles();
    }

    private void ChangeState_Tmp(object sender, EventArgs e)
    {
        ClearChoices.TmpFile = ((UICheckBox)sender).Checked;
    }

    private void GetFiles()
    {
        var total = 0;
        if (ClearChoices.LogFile)
        {
            total += System.IO.Directory.EnumerateFiles(Program.STARTUP_PATH + "\\logs").Count();
        }
        //if (ClearChoices.PyCNFile)
        //{
        //    //total += System.IO.Directory.EnumerateFiles(Program.STARTUP_PATH + "\\logs").Count();
        //}
        if (ClearChoices.TmpFile)
        {
            total += System.IO.Directory.EnumerateFiles(Program.STARTUP_PATH + "\\$tmp_code").Count();
        }
        if (ClearChoices.UpdateFile)
        {
            total += System.IO.Directory.EnumerateFiles(Utils.Update.GlobalDefinitions.DecompressedUpdateArchive_Path).Count();
        }
        if (ClearChoices.UpdateArchive)
        {
            total += 1;
        }
        uiProcessBar1.Maximum = total;
    }

    private void Disable(object sender, EventArgs e)
    {
        if (ClearChoices.TmpFile && ClearChoices.UpdateArchive && ClearChoices.LogFile && ClearChoices.UpdateFile) { return; }
        ClearStatus = true;
        BtnOk.Disabled();
        BtnCancel.Disabled();
        GetFiles();
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
                {
                    continue;
                }
                File.Delete(file);
                uiProcessBar1.StepIt();
            }
        }
        if (ClearChoices.UpdateFile)
        {
            var files = System.IO.Directory.EnumerateFiles(Utils.Update.GlobalDefinitions.DecompressedUpdateArchive_Path);
            foreach (var file in files)
            {
                File.Delete(file);
                uiProcessBar1.StepIt();
            }
        }
        if (ClearChoices.UpdateArchive)
        {
            File.Delete(Utils.Update.GlobalDefinitions.UpdateArchive_Path);
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

    private void Cancel(object sender, EventArgs e)
    {
        this.Close();
    }

    private void ChangeState_UA(object sender, EventArgs e)
    {
        ClearChoices.UpdateArchive = ((UICheckBox)sender).Checked;
    }

    private void ChangeState_UR(object sender, EventArgs e)
    {
        ClearChoices.UpdateFile = ((UICheckBox)sender).Checked;
    }
}
