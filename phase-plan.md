# MarkLite 详细开发计划

## Phase 1: 基础框架 (Week 1-2)

### Week 1: 项目搭建 + 主窗口
| 天数 | 任务 | 交付物 |
|-----|------|-------|
| Day 1 | 创建 .NET 8 WPF 项目，配置依赖 | 项目骨架 |
| Day 2 | 引入 Markdig, WebView2, AvalonEdit | NuGet 配置 |
| Day 3 | 设计主窗口布局（菜单栏、工具栏） | MainWindow.xaml |
| Day 4 | 状态栏 + 基础 MVVM 框架 | ViewModel 基类 |
| Day 5 | 登录窗口、设置窗口框架 | SettingsWindow |

**Week 1 结束目标**：空窗口能跑起来

### Week 2: 文件操作 + WebView2 集成
| 天数 | 任务 | 交付物 |
|-----|------|-------|
| Day 6 | 文件打开/保存对话框 | FileService |
| Day 7 | 编码检测 (UTF-8 BOM) | EncodingHelper |
| Day 8 | WebView2 初始化 + 基础 HTML 渲染 | EditorControl |
| Day 9 | 最小可行产品：能打开 .md 文件显示 | MVP v0.1 |
| Day 10 | 代码审查 + Bug 修复 | 稳定版 |

**Week 2 结束目标**：能打开 Markdown 文件并显示

---

## Phase 2: 核心编辑功能 (Week 3-4)

### Week 3: Markdown 解析 + 即时渲染
| 天数 | 任务 | 交付物 |
|-----|------|-------|
| Day 11 | Markdig 配置 + 基础解析 | MarkdownParser |
| Day 12 | 输入事件捕获 + 防抖 (300ms) | InputHandler |
| Day 13 | 渲染流程：文本 → HTML | RenderPipeline |
| Day 14 | 预览区样式初始化 | default.css |
| Day 15 | 标题、段落、粗体、斜体渲染 | 基础语法 |

**Week 3 结束目标**：输入文字，300ms 后显示渲染结果

### Week 4: 代码高亮 + 基础语法
| 天数 | 任务 | 交付物 |
|-----|------|-------|
| Day 16 | Prism.js 集成 | CodeHighlighter |
| Day 17 | 代码块渲染 | 代码块支持 |
| Day 18 | 链接 + 图片渲染 | 链接/图片 |
| Day 19 | 列表（有序/无序）渲染 | 列表支持 |
| Day 20 | 引用块渲染 | Blockquote |

**Week 4 结束目标**：常用 Markdown 语法都能正确渲染

---

## Phase 3: 高级功能 (Week 5-6)

### Week 5: 高级语法 + 自动保存
| 天数 | 任务 | 交付物 |
|-----|------|-------|
| Day 21 | KaTeX 集成 | MathRenderer |
| Day 22 | 行内公式 + 块公式 | 数学公式支持 |
| Day 23 | 表格解析 + 渲染 | TableSupport |
| Day 24 | 任务列表 (checkbox) | TaskListSupport |
| Day 25 | 自动保存逻辑 | AutoSaveService |

**Week 5 结束目标**：数学公式、表格、任务列表都能用

### Week 6: 目录 + 脚注 + 导出
| 天数 | 任务 | 交付物 |
|-----|------|-------|
| Day 26 | 目录自动生成 (TOC) | TocGenerator |
| Day 27 | 脚注支持 | FootnoteSupport |
| Day 28 | 导出 HTML | ExportService |
| Day 29 | 导出 PDF (PrintToPdf) | PDFExport |
| Day 30 | 导出 DOCX (DocX) | WordExport |

**Week 6 结束目标**：核心功能基本完成

---

## Phase 4: UI/UX 优化 (Week 7)

### Week 7: 主题系统 + 快捷键 + 性能
| 天数 | 任务 | 交付物 |
|-----|------|-------|
| Day 31 | 主题系统架构 | ThemeManager |
| Day 32 | 浅色主题 (GitHub 风格) | light.css |
| Day 33 | 深色主题 | dark.css |
| Day 34 | 主题切换 UI | 切换按钮 |
| Day 35 | 常用快捷键 (Ctrl+S, Ctrl+B 等) | KeyBindings |
| Day 36 | 性能优化 (大文档防卡) | PerformanceTuning |
| Day 37 | 拖拽打开文件 | DragDropSupport |
| Day 38 | 最近文件列表 | RecentFiles |

**Week 7 结束目标**：功能完整，体验良好

---

## Phase 5: 测试 + 发布 (Week 8)

### Week 8: 打磨 + 发布
| 天数 | 任务 | 交付物 |
|-----|------|-------|
| Day 39-40 | 内部测试 + Bug 修复 | BugFixes |
| Day 41-42 | 用户体验优化 | UXImprovements |
| Day 43-44 | 打包 (MSI / 便携版) | Installer |
| Day 45-46 | 说明文档 | README.md |
| Day 47-48 | 正式发布 | Release v1.0 |

**Week 8 结束目标**：可对外发布的稳定版本

---

## 每日工作节奏

```
09:00 - 10:00   任务规划 + 代码编写
10:00 - 12:00   核心功能开发
14:00 - 17:00   功能开发 + 测试
17:00 - 18:00   代码 review + 文档
```

---

## 关键依赖版本

| 包 | 版本 | 用途 |
---|------|-----|
| .NET | 8.0 LTS | 运行时 |
| Markdig | 0.34.0 | Markdown 解析 |
| WebView2 | 1.0.2210.55 | HTML 渲染 |
| AvalonEdit | 6.3.0 | 代码编辑（备选） |
| Katex.Net | 1.0.0 | 数学公式 |
| DocumentFormat.OpenXml | 3.0.0 | Word 导出 |

---

## 后续迭代 (v1.1+)

- 插件系统
- 大纲视图
- 多标签页
- 同步滚动
- 自定义 CSS
