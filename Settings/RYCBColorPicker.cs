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
internal partial class RYCBColorPicker : UIForm
{
    internal Color Color
    {
        get; set;
    }

    private bool isInitialized = false;

    internal RYCBColorPicker()
    {
        InitializeComponent();
    }

    private string GetRGBFromColor(Color color)
    {
        string r = Convert.ToInt32(color.R).ToString();
        string g = Convert.ToInt32(color.G).ToString();
        string b = Convert.ToInt32(color.B).ToString();
        string rgb = string.Format("{0}, {1}, {2}", r, g, b);
        return rgb;
    }

    private Color GetColorFromRGB(string RGB)
    {
        string[] _RGB = RGB.Split(", ");
        int r = Convert.ToInt32(_RGB[0]);
        int g = Convert.ToInt32(_RGB[1]);
        int b = Convert.ToInt32(_RGB[2]);
        return Color.FromArgb(r, g, b);
    }

    private void RGBUpdate(object sender, EventArgs e)
    {
        if (!isInitialized)
        {
            return;
        }
        Color = GetColorFromRGB(rgbText.Text);
        hexText.Text = ColorTranslator.ToHtml(Color);
        uiColorPicker1.Value = Color;
    }

    private void HexUpdate(object sender, EventArgs e)
    {
        if (!isInitialized)
        {
            return;
        }
        Color = ColorTranslator.FromHtml(hexText.Text);
        rgbText.Text = GetRGBFromColor(Color);
        uiColorPicker1.Value = Color;
    }

    private void RYCBColorPicker_Load(object sender, EventArgs e)
    {
        uiColorPicker1.Value = Color;
        rgbText.Text = GetRGBFromColor(Color);
        hexText.Text = ColorTranslator.ToHtml(Color).RemoveLeft(1);
        isInitialized = true;
    }

    /// <summary>
    /// color 转换hex
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static string ColorToHex(Color color)
    {
        //int r = Mathf.RoundToInt(color.R * 255.0f);
        //int g = System.Mathf.RoundToInt(color.G * 255.0f);
        //int b = System.Mathf.RoundToInt(color.B * 255.0f);
        //int a = System.Mathf.RoundToInt(color.A * 255.0f);
        //string hex = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", r, g, b, a);
        return /*hex*/"";
    }

    private void Update(object sender, Color value)
    {
        rgbText.Text = GetRGBFromColor(value);
        hexText.Text = ColorTranslator.ToHtml(value).RemoveLeft(1);
        Color = value;
    }
}
