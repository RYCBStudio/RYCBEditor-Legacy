using System;
using System.Threading.Tasks;
using Sunny.UI;

namespace IDE;
public partial class InterpreterConfigBox : UIForm
{
    private string path;

    public InterpreterConfigBox(string path)
    {
        InitializeComponent();
        this.path = path;
    }

    private async void InterpreterConfigBox_Load(object sender, EventArgs e)
    {
        ICBFileProcessor iCBFileProcessor = new(this.path);
        var type = await Task.Run(() => iCBFileProcessor.GetInfo(ICBFileProcessor.InfoType.Itptr_type));
        var path = await Task.Run(() => iCBFileProcessor.GetInfo(ICBFileProcessor.InfoType.Itptr_path));
        var args = await Task.Run(() => iCBFileProcessor.GetInfo(ICBFileProcessor.InfoType.Itptr_args));
        CBoxItptrType.Text = type;
        TBoxItptrPath.Text = path;
        TBoxItptrArgs.Text = args;
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

    internal enum InfoType
    {
        Itptr_type,
        Itptr_path,
        Itptr_args,
    }
}
