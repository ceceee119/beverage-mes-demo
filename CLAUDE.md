# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Smart MES — 飲料工廠製造執行系統 Demo (Beverage Factory MES Demo)  
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

## Modules

| Controller | Route | Status | 說明 |
|---|---|---|---|
| `Home` | `/` | ✅ Done | Dashboard — KPI、產線狀態、告警、訂單 Pipeline |
| `Inventory` | `/Inventory` | ✅ Done | 進銷存管理 — Data Grid、庫存率 Bar、右側 Drawer（流水帳 + 歷史成本） |
| `Orders` | `/Orders` | ✅ Done | 訂單排程 — List View / Kanban Board 切換、備料燈號 |
| `CostAnalytics` | `/CostAnalytics` | ✅ Done | 成本分析 — KPI 卡、成本結構、訂單拆解表（利潤率 Bar） |
| `AiQC` | `/AiQC` | ✅ Done | AI 品檢 — 雙欄佈局、瑕疵清單、PCB 模擬圖 + Bounding Box |
| `RBAC` | `/RBAC` | ✅ Done | 權限管理 — 使用者列表、角色標籤、CRUD |

## Mock 資料關聯說明

所有頁面 Mock 資料共用同一組欄位互相關聯：

- **Order_ID**：`ORD-2026-0840` ～ `ORD-2026-0845`（出現在 Orders、CostAnalytics、Dashboard）
- **MAT_ID**：`MAT-001` ～ `MAT-008`（出現在 Inventory、Orders 備料狀態）
- Inventory 的 `status` 欄位影響 Orders 看板上的「備料燈號」顯示邏輯

日後對接後端 API 時，將 View 中的 JavaScript Mock 陣列替換為 `fetch()` 呼叫即可。

## Git & Collaboration

- Remote: `https://github.com/ceceee119/beverage-mes-demo.git`
- Branch: `main`
- `appsettings.Development.json` is gitignored — each dev creates their own locally
- `bin/` and `obj/` are gitignored — run `dotnet build` after cloning

## 組員環境設定（Clone 後執行）

```bash
git clone https://github.com/ceceee119/beverage-mes-demo.git
cd beverage-mes-demo
dotnet run
```

瀏覽器開 `http://localhost:5120` 即可看到網站。  
**不需要資料庫**，所有資料為 JavaScript Mock 陣列，clone 下來直接跑。
