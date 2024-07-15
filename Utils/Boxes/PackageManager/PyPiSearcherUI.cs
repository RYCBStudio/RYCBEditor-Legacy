using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using IDE.Utils.Boxes.PackageManager;
using Sunny.UI;

namespace IDE.Utils;
public partial class PyPiSearcherUI : UIForm
{
    private int currentPage = 1, totalpages;
    private string baseAdd = "https://pypi.org/search/?q={0}&page={1}";
    private List<Dictionary<string, string>> resLst = [];
    internal string query = "";
    private PackageManagerProgressWindow pw;

    public PyPiSearcherUI(string query = "")
    {
        InitializeComponent();
        this.query = query;
    }

    private void uiTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) { Search(sender, e); }
    }

    private void Search(object sender, EventArgs e)
    {
        ResLst.Items.Clear();
        pw = new(0, 10, true, PythonPackageManagerMain._I18nFile.Localize("text.ppmm.pkg.pypiprocessing"));
        pw.uiProcessBar1.Hide();
        pw.progressBar1.Show();
        var handler = new Action(() => pw.ShowDialog());
        handler.BeginInvoke(null, null);
        pw.TopMost = true;
        var _res = PypiHelper.ParseLinkWithContent(PypiHelper.GetHtml(string.Format(baseAdd, SchBox.Text, currentPage.ToString())));
        var res = PypiHelper.ConvertToDict(_res.Item1);
        resLst = res;
        foreach (var item in resLst)
        {
            ResLst.Items.Add(item["name"]);
        }
        Page.Text = $"{currentPage}/{_res.Item2}";
        totalpages = Convert.ToInt32(_res.Item2);
        pw.Hide();
    }

    private void GetInfo(object sender, EventArgs e)
    {
        NameBox.Text = resLst[ResLst.SelectedIndex]["name"];
        Version.Text = resLst[ResLst.SelectedIndex]["ver"];
        Description.Text = resLst[ResLst.SelectedIndex]["desc"];
    }

    private void PyPiSearcherUI_Load(object sender, EventArgs e)
    {
        SchBox.Text = query;
    }

    private void Install(object sender, EventArgs e)
    {
        var pip = new Process()
        {
            StartInfo = new()
            {
                Arguments = "install " + NameBox.Text,
                FileName = "pip",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            }
        };
        pip.Start();
        var output = pip.StandardOutput.ReadToEnd();
        var error = pip.StandardError.ReadToEnd();
        if (error.IsNullOrEmpty() & (output.Contains("Successfully installed") || output.Contains("Requirement already satisfied")))
        {
            MessageBox.Show(string.Format(PythonPackageManagerMain._I18nFile.Localize("text.ppmm.pkg.inst.suc"), NameBox.Text), "tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show($"{PythonPackageManagerMain._I18nFile.Localize("text.ppmm.pkg.inst.fail")} \n{error}", "tip", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        pip.Close();
    }

    private void NxtPg(object sender, EventArgs e)
    {
        currentPage++;
        if (currentPage >= totalpages) { currentPage = totalpages; }
        Search(sender, e);
    }

    private void PrePg(object sender, EventArgs e)
    {
        currentPage--;
        Search(sender, e);
    }

    private void PyPiSearcherUI_AfterShown(object sender, EventArgs e)
    {
        if (!query.IsNullOrEmpty()) { Search(sender, e); }
    }

    private void St(object sender, EventArgs e)
    {
        currentPage = 1;
        Search(sender, e);
    }

    private void Ed(object sender, EventArgs e)
    {
        currentPage = totalpages;
        Search(sender, e);
    }
}
