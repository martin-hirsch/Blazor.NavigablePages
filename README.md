# Blazor.NavigablePages

## Usage

### 1. Basic Navigation

### 2. Navigation with Parameters

```csharp
public static string Path => "/collections/sites";

public static string GetPathWithParameters(IndexNavigationParameter navigationParameter)
{
    var parameters = new Dictionary<string, string>
    {
        { "sort", navigationParameter.Sort.ToString() },
        { "filter", navigationParameter.Filter.ToString() }
    };

    var result = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(Path, parameters);

    return result;
}
```~~~~