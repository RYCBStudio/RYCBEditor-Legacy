using System.Windows;
using System.Windows.Controls;

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

