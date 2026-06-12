---
name: add-module
description: Scaffold a new MES module — creates Controller + View with correct naming, ViewData["Title"], and sidebar active-state logic. Usage: /add-module <ModuleName> [Page Title]
disable-model-invocation: false
---

The user wants to add a new module named `$ARGUMENTS`.

Parse `$ARGUMENTS` as: first word = ControllerName (PascalCase), rest = page display title (defaults to ControllerName if omitted).

## Steps

1. **Verify the name** — confirm `$ARGUMENTS` is provided and PascalCase. If empty, ask the user for the module name before proceeding.

2. **Create `Controllers/<Name>Controller.cs`**:

```csharp
using Microsoft.AspNetCore.Mvc;

namespace SmartMES.Controllers;

public class <Name>Controller : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "<Page Title>";
        return View();
    }
}
```

3. **Create the View directory** `Views/<Name>/` if it doesn't exist.

4. **Create `Views/<Name>/Index.cshtml`**:

```html
@{
    ViewData["Title"] = "<Page Title>";
}

<div class="d-flex align-items-center justify-content-between mb-4">
    <div>
        <h4 class="mb-0 fw-bold" style="color:#0f172a;"><Page Title></h4>
        <p class="mb-0 text-muted" style="font-size:13px;">Manage and monitor <page title lowercase></p>
    </div>
</div>

<div class="section-card">
    <div class="card-header-custom">
        <h6><i class="fa-solid fa-table me-2 text-primary"></i><Page Title></h6>
    </div>
    <div class="card-body-custom">
        <p class="text-muted" style="font-size:13px;">Content for <Page Title> goes here.</p>
    </div>
</div>

@* Page-specific CSS *@
<style>
    /* Add styles specific to this page here */
</style>

@section Scripts {
    @* Add page-specific JavaScript here *@
}
```

5. **Check sidebar status** — look in `Views/Shared/_Layout.cshtml` for an existing `asp-controller="<Name>"` link:
   - If it exists: tell the user the sidebar link is already wired and will highlight automatically.
   - If missing: show the user the exact HTML snippet to add to `_Layout.cshtml` in the appropriate section:
     ```html
     <a class="nav-link @(ViewContext.RouteData.Values["controller"]?.ToString() == "<Name>" ? "active" : "")"
        asp-controller="<Name>" asp-action="Index">
         <i class="fa-solid fa-<appropriate-icon>"></i>
         <Page Title>
     </a>
     ```
     Suggest an appropriate FontAwesome icon based on the module name.

6. **Run `dotnet build`** to confirm no compilation errors.

7. **Report** what was created and the URL to visit: `http://localhost:5120/<Name>`.
