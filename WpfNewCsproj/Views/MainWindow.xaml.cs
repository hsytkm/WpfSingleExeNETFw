using System.Windows;

namespace WpfNewCsproj.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        assembliesTextBlock.Text = Program.LoadedAssemblies.ToString();
    }
}
