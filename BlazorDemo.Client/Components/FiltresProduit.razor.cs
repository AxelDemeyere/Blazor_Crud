using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Components;

public partial class FiltresProduit
{
    [Parameter] public string Recherche { get; set; } = string.Empty;

    [Parameter] public EventCallback<string> RechercheChanged { get; set; }

    [Parameter] public string CategorieSelectionnee { get; set; } = string.Empty;

    [Parameter] public EventCallback<string> CategorieSelectionneeChanged { get; set; }

    [Parameter] public EventCallback OnFiltreChange { get; set; }

    private async Task OnRechercheChange(ChangeEventArgs e)
    {
        var value = e.Value?.ToString() ?? string.Empty;
        await RechercheChanged.InvokeAsync(value);
        await OnFiltreChange.InvokeAsync();
    }

    private async Task OnCategorieChange(ChangeEventArgs e)
    {
        var value = e.Value?.ToString() ?? string.Empty;
        await CategorieSelectionneeChanged.InvokeAsync(value);
        await OnFiltreChange.InvokeAsync();
    }
}