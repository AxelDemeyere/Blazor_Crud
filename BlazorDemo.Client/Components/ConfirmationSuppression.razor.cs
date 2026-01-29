using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Components;

public partial class ConfirmationSuppression
{
    [Parameter]
    public bool Afficher { get; set; }

    [Parameter]
    public string Message { get; set; } = "Êtes-vous sûr de vouloir supprimer cet élément ? Cette action est irréversible.";

    [Parameter]
    public EventCallback OnAnnuler { get; set; }

    [Parameter]
    public EventCallback OnConfirmer { get; set; }

    private async Task Annuler()
    {
        await OnAnnuler.InvokeAsync();
    }

    private async Task Confirmer()
    {
        await OnConfirmer.InvokeAsync();
    }
}

