using BlazorDemo.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Components;

public partial class ModaleProduit
{
    [Parameter] public bool Afficher { get; set; }

    [Parameter] public string Titre { get; set; } = "Ajouter un produit";

    [Parameter] public Produit? ProduitAEditer { get; set; }

    [Parameter] public EventCallback OnFermer { get; set; }

    [Parameter] public EventCallback<ProduitDto> OnEnregistrer { get; set; }

    private ProduitDto _produit = new();

    protected override void OnParametersSet()
    {
        if (ProduitAEditer != null)
        {
            _produit = new ProduitDto
            {
                Nom = ProduitAEditer.Nom,
                Description = ProduitAEditer.Description,
                Prix = ProduitAEditer.Prix,
                Stock = ProduitAEditer.Stock,
                Categorie = ProduitAEditer.Categorie.ToString(),
                EstActif = ProduitAEditer.EstActif
            };
        }
        else
        {
            _produit = new ProduitDto
            {
                EstActif = true
            };
        }
    }

    private async Task Fermer()
    {
        await OnFermer.InvokeAsync();
    }

    private async Task Enregistrer()
    {
        await OnEnregistrer.InvokeAsync(_produit);
    }
}