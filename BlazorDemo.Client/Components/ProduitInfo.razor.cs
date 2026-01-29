using BlazorDemo.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Components;

public partial class ProduitInfo
{
    [Parameter] public List<Produit> Produits { get; set; } = new();

    private int ProduitsActifs => Produits.Count(p => p.EstActif);
    private int ProduitsEnRupture => Produits.Count(p => p.Stock == 0);
    private decimal ValeurTotale => Produits.Sum(p => p.Prix * p.Stock);
}