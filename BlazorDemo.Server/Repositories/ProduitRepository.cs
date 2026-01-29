using BlazorDemo.Server.Data;
using BlazorDemo.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Server.Repositories
{
    public class ProduitRepository : Repository<Produit>, IProduitRepository
    {

        public ProduitRepository(AppDbContext context) : base(context) { }

        public override async Task<IEnumerable<Produit>> GetAllAsync()
            => await _dbSet.OrderBy(p => p.Nom).ToListAsync();

        public async Task<IEnumerable<Produit>> RechercherAsync(string terme)
        {
            if (string.IsNullOrWhiteSpace(terme)) return await GetAllAsync();
            var t = terme.ToLower();
            return await _dbSet
                .Where(p => p.Nom.ToLower().Contains(t) || (p.Description != null && p.Description.ToLower().Contains(t)))
                .OrderBy(p => p.Nom).ToListAsync();
        }

        public async Task<IEnumerable<Produit>> GetByCategorieAsync(string categorie)
            => await _dbSet.Where(p => p.Categorie.ToString().ToLower() == categorie.ToLower()).OrderBy(p => p.Nom).ToListAsync();

        public async Task<IEnumerable<string>> GetCategoriesAsync()
            => await _dbSet.Select(p => p.Categorie.ToString()).Distinct().OrderBy(c => c).ToListAsync();

        public async Task<decimal> GetValeurStockAsync()
            => await _dbSet.SumAsync(p => p.Prix * p.Stock);
    }
}

    

