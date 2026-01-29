﻿using BlazorDemo.Server.Repositories;
using BlazorDemo.Shared.Models;

namespace BlazorDemo.Server.Services
{
    public class ProduitService : IProduitService
    {
        private readonly IProduitRepository _repository;

        public ProduitService(IProduitRepository repository) => _repository = repository;

        public async Task<List<Produit>> ObtenirTousAsync() => (await _repository.GetAllAsync()).ToList();
        public async Task<Produit?> ObtenirParIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<List<Produit>> RechercherAsync(string terme) => (await _repository.RechercherAsync(terme)).ToList();
        public async Task<List<Produit>> ObtenirParCategorieAsync(string categorie) => (await _repository.GetByCategorieAsync(categorie)).ToList();

        public async Task<Produit> AjouterAsync(ProduitDto dto)
        {
            var produit = new Produit
            {
                Nom = dto.Nom,
                Description = dto.Description,
                Prix = dto.Prix,
                Categorie = (EnumCategorie)Enum.Parse(typeof(EnumCategorie), dto.Categorie),
                Stock = dto.Stock,
                EstActif = dto.EstActif,
                DateCreation = DateTime.Now
            };
            return await _repository.AddAsync(produit);
        }

        public async Task<Produit?> ModifierAsync(int id, ProduitDto dto)
        {
            var produit = await _repository.GetByIdAsync(id);
            if (produit == null) return null;
            produit.Nom = dto.Nom; produit.Description = dto.Description; produit.Prix = dto.Prix;
            produit.Categorie = (EnumCategorie)Enum.Parse(typeof(EnumCategorie), dto.Categorie); produit.Stock = dto.Stock; produit.EstActif = dto.EstActif;
            return await _repository.UpdateAsync(produit);
        }

        public async Task<bool> SupprimerAsync(int id) => await _repository.DeleteAsync(id);
        public async Task<List<string>> ObtenirCategoriesAsync() => (await _repository.GetCategoriesAsync()).ToList();

       
    }
}
