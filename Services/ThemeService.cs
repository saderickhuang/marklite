namespace MarkLite.Services;

public enum Theme
{
    Light,
    Dark
}

public class ThemeService
{
    private static ThemeService? _instance;
    public static ThemeService Instance => _instance ??= new ThemeService();
    
    private Theme _currentTheme = Theme.Light;
    
    public void LoadDefaultTheme()
    {
        // Default to light theme
    }
    
    public void SetTheme(Theme theme)
    {
        _currentTheme = theme;
    }
    
    public string GetHtmlTemplate()
    {
        return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset=""UTF-8"">
    <style id=""theme-style"">{GetLightCss()}</style>
    <style>
        body {{
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif;
            line-height: 1.6;
            padding: 20px;
            max-width: 800px;
            margin: 0 auto;
        }}
        pre {{
            background: #f6f8fa;
            padding: 16px;
            border-radius: 6px;
            overflow-x: auto;
        }}
        code {{
            font-family: 'Consolas', 'Monaco', monospace;
            background: #f6f8fa;
            padding: 2px 6px;
            border-radius: 3px;
        }}
        pre code {{
            background: none;
            padding: 0;
        }}
        blockquote {{
            border-left: 4px solid #ddd;
            margin: 0;
            padding-left: 16px;
            color: #666;
        }}
        table {{
            border-collapse: collapse;
            width: 100%;
            margin: 16px 0;
        }}
        th, td {{
            border: 1px solid #ddd;
            padding: 8px 12px;
            text-align: left;
        }}
        th {{
            background: #f6f8fa;
        }}
        img {{
            max-width: 100%;
        }}
    </style>
</head>
<body>
    <h1>Welcome to MarkLite</h1>
    <p>Start writing your Markdown here...</p>
</body>
</html>";
    }
    
    public string GetLightCss()
    {
        return @"
body {
    background: #ffffff;
    color: #333333;
}
pre, code {
    background: #f6f8fa;
}
blockquote {
    border-color: #ddd;
    color: #666;
}
th, td {
    border-color: #ddd;
}
th {
    background: #f6f8fa;
}
a {
    color: #2196F3;
}
";
    }
    
    public string GetDarkCss()
    {
        return @"
body {
    background: #1e1e1e;
    color: #d4d4d4;
}
pre, code {
    background: #2d2d2d;
}
blockquote {
    border-color: #555;
    color: #999;
}
th, td {
    border-color: #444;
}
th {
    background: #2d2d2d;
}
a {
    color: #64B5F6;
}
";
    }
}
