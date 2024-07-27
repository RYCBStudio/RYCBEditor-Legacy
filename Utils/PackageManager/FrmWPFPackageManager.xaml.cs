using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace IDE.Utils.PackageManager;
/// <summary>
/// FrmWPFPackageManager.xaml 的交互逻辑
/// </summary>
public partial class FrmWPFPackageManager : Window
{
    public FrmWPFPackageManager()
    {
        InitializeComponent();
        var form = new PackageManagerMain();
        form.TopLevel = false;
        this.LocalPkgManager.Child = form;
        this.DataContext = new FrmWPFPackageViewModel();
        ProcessJSONFile();
    }

    private void ProcessJSONFile()
    {
        Dictionary<string, PackageInfo> packageDict = [];

        // JSON 文件路径
        string jsonFilePath = GlobalSettings.commonPackageIndexFilePath;

        try
        {
            // 读取 JSON 文件内容
            string jsonContent = File.ReadAllText(jsonFilePath);

            // 反序列化 JSON 内容为 Dictionary<string, PackageInfo>
            packageDict = JsonConvert.DeserializeObject<Dictionary<string, PackageInfo>>(jsonContent);

            // 构造 PackageInfo 列表
            List<PackageInfo> packages = new List<PackageInfo>(packageDict.Values);

            // 设置 ListBox 的数据源
            ListBoxPackages.ItemsSource = packages;
        }
        catch (FileNotFoundException ex)
        {
            MessageBox.Show($"找不到文件: {ex.Message}");
        }
        catch (JsonException ex)
        {
            MessageBox.Show($"JSON 解析错误: {ex.Message}");
        }
    }

    private void GetPkgInfo(object sender, SelectionChangedEventArgs e)
    {
        if (ListBoxPackages.SelectedIndex == -1) return;
        var pkginfo = ((List<PackageInfo>)ListBoxPackages.ItemsSource)[ListBoxPackages.SelectedIndex];
        TBlkName.Text = pkginfo.Name;
        TBlkVer.Text = pkginfo.Version;
        TBlkDesc.Text = pkginfo.Description;
        TBlkDepend.Text = pkginfo.Dependencies;
        TBlkAuthor.Text = pkginfo.Author;
    }

    private async void GetPackage(object sender, RoutedEventArgs e)
    {
        List<string> packages = [];
        foreach (PackageInfo item in ListBoxPackages.SelectedItems)
        {
            packages.Add(item.Name);
        }
        await new PackageProcessor(packages).DownloadAsync();
    }
}

public class PackageInfo
{
    public string Name
    {
        get; set;
    }
    public string Version
    {
        get; set;
    }

    public string Description
    {
        get; set;
    }
    public string Author
    {
        get; set;
    }
    public string Dependencies
    {
        get; set;
    }
}
