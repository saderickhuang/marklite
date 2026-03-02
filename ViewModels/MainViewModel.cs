using System.IO;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MarkLite.Services;
using Microsoft.Win32;

namespace MarkLite.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly MarkdownRenderer _renderer;
    private string? _currentFilePath;
    private System.Timers.Timer? _debounceTimer;
    
    [ObservableProperty]
    private string _markdownText = "# Welcome to MarkLite\n\nStart writing your Markdown here...\n\n## Features\n\n- **Bold** and *italic* text\n- [Links](https://example.com)\n- Code blocks\n- And more!\n";
    
    [ObservableProperty]
    private string _htmlContent = "";
    
    [ObservableProperty]
    private string _statusText = "Ready";
    
    [ObservableProperty]
    private int _wordCount = 0;
    
    [ObservableProperty]
    private bool _isDarkMode = false;
    
    [ObservableProperty]
    private bool _isModified = false;

    public MainViewModel()
    {
        _renderer = new MarkdownRenderer();
        UpdateHtml(MarkdownText);
        
        // Setup debounce timer for rendering
        _debounceTimer = new System.Timers.Timer(300);
        _debounceTimer.AutoReset = false;
        _debounceTimer.Elapsed += (s, e) =>
        {
            Application.Current.Dispatcher.Invoke(() => UpdateHtml(MarkdownText));
        };
    }

    partial void OnMarkdownTextChanged(string value)
    {
        IsModified = true;
        WordCount = string.IsNullOrWhiteSpace(value) ? 0 : value.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        _debounceTimer?.Stop();
        _debounceTimer?.Start();
    }
    
    private void UpdateHtml(string markdown)
    {
        HtmlContent = _renderer.Render(markdown);
    }

    [RelayCommand]
    private void New()
    {
        MarkdownText = "";
        _currentFilePath = null;
        IsModified = false;
        StatusText = "New file";
    }

    [RelayCommand]
    private void Open()
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Markdown files (*.md)|*.md|All files (*.*)|*.*",
            DefaultExt = ".md"
        };
        
        if (dialog.ShowDialog() == true)
        {
            try
            {
                MarkdownText = File.ReadAllText(dialog.FileName);
                _currentFilePath = dialog.FileName;
                IsModified = false;
                StatusText = $"Opened: {Path.GetFileName(dialog.FileName)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    [RelayCommand]
    private void Save()
    {
        if (string.IsNullOrEmpty(_currentFilePath))
        {
            SaveAs();
            return;
        }
        
        try
        {
            File.WriteAllText(_currentFilePath, MarkdownText);
            IsModified = false;
            StatusText = $"Saved: {Path.GetFileName(_currentFilePath)}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    [RelayCommand]
    private void SaveAs()
    {
        var dialog = new SaveFileDialog
        {
            Filter = "Markdown files (*.md)|*.md|All files (*.*)|*.*",
            DefaultExt = ".md"
        };
        
        if (dialog.ShowDialog() == true)
        {
            _currentFilePath = dialog.FileName;
            Save();
        }
    }

    [RelayCommand]
    private void Exit()
    {
        if (IsModified)
        {
            var result = MessageBox.Show("Do you want to save changes?", "Unsaved Changes", 
                MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                Save();
            }
            else if (result == MessageBoxResult.Cancel)
            {
                return;
            }
        }
        
        Application.Current.Shutdown();
    }

    [RelayCommand]
    private void ToggleTheme()
    {
        IsDarkMode = !IsDarkMode;
        ThemeService.Instance.SetTheme(IsDarkMode ? Theme.Dark : Theme.Light);
    }

    [RelayCommand]
    private void About()
    {
        MessageBox.Show("MarkLite v1.0.0\n\nA lightweight Markdown editor inspired by Typora.\n\nBuilt with WPF and Markdig.", 
            "About MarkLite", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
