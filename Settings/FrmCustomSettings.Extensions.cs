using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
public partial class FrmCustomSettings
{

    #region ComboBox Items设定
    /// <summary>
    /// ComboBox Items设定
    /// </summary>
    /// <param name="CobBox">ComboBox 名称</param>
    /// <param name="ItemsValue">要添加的Items(各项目之间用;隔开)</param>
    public static void SetCobBoxItems(ComboBox CobBox, string ItemsValue)
    {
        CobBox.Items.Clear();
        CobBox.Text = "";
        if (ItemsValue == null) { return; }
        var s = ItemsValue.Split(new char[] { ';' });
        for (var i = 0; i <= s.Length - 1; i++)
        {
            CobBox.Items.Add(s[i].ToString());
        }
    }

    /// <summary>
    /// ComboBox Items设定
    /// </summary>
    /// <param name="CobBox">ComboBox 名称</param>
    /// <param name="ItemsList">List</param>
    public static void SetCobBoxItems(ComboBox CobBox, List<string> ItemsList)
    {
        CobBox.Items.Clear();
        CobBox.Text = "";
        if (ItemsList.Count == 0) { return; }
        for (var i = 0; i <= ItemsList.Count - 1; i++)
        {
            CobBox.Items.Add(ItemsList[i].ToString());
        }
    }

    /// <summary>
    /// ComboBox Items设定
    /// </summary>
    /// <param name="CobBox">ComboBox 名称</param>
    /// <param name="ItemsValue">要添加的Items(各项目之间用;隔开)</param>
    public static void SetSunnyCobBoxItems(UIComboBox CobBox, string ItemsValue)
    {
        CobBox.Items.Clear();
        CobBox.Text = "";
        if (ItemsValue == null) { return; }
        var s = ItemsValue.Split(new char[] { ';' });
        for (var i = 0; i <= s.Length - 1; i++)
        {
            CobBox.Items.Add(s[i].ToString());
        }
    }
    /// <summary>
    /// ComboBox Items设定
    /// </summary>
    /// <param name="CobBox">ComboBox 名称</param>
    /// <param name="ItemsList">List</param>
    public static void SetSunnyCobBoxItems(UIComboBox CobBox, List<string> ItemsList)
    {
        CobBox.Items.Clear();
        CobBox.Text = "";
        if (ItemsList.Count == 0) { return; }
        for (var i = 0; i <= ItemsList.Count - 1; i++)
        {
            CobBox.Items.Add(ItemsList[i].ToString());
        }
    }
    /// <summary>
    /// ComboBox Items设定
    /// </summary>
    /// <param name="CobBox">ComboBox 名称</param>
    /// <param name="families">List</param>
    private void SetSunnyCobBoxItems(UIComboBox CobBox, System.Drawing.FontFamily[] families)
    {
        CobBox.Items.Clear();
        CobBox.Text = "";
        if (families.Length == 0) { return; }
        for (var i = 0; i <= families.Length - 1; i++)
        {
            CobBox.Items.Add(families[i].Name);
        }
    }

    #endregion
}
