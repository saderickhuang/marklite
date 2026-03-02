using System.Windows;
using MarkLite.ViewModels;
using MarkLite.Services;

namespace MarkLite;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // Initialize WebView2
        Loaded += async (s, e) =>
        {
            await PreviewWebView.EnsureCoreWebView2Async();
            PreviewWebView.NavigateToString(ThemeService.Instance.GetHtmlTemplate());
        };
        
        // Subscribe to theme changes
        if (DataContext is MainViewModel vm)
        {
            vm.PropertyChanged += (s, args) =>
            {
                if (args.PropertyName == nameof(MainViewModel.IsDarkMode))
                {
                    UpdatePreviewTheme(vm.IsDarkMode);
                }
            };
        }
    }
    
    private void UpdatePreviewTheme(bool isDark)
    {
        if (PreviewWebView.CoreWebView2 != null)
        {
            var css = isDark ? ThemeService.Instance.GetDarkCss() : ThemeService.Instance.GetLightCss();
            PreviewWebView.ExecuteScriptAsync($"document.getElementById('theme-style').textContent = `{css}`;");
        }
    }
}
