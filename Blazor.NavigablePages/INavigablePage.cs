using Microsoft.AspNetCore.Components;

namespace Blazor.NavigablePages;

public interface INavigablePage<TRoutableComponent> where TRoutableComponent : INavigablePage<TRoutableComponent>
{
    static abstract string Path { get; }

    static void NavigateTo(NavigationManager navigationManager)
    {
        navigationManager.NavigateTo(TRoutableComponent.Path);
    }
}

public interface INavigablePage<in TRoutableComponent, in TNavigationParameter> where TRoutableComponent : INavigablePage<TRoutableComponent, TNavigationParameter>
{
    static abstract string Path { get; }

    static abstract string GetPathWithParameters(TNavigationParameter navigationParameter);

    static abstract void NavigateTo(NavigationManager navigationManager, TNavigationParameter navigationParameter);
}