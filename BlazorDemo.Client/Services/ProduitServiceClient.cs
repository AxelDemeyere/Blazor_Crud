using System.Net.Http.Json;
using BlazorDemo.Shared.Models;

namespace BlazorDemo.Client.Services;


public class ProduitServiceClient : IProduitServiceClient
{
    private readonly HttpClient _http;
    private const string BaseUrl = "api/produits";

    public ProduitServiceClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Produit>> ObtenirTousAsync()
    {
        try
        {
            var result = await _http.GetFromJsonAsync<List<Produit>>(BaseUrl);
            return result ?? new List<Produit>();
        }
        catch
        {
            return new List<Produit>();
        }
    }

    public async Task<Produit?> ObtenirParIdAsync(int id)
    {
        try
        {
            return await _http.GetFromJsonAsync<Produit>($"{BaseUrl}/{id}");
        }
        catch
        {
            return null;
        }
    }

    public async Task<List<Produit>> RechercherAsync(string terme)
    {
        try
        {
            var result = await _http.GetFromJsonAsync<List<Produit>>($"{BaseUrl}/recherche?terme={terme}");
            return result ?? new List<Produit>();
        }
        catch
        {
            return new List<Produit>();
        }
    }

    public async Task<List<Produit>> ObtenirParCategorieAsync(string categorie)
    {
        try
        {
            var result = await _http.GetFromJsonAsync<List<Produit>>($"{BaseUrl}/categorie/{categorie}");
            return result ?? new List<Produit>();
        }
        catch
        {
            return new List<Produit>();
        }
    }

    public async Task<Produit?> AjouterAsync(ProduitDto dto)
    {
        try
        {
            var response = await _http.PostAsJsonAsync(BaseUrl, dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Produit>();
        }
        catch
        {
            return null;
        }
    }

    public async Task<Produit?> ModifierAsync(int id, ProduitDto dto)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"{BaseUrl}/{id}", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Produit>();
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> SupprimerAsync(int id)
    {
        try
        {
            var response = await _http.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<string>> ObtenirCategoriesAsync()
    {
        try
        {
            var result = await _http.GetFromJsonAsync<List<string>>($"{BaseUrl}/categories");
            return result ?? new List<string>();
        }
        catch
        {
            return new List<string>();
        }
    }
}
