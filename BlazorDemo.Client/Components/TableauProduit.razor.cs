using BlazorDemo.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Components;

public partial class TableauProduit
{
    [Parameter] public List<Produit> Produits { get; set; } = new();

    [Parameter] public bool Chargement { get; set; }

    [Parameter] public EventCallback OnRecharger { get; set; }
    
    [Parameter] public EventCallback<int> OnModifier { get; set; }

    [Parameter] public EventCallback<int> OnSupprimer { get; set; }

}