# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Smart MES — 智慧工廠製造執行系統 (Manufacturing Execution System)  
ASP.NET Core 9 MVC + Razor Views. No frontend build step; all CSS/JS loaded via CDN.

## Commands

```bash
dotnet run       # Start dev server → http://localhost:5120
dotnet build     # Compile only (no server)
```

No test framework configured yet.

## Architecture

Standard MVC layout. Every page automatically uses `Views/Shared/_Layout.cshtml` via `_ViewStart.cshtml`.

```
Controllers/          ← One file per module
Views/
  Shared/
    _Layout.cshtml    ← Sidebar + Topbar (DO NOT touch nav structure here)
  <ModuleName>/
    Index.cshtml      ← Folder name MUST match Controller name
wwwroot/              ← Static assets (images, custom JS/CSS)
```

## Adding a New Module

Three files required — no other config needed:

1. `Controllers/<Name>Controller.cs` — inherit `Controller`, set `ViewData["Title"]`
2. `Views/<Name>/Index.cshtml` — folder name must match controller exactly
3. Sidebar link already exists in `_Layout.cshtml` for: `Inventory`, `Orders`, `AiQC`, `CostAnalytics`, `RBAC`

Active sidebar highlighting is driven by:
```csharp
ViewContext.RouteData.Values["controller"]?.ToString() == "ControllerName"
```
The sidebar link for a new controller only highlights if its `asp-controller` value matches exactly.

## UI Conventions

**CDN only — no npm:**
- Bootstrap 5: `https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css`
- FontAwesome 6: `https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css`

**Reusable CSS classes** (defined in `Views/Home/Index.cshtml`, copy to new pages as needed):

| Class | Purpose |
|---|---|
| `section-card` | White content card with border and shadow |
| `kpi-card` | KPI number card with icon + trend line |
| `status-badge badge-running` | Green "Running" pill |
| `status-badge badge-idle` | Yellow "Idle" pill |
| `status-badge badge-error` | Red "Error" pill |
| `status-badge badge-pending` | Blue "Pending" pill |

**Page title** — always set `ViewData["Title"]` at the top of each view; it appears in both the browser tab and the topbar:
```csharp
@{ ViewData["Title"] = "Orders"; }
```

**Custom JavaScript** — place at the bottom of the view inside `@section Scripts {}`, never in `_Layout.cshtml`:
```html
@section Scripts {
    <script> /* page-specific JS here */ </script>
}
```

## Layout Rules

- **Do not modify** the sidebar nav or topbar HTML in `_Layout.cshtml` when building module pages
- All page content goes inside the view file only — `_Layout.cshtml` injects it via `@RenderBody()`
- The sidebar uses CSS variable `--sidebar-width: 250px` and is fixed-position

## Planned Modules

| Controller | Route | Status |
|---|---|---|
| `Home` | `/` | Done (Dashboard) |
| `Inventory` | `/Inventory` | Pending |
| `Orders` | `/Orders` | Pending |
| `AiQC` | `/AiQC` | Pending |
| `CostAnalytics` | `/CostAnalytics` | Pending |
| `RBAC` | `/RBAC` | Pending |

## Git & Collaboration

- Remote: `https://github.com/ceceee119/smartmse.git`
- Branch: `main`
- `appsettings.Development.json` is gitignored — each dev creates their own locally
- `bin/` and `obj/` are gitignored — run `dotnet build` after cloning
