using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RE_Addon_Controls;
/// <summary>
/// Interaction logic for UserControl1.xaml
/// </summary>
public partial class CodeSenseSelection : UserControl
{
    private string CompletionText
    {
        get; set;
    }

    public CodeSenseSelection(string text)
    {
        InitializeComponent();
        CompletionText = text;
    }

    private void Initialize(object sender, RoutedEventArgs e)
    {
        CompletionTBox.Text = CompletionText;
    }
}

