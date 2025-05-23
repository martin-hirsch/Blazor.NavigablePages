using Microsoft.AspNetCore.Components;

namespace Blazor.NavigablePages;

public static class NavigationManagerExtensions
{
    public static void NavigateTo<TRoutableComponent>(this NavigationManager navigationManager) where TRoutableComponent : INavigablePage<TRoutableComponent>
    {
        navigationManager.NavigateTo(TRoutableComponent.Path);
    }

    public static void NavigateTo<TRoutableComponent, TNavigationParameter>(this NavigationManager navigationManager, TNavigationParameter navigationParameter) where TRoutableComponent : INavigablePage<TRoutableComponent, TNavigationParameter>
    {
        navigationManager.NavigateTo(TRoutableComponent.GetPathWithParameters(navigationParameter));
    }
}