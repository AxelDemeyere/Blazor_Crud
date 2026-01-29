using BlazorDemo.Server.Services;
using BlazorDemo.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDemo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {

        private readonly IProduitService _produitService;

        public ProduitsController(IProduitService produitService) => _produitService = produitService;

        [HttpGet]
        public async Task<ActionResult<List<Produit>>> GetAll() => Ok(await _produitService.ObtenirTousAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Produit>> GetById(int id)
        {
            var produit = await _produitService.ObtenirParIdAsync(id);
            return produit == null ? NotFound() : Ok(produit);
        }

        [HttpGet("recherche")]
        public async Task<ActionResult<List<Produit>>> Rechercher([FromQuery] string terme) => Ok(await _produitService.RechercherAsync(terme ?? ""));

        [HttpGet("categorie/{categorie}")]
        public async Task<ActionResult<List<Produit>>> GetByCategorie(string categorie) => Ok(await _produitService.ObtenirParCategorieAsync(categorie));

        [HttpGet("categories")]
        public async Task<ActionResult<List<string>>> GetCategories() => Ok(await _produitService.ObtenirCategoriesAsync());

        [HttpPost]
        public async Task<ActionResult<Produit>> Create([FromBody] ProduitDto dto)
        {
            var produit = await _produitService.AjouterAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = produit.Id }, produit);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produit>> Update(int id, [FromBody] ProduitDto dto)
        {
            var produit = await _produitService.ModifierAsync(id, dto);
            return produit == null ? NotFound() : Ok(produit);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) => await _produitService.SupprimerAsync(id) ? NoContent() : NotFound();
    }




}

