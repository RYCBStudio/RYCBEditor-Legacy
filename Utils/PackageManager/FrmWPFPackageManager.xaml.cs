﻿using System;
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
            FrmMain.LOGGER.Log($"找不到文件: {ex.Message}");
            FrmMain.LOGGER.Err(ex);
        }
        catch (JsonException ex)
        {
            FrmMain.LOGGER.Log($"JSON 解析错误: {ex.Message}");
            FrmMain.LOGGER.Err(ex);
        }
        catch (Exception ex)
        {
            FrmMain.LOGGER.Err(ex);
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
        ((FrmWPFPackageViewModel)this.DataContext).SelectedPackages = ListBoxPackages.SelectedItems.Count;
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

    private void Search(object sender, RoutedEventArgs e)
    {
        foreach (var item in (List<PackageInfo>)ListBoxPackages.ItemsSource)
        {
            if (item.Name.Contains(SearchBox.Text)
                || item.Version.Contains(SearchBox.Text)
                || item.Dependencies.Contains(SearchBox.Text)
                || item.Description.Contains(SearchBox.Text)
                || item.Author.Contains(SearchBox.Text)
                || SearchBox.Text.Contains(item.Name)
                || SearchBox.Text.Contains(item.Author)
                || SearchBox.Text.Contains(item.Description)
                || SearchBox.Text.Contains(item.Dependencies))
            {
                ListBoxPackages.SelectedItem = item;
            }
        }
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
