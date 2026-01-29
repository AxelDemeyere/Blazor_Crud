using BlazorDemo.Shared.Models;

namespace BlazorDemo.Server.Repositories
{
    public interface IProduitRepository : IRepository<Produit>
    {

        Task<IEnumerable<Produit>> RechercherAsync(string terme);
        Task<IEnumerable<Produit>> GetByCategorieAsync(string categorie);
        Task<IEnumerable<string>> GetCategoriesAsync();
        Task<decimal> GetValeurStockAsync();

    }
}
