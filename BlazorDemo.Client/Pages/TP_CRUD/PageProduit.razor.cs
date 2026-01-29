using BlazorDemo.Shared.Models;

namespace BlazorDemo.Client.Pages.TP_CRUD;

public partial class PageProduit
{
    private List<Produit> _produits = new();
    private bool _chargement;
    private bool _isEditMode = false;
    private string _recherche = string.Empty;
    private string _categorieSelectionnee = string.Empty;
    private bool _afficherModale = false;
    private Produit? _produitAEditer = null;
    private bool _afficherConfirmation = false;
    private string _messageConfirmation = string.Empty;
    private int _idProduitASupprimer = 0;


    private List<Produit> ProduitsFiltres
    {
        get
        {
            var resultats = _produits.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(_recherche))
            {
                resultats = resultats.Where(p =>
                    p.Nom.Contains(_recherche, StringComparison.OrdinalIgnoreCase) ||
                    (p.Description?.Contains(_recherche, StringComparison.OrdinalIgnoreCase) ?? false)
                );
            }

            if (!string.IsNullOrWhiteSpace(_categorieSelectionnee))
            {
                resultats = resultats.Where(p => p.Categorie.ToString() == _categorieSelectionnee);
            }

            return resultats.ToList();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await Charger();
    }

    private async Task Charger()
    {
        _chargement = true;
        _produits = await ProduitService.ObtenirTousAsync();
        _chargement = false;
    }

    private void Filtrer()
    {
        StateHasChanged();
    }

    private void OuvrirModale()
    {
        _isEditMode = false;
        _produitAEditer = null;
        _afficherModale = true;
    }

    private void FermerModale()
    {
        _isEditMode = false;
        _produitAEditer = null;
        _afficherModale = false;
    }

    private async Task EnregistrerProduit(ProduitDto dto)
    {
        if (_isEditMode && _produitAEditer != null)
        {
            var resultat = await ProduitService.ModifierAsync(_produitAEditer.Id, dto);
            
            if (resultat == null)
            {
                Console.WriteLine("Erreur lors de la modification du produit");
                return;
            }
        }
        else
        {
            var resultat = await ProduitService.AjouterAsync(dto);
            
            if (resultat == null)
            {
                Console.WriteLine("Erreur lors de l'ajout du produit");
                return;
            }
        }
        
        await Charger();
        FermerModale();
    }

    private async Task ModifierProduit(int id)
    {
        _isEditMode = true;
        
        _produitAEditer = await ProduitService.ObtenirParIdAsync(id);
        
        if (_produitAEditer != null)
        {
            _afficherModale = true;
        }
        else
        {
            Console.WriteLine($"Produit avec l'id {id} introuvable");
        }
    }
    
    private async Task SupprimerProduit(int id)
    {
        var produit = await ProduitService.ObtenirParIdAsync(id);
        
        if (produit != null)
        {
            _idProduitASupprimer = id;
            _messageConfirmation = $"Êtes-vous sûr de vouloir supprimer le produit \"{produit.Nom}\" ? Cette action est irréversible.";
            _afficherConfirmation = true;
        }
    }

    private void AnnulerSuppression()
    {
        _afficherConfirmation = false;
        _idProduitASupprimer = 0;
        _messageConfirmation = string.Empty;
    }

    private async Task ConfirmerSuppression()
    {
        var succes = await ProduitService.SupprimerAsync(_idProduitASupprimer);
        
        if (succes)
        {
            await Charger();
        }
        else
        {
            Console.WriteLine("Erreur lors de la suppression du produit");
        }
        
        AnnulerSuppression();
    }
}