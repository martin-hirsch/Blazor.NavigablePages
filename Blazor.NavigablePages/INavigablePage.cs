using Microsoft.AspNetCore.Components;

namespace Blazor.NavigablePages;

/// <summary>
///     Use this interface for parameterless pages
/// </summary>
/// <typeparam name="TRoutableComponent">The Page that implements this interface</typeparam>
public interface INavigablePage<TRoutableComponent> where TRoutableComponent : INavigablePage<TRoutableComponent>
{
    static abstract string Path { get; }

    /// <summary>
    ///     Navigate to the page
    ///     <remarks>Use <see cref="NavigationManagerExtensions" /> for enhanced readability</remarks>
    /// </summary>
    /// <param name="navigationManager"></param>
    static void NavigateTo(NavigationManager navigationManager)
    {
        navigationManager.NavigateTo(TRoutableComponent.Path);
    }
}

public interface INavigablePage<in TRoutableComponent, in TNavigationParameter> where TRoutableComponent : INavigablePage<TRoutableComponent, TNavigationParameter>
{
    static abstract string Path { get; }

    static abstract string GetPathWithParameters(TNavigationParameter navigationParameter);

    static void NavigateTo(NavigationManager navigationManager, TNavigationParameter navigationParameter)
    {
        navigationManager.NavigateTo(TRoutableComponent.GetPathWithParameters(navigationParameter));
    }
}