using System.Windows;
using MarkLite.ViewModels;
using MarkLite.Services;

namespace MarkLite;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        // Initialize services
        ThemeService.Instance.LoadDefaultTheme();
        
        // Create and show main window
        var mainWindow = new MainWindow();
        mainWindow.DataContext = new MainViewModel();
        mainWindow.Show();
    }
}
