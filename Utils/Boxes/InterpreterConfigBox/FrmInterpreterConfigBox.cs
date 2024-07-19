using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using Sunny.UI;

namespace IDE;
public partial class FrmInterpreterConfigBox : UIForm
{
    private string path;

    public FrmInterpreterConfigBox(string path)
    {
        InitializeComponent();
        InitializeLocalization();
        this.path = path;
    }

    private void InterpreterConfigBox_Load(object sender, EventArgs e)
    {
        uiListBox1.Tag = new List<Dictionary<int, string>>() { };
        foreach (var item in Directory.EnumerateFiles(path))
        {
            ICBFileProcessor iCBFileProcessor = new(item);
            var name = iCBFileProcessor.GetInfo(ICBFileProcessor.InfoType.Itptr_name);
            int index = uiListBox1.Items.Add(name);
            ((List<Dictionary<int, string>>)uiListBox1.Tag).Add(new Dictionary<int, string> { { index, item } });
            iCBFileProcessor = null;
        }
    }

    /*
     * (Recommend)Built-in Python Program Runner
     * Local Python 3
     * Virtual Python Environment
    */

    private void AddNewConfig(object sender, EventArgs e)
    {
        var filename = "New.icbconfig";
        if (!UIInputDialog.InputStringDialog(this, ref filename, true, _I18nFile.Localize("text.icb.filename.enter"), true))
        {
            return;
        }
        var filepath = Program.STARTUP_PATH + "\\Config\\Runners\\" + (filename.EndsWith(".icbconfig") ? filename : filename + ".icbconfig");
        File.Create(filepath).Dispose();
        var name = Path.GetFileNameWithoutExtension(filename);
        if (!UIInputDialog.InputStringDialog(this, ref name, true, _I18nFile.Localize("text.icb.name.enter"), true))
        {
            //text.tip.nullvalue = 您未输入值，RYCB Editor会自动分配该值。
            MessageBox.Show(_I18nFile.Localize("text.tip.nullvalue"), "", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        File.WriteAllText(filepath, $"[itptr]\r\nname={name}\r\ntype=\r\npath=\r\nargs=");
        int index = uiListBox1.Items.Add(name);
        ((List<Dictionary<int, string>>)uiListBox1.Tag).Add(new Dictionary<int, string> { { index, filepath } });

    }

    private void DeleteConfig(object sender, EventArgs e)
    {
        if (uiListBox1.SelectedIndex != -1)
        {
            string path = (uiListBox1.Tag as List<Dictionary<int, string>>)[uiListBox1.SelectedIndex][uiListBox1.SelectedIndex];
            try
            {
                File.Delete(path);
                uiListBox1.Delete(uiListBox1.SelectedItem);
                uiListBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                FrmMain.LOGGER.Err(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                label6.Show();
                pictureBox1.Show();
            }
        }
    }

    private void SearchForExistingConfig(object sender, EventArgs e)
    {
        openFileDialog1.Filter = "|*.icbconfig||*.*";
        if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            var filedirectorypath = Program.STARTUP_PATH + "\\Config\\Runners\\";
            var filename = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
            var destfilename = filedirectorypath + filename + ".icbconfig";
            try
            {
                File.Copy(openFileDialog1.FileName, destfilename, true);
                var icbfp = new ICBFileProcessor(destfilename);
                var name = icbfp.GetInfo(ICBFileProcessor.InfoType.Itptr_name);
                if (name.IsNullOrEmpty())
                {
                    return;
                }
                int index = uiListBox1.Items.Add(name);
                ((List<Dictionary<int, string>>)uiListBox1.Tag).Add(new Dictionary<int, string> { { index, destfilename } });
            }
            catch (Exception ex)
            {
                FrmMain.LOGGER.Err(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
            }
        }
    }

    private void RefreshConfig(object sender, EventArgs e)
    {
        try
        {
            uiListBox1.Items.Clear();
            uiListBox1.Tag = new List<Dictionary<int, string>>() { };
            foreach (var item in Directory.EnumerateFiles(path))
            {
                ICBFileProcessor iCBFileProcessor = new(item);
                var name = iCBFileProcessor.GetInfo(ICBFileProcessor.InfoType.Itptr_name);
                if (name.IsNullOrEmpty())
                {
                    return;
                }
                int index = uiListBox1.Items.Add(name);
                ((List<Dictionary<int, string>>)uiListBox1.Tag).Add(new Dictionary<int, string> { { index, item } });
                iCBFileProcessor = null;
            }
        }
        catch (Exception ex)
        {
            FrmMain.LOGGER.Err(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
            label6.Text = "Failed to refresh.";
            label6.Show();
            pictureBox1.Show();
        }
    }

    private void ReadValues(object sender, EventArgs e)
    {
        string path;
        try
        {
            path = (uiListBox1.Tag as List<Dictionary<int, string>>)[uiListBox1.SelectedIndex][uiListBox1.SelectedIndex];
            var icbfp = new ICBFileProcessor(path);
            var itptr_type = icbfp.GetInfo(ICBFileProcessor.InfoType.Itptr_type);
            var itptr_path = icbfp.GetInfo(ICBFileProcessor.InfoType.Itptr_path);
            var itptr_args = icbfp.GetInfo(ICBFileProcessor.InfoType.Itptr_args);
            CBoxItptrType.SelectedItem = itptr_type.ToLower().Contains("venv") ? "Virtual Environment(venv)" : itptr_type;
            TBoxItptrPath.Text = itptr_path;
            TBoxItptrArgs.Text = itptr_args;
            TBoxItptrFinalCmd.Text = $"\"{itptr_path}\" {itptr_args}";
        }
        catch (Exception ex)
        {
            FrmMain.LOGGER.Err(ex, EnumMsgLevel.WARN, EnumPort.CLIENT);
            if (ex is IOException) FrmMain.LOGGER.Log("I/O错误：无法读取文件。", EnumMsgLevel.ERROR, EnumPort.CLIENT, EnumModule.IO);
        }
    }

    private void UpdateItptrTypeInfo(object sender, EventArgs e)
    {
        string path = (uiListBox1.Tag as List<Dictionary<int, string>>)[uiListBox1.SelectedIndex][uiListBox1.SelectedIndex];
        var icbfp = new ICBFileProcessor(path);
        icbfp.SetInfo(ICBFileProcessor.InfoType.Itptr_type, CBoxItptrType.SelectedText);
        icbfp = null;
    }

    private void UpdateItptrPathInfo(object sender, EventArgs e)
    {
        string path = (uiListBox1.Tag as List<Dictionary<int, string>>)[uiListBox1.SelectedIndex][uiListBox1.SelectedIndex];
        var icbfp = new ICBFileProcessor(path);
        icbfp.SetInfo(ICBFileProcessor.InfoType.Itptr_path, TBoxItptrPath.Text);
        icbfp = null;
        TBoxItptrFinalCmd.Text = $"\"{TBoxItptrPath.Text}\" {TBoxItptrArgs.Text}";
    }

    private void UpdateItptrArgsInfo(object sender, EventArgs e)
    {
        string path = (uiListBox1.Tag as List<Dictionary<int, string>>)[uiListBox1.SelectedIndex][uiListBox1.SelectedIndex];
        var icbfp = new ICBFileProcessor(path);
        icbfp.SetInfo(ICBFileProcessor.InfoType.Itptr_args, TBoxItptrArgs.Text);
        icbfp = null;
        TBoxItptrFinalCmd.Text = $"\"{TBoxItptrPath.Text}\" {TBoxItptrArgs.Text}";
    }

    private void CopyToPaste(object sender, EventArgs e)
    {
        TBoxItptrFinalCmd.Copy();
    }

    private void ChooseDirectory(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            TBoxItptrPath.Text = openFileDialog1.FileName;
        }
    }

    private void Wait(object sender, EventArgs e)
    {
        label6.Hide();
        pictureBox1.Hide();
        timer1.Stop();
    }

    private void label6_VisibleChanged(object sender, EventArgs e)
    {
        timer1.Start();
    }

    private void RunCmd(object sender, EventArgs e)
    {
        ProcessStartInfo psi = new()
        {
            FileName = TBoxItptrPath.Text,
            Arguments = TBoxItptrArgs.Text,
            UseShellExecute = false,
        };
        try
        {
            Process.Start(psi);
        }
        catch (Exception ex)
        {
            FrmMain.LOGGER.Err(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
            label6.Text = "Fail to run command. Something wrong happened.";
            label6.Show();
            pictureBox1.Show();
        }
    }
}

internal class ICBFileProcessor
{
    private string _path;
    private IniFile _file;

    internal ICBFileProcessor(string path)
    {
        _path = path;
        _file = new(_path);
    }

    internal string GetInfo(InfoType infoType)
    {
        var ret = "";
        switch (infoType)
        {
            case InfoType.Itptr_name:
                ret = _file.Read("itptr", "name", "");
                break;
            case InfoType.Itptr_type:
                ret = _file.Read("itptr", "type", "");
                break;
            case InfoType.Itptr_path:
                ret = _file.Read("itptr", "path", "");
                break;
            case InfoType.Itptr_args:
                ret = _file.Read("itptr", "args", "");
                break;
            default:
                break;
        }
        return ret;
    }

    internal bool SetInfo(InfoType infoType, string value)
    {
        var ret = false;
        switch (infoType)
        {
            case InfoType.Itptr_name:
                ret = _file.Write("itptr", "name", value);
                break;
            case InfoType.Itptr_type:
                ret = _file.Write("itptr", "type", value);
                break;
            case InfoType.Itptr_path:
                ret = _file.Write("itptr", "path", value);
                break;
            case InfoType.Itptr_args:
                ret = _file.Write("itptr", "args", value);
                break;
            default:
                break;
        }
        return ret;
    }

    internal enum InfoType
    {
        Itptr_name,
        Itptr_type,
        Itptr_path,
        Itptr_args,
    }
}
