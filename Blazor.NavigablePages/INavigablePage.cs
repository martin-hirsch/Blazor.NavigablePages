using Microsoft.AspNetCore.Components;

namespace Blazor.NavigablePages;

public interface INavigablePage<TRoutableComponent> where TRoutableComponent : INavigablePage<TRoutableComponent>
{ 
    static abstract string Route { get; }
    
    static void NavigateTo(NavigationManager navigationManager)
    {
        navigationManager.NavigateTo(TRoutableComponent.Route);
    }
}

public interface INavigablePage<in TRoutableComponent, in TNavigationParameter> where TRoutableComponent : INavigablePage<TRoutableComponent, TNavigationParameter>
{
    static abstract string Route { get; }
    static abstract void NavigateTo(NavigationManager navigationManager, TNavigationParameter navigationParameter);
}