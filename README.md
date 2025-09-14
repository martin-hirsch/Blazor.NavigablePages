# Blazor.NavigablePages

Meet Blazor.NavigablePages! A small library for navigation in Blazor. Define each page's details about how to navigate
to it locally via an interface and navigate *ergonomically* using `NavigationManager` extension methods. With or without
parameters.

## Installation

- NuGet: Blazor.NavigablePages
- dotnet CLI: `dotnet add package Blazor.NavigablePages`
- Import namespace: `using Blazor.NavigablePages;`

Note: In the examples below, `Microsoft.AspNetCore.WebUtilities` (`QueryHelpers`) is optionally used to conveniently
build query strings.

## Parameterless Navigation

Implement the interface with the matching page directive:

```csharp
@page "/vans"
@using Blazor.NavigablePages
@implements INavigablePage<VansPage>

@code {
    public static string Path => "/vans";
}
```

Navigate to the page:

```csharp
@using Blazor.NavigablePages
@inject NavigationManager Nav

<button @onclick="() => Nav.NavigateTo<VansPage>()">Go to Vans</button>
```

## Navigation with a single parameter

Implement the generic interface variant with a parameter type:

```csharp
using Blazor.NavigablePages;
using Microsoft.AspNetCore.Components;

public partial class VansEditPage : INavigablePage<VansEditPage, Guid>
{ 
    [SupplyParameterFromQuery(Name = "id")]
    private Guid? VanId { get; set; }
    
    public static string Path => "/vans/edit";

    public static string GetPathWithParameters(Guid id)
    {
        return Path + "/" + id;
    }
}
```

Navigate to the page:

```csharp
@using Blazor.NavigablePages;
@inject NavigationManager Nav

<button @onclick="GoToEdit">Edit Van</button>

@code {
    void GoToEdit()
    {
        Nav.NavigateTo<VansListPage, Guid>(Guid.NewGuid();
    }
}
```

## Navigation with multiple parameters

Implement the generic interface variant with a parameter type.

```csharp
using Blazor.NavigablePages;
using Microsoft.AspNetCore.WebUtilities; // optional for QueryHelpers

public record Parameter(string Sort, string Brand);

public partial class VansListPage : INavigablePage<VansListPage, Parameter>
{ 
    public static string Path => "/vans/list";

    public static string GetPathWithParameters(Parameter p)
    {
        var dict = new Dictionary<string, string>
        {
            ["sort"] = p.Sort,
            ["brand"] = p.Brand
        };
        return QueryHelpers.AddQueryString(Path, dict);
    }
}
```

Navigate to the page:

```csharp
@inject NavigationManager Nav

<button @onclick="GoToFiltered">Filtered Vans</button>

@code {
    void GoToFiltered()
    {
        var parameter = new Parmeter(Sort: "asc", Brand: "Opel");
        Nav.NavigateTo<VansListPage, Parmeter>(parameter);
    }
}
```

## Why this package?

- No string literals scattered throughout your code
- Readable navigation via `NavigationManager.NavigateTo<TPage>()`
- Extensible for parameters through `GetPathWithParameters`

## Support

Found an issue or have an idea? Please open an issue in the repository. Happy navigating!