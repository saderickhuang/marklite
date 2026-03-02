using Markdig;

namespace MarkLite.Services;

public class MarkdownRenderer
{
    private readonly MarkdownPipeline _pipeline;
    
    public MarkdownRenderer()
    {
        _pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .UseTaskLists()
            .UseAutoLinks()
            .Build();
    }
    
    public string Render(string markdown)
    {
        if (string.IsNullOrEmpty(markdown))
            return "";
            
        var html = Markdig.Markdown.ToHtml(markdown, _pipeline);
        return WrapInHtmlTemplate(html);
    }
    
    private string WrapInHtmlTemplate(string bodyHtml)
    {
        return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset=""UTF-8"">
    <style id=""theme-style"">{ThemeService.Instance.GetLightCss()}</style>
    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/katex@0.16.9/dist/katex.min.css"">
    <script src=""https://cdn.jsdelivr.net/npm/katex@0.16.9/dist/katex.min.js""></script>
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
        input[type=""checkbox""] {{
            margin-right: 8px;
        }}
    </style>
</head>
<body>
{bodyHtml}
</body>
</html>";
    }
}
