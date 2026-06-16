# Beverage MES Demo — 飲料工廠製造執行系統

一個以飲料工廠為情境的 MES（製造執行系統）展示專案，使用 ASP.NET Core 9 MVC 開發。
所有資料為前端 Mock，**不需資料庫**，clone 下來直接跑。

## 功能頁面

| 頁面 | 說明 |
|---|---|
| Dashboard | 工廠總覽 — KPI、產線狀態、即時告警、訂單 Pipeline |
| Inventory | 原料庫存管理 — 庫存清單、安全庫存警示、新增／編輯／刪除 |
| Orders | 訂單排程 — List / Kanban 雙模式、備料狀態燈號、CRUD |
| Cost Analytics | 成本分析 — 訂單利潤率、成本結構圓餅圖 |
| AI QC | AI 品質檢驗 — 輸送帶瑕疵偵測模擬、瑕疵分類清單 |
| Access Control | 使用者權限管理 — 角色指派、帳號狀態、CRUD |

## 快速開始

**環境需求：** [.NET 9 SDK](https://dotnet.microsoft.com/download)

```bash
git clone https://github.com/ceceee119/beverage-mes-demo.git
cd beverage-mes-demo
dotnet run
```

瀏覽器開啟 `http://localhost:5120`

## 技術架構

- **後端**：ASP.NET Core 9 MVC + Razor Views
- **前端**：Bootstrap 5、FontAwesome 6（CDN，無需 npm）
- **資料**：JavaScript Mock 陣列（無資料庫）
