using System;
using System.Drawing;
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
        var r = Convert.ToInt32(color.R).ToString();
        var g = Convert.ToInt32(color.G).ToString();
        var b = Convert.ToInt32(color.B).ToString();
        var rgb = string.Format("{0}, {1}, {2}", r, g, b);
        return rgb;
    }

    private Color GetColorFromRGB(string RGB)
    {
        var _RGB = RGB.Split(", ");
        var r = Convert.ToInt32(_RGB[0]);
        var g = Convert.ToInt32(_RGB[1]);
        var b = Convert.ToInt32(_RGB[2]);
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
        hexText.Text = ColorTranslator.ToHtml(Color).Replace("#", "");
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
