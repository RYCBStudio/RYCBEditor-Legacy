using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
public partial class FileSHAorMD5Checker : UIForm
{
    public FileSHAorMD5Checker()
    {
        InitializeComponent();
    }

    private void OpenFile(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            txtBoxFilePath.Text = openFileDialog1.FileName;
            txtBoxFileName.Text = Main.GetFileName(openFileDialog1.FileName);
        }
    }

    private void FileChanged(object sender, EventArgs e)
    {
        txtBoxFileMD5.Text = GetMD5HashFromFile(txtBoxFilePath.Text);
        txtBoxFileSHA1.Text = GetSHA1(txtBoxFilePath.Text);
        txtBoxFileSHA256.Text = GetSHA256(txtBoxFilePath.Text);
    }

    public string GetMD5HashFromFile(string fileName)
    {
        try
        {
            var file = new FileStream(fileName, System.IO.FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            var retVal = md5.ComputeHash(file);
            file.Close();
            var sb = new StringBuilder();
            for (var i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        catch (Exception ex)
        {
            Main.LOGGER.WriteErrLog(new Exception("GetMD5HashFromFile() fail,error:" + ex.Message), EnumMsgLevel.ERROR, EnumPort.CLIENT);
        }
        return string.Empty;
    }

    public string GetSHA1(string s)
    {
        var file = new FileStream(s, FileMode.Open);
        SHA1 sha1 = new SHA1CryptoServiceProvider();
        var retval = sha1.ComputeHash(file);
        file.Close();

        var sc = new StringBuilder();
        for (var i = 0; i < retval.Length; i++)
        {
            sc.Append(retval[i].ToString("x2"));
        }
        return sc.ToString();
    }

    public static string GetSHA256(string filePath)
    {
        using (var sha256 = SHA256.Create())
        {
            using (var stream = File.OpenRead(filePath))
            {
                var hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }

    private void Judge_MD5(object sender, EventArgs e)
    {
        if (txtBoxFileMD5.Text.ToLower() == txtBoxGivenMD5Value.Text.ToLower())
        {
            pictureBox3.Image = IDE.Properties.Resources.save;
        }
        else
        {
            pictureBox3.Image = IDE.Properties.Resources.delete;
        }
    }

    private void Judge_SHA1(object sender, EventArgs e)
    {
        if (txtBoxFileSHA1.Text.ToLower() == txtBoxGivenSHA1Value.Text.ToLower())
        {
            pictureBox4.Image = IDE.Properties.Resources.save;
        }
        else
        {
            pictureBox4.Image = IDE.Properties.Resources.delete;
        }
    }

    private void Judge_SHA256(object sender, EventArgs e)
    {
        if (txtBoxFileSHA256.Text.ToLower() == txtBoxGivenSHA256Value.Text.ToLower())
        {
            pictureBox5.Image = IDE.Properties.Resources.save;
        }
        else
        {
            pictureBox5.Image = IDE.Properties.Resources.delete;
        }
    }
}
