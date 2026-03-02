# MarkLite

A lightweight Markdown editor inspired by Typora, built with WPF and .NET 8.

![Platform](https://img.shields.io/badge/platform-Windows-blue)
![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![License](https://img.shields.io/badge/license-MIT-green)

## Features

- **Instant Preview** - See rendered Markdown as you type (300ms debounce)
- **Live Rendering** - No need to switch between edit and preview modes
- **Theme Support** - Light and dark themes
- **Syntax Highlighting** - Code blocks with syntax highlighting
- **Task Lists** - GFM task list support
- **Auto-save** - Never lose your work
- **Keyboard Shortcuts** - Common shortcuts like Ctrl+S, Ctrl+O, Ctrl+N

## Screenshots

> Coming soon...

## Requirements

- Windows 10/11
- .NET 8.0 SDK
- WebView2 Runtime (usually pre-installed on Windows 10/11)

## Installation

```bash
# Clone the repository
git clone https://github.com/saderickhuang/marklite.git
cd marklite

# Build
dotnet build

# Run
dotnet run
```

## Keyboard Shortcuts

| Shortcut | Action |
|----------|--------|
| Ctrl+N | New file |
| Ctrl+O | Open file |
| Ctrl+S | Save file |
| Ctrl+Shift+S | Save as |
| Ctrl+Z | Undo |
| Ctrl+Y | Redo |

## Technology Stack

- **UI Framework**: WPF (.NET 8)
- **Markdown Parser**: [Markdig](https://github.com/xoofx/markdig)
- **HTML Renderer**: [WebView2](https://developer.microsoft.com/en-us/microsoft-edge/webview2/)
- **MVVM**: [CommunityToolkit.Mvvm](https://github.com/CommunityToolkit/dotnet)

## Project Structure

```
MarkLite/
├── App.xaml              # Application entry
├── MainWindow.xaml       # Main window UI
├── MarkLite.csproj       # Project file
├── ViewModels/
│   └── MainViewModel.cs # MVVM ViewModel
├── Services/
│   ├── MarkdownRenderer.cs # Markdown to HTML
│   └── ThemeService.cs    # Theme management
└── README.md
```

## Roadmap

- [x] Basic file operations (New/Open/Save)
- [x] Live Markdown preview
- [x] Theme switching (Light/Dark)
- [ ] Code syntax highlighting
- [ ] Math equations (KaTeX)
- [ ] Table support
- [ ] Export to PDF
- [ ] Export to HTML/Word
- [ ] Auto-save

## License

MIT License - see [LICENSE](LICENSE) for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

---

Built with ❤️ by [Huang Hao](https://github.com/saderickhuang)
