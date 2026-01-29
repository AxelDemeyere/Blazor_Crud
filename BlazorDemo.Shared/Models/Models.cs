﻿
using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Shared.Models;

public class Produit
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom est obligatoire")]
    [StringLength(100, MinimumLength = 2)]
    public string Nom { get; set; } = "";

    [StringLength(500)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Le prix est obligatoire")]
    [Range(0.01, 99999.99)]
    public decimal Prix { get; set; }

    [Required(ErrorMessage = "La catégorie est obligatoire")]
    public EnumCategorie Categorie { get; set; }

    [Range(0, 10000)]
    public int Stock { get; set; }

    public bool EstActif { get; set; } = true;
    public DateTime DateCreation { get; set; } = DateTime.Now;
}

public class ProduitDto
{
    [Required(ErrorMessage = "Le nom est obligatoire")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Le nom doit contenir entre 2 et 100 caractères")]
    public string Nom { get; set; } = "";

    [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Le prix est obligatoire")]
    [Range(0.01, 99999.99, ErrorMessage = "Le prix doit être compris entre 0.01 et 99999.99")]
    public decimal Prix { get; set; }

    [Required(ErrorMessage = "La catégorie est obligatoire")]
    [MinLength(1, ErrorMessage = "Veuillez sélectionner une catégorie")]
    public string Categorie { get; set; } = "";

    [Range(0, 10000, ErrorMessage = "Le stock doit être compris entre 0 et 10000")]
    public int Stock { get; set; }

    public bool EstActif { get; set; } = true;
}

public class ContactDto
{
    [Required(ErrorMessage = "Le nom est obligatoire")]
    public string Nom { get; set; } = "";

    [Required(ErrorMessage = "L'email est obligatoire")]
    [EmailAddress(ErrorMessage = "Email invalide")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Le sujet est obligatoire")]
    public string Sujet { get; set; } = "";

    [Required(ErrorMessage = "Le message est obligatoire")]
    [StringLength(1000, MinimumLength = 10)]
    public string Message { get; set; } = "";

    public string? Priorite { get; set; } = "Normal";
}

public class StatistiquesDto
{
    public int Total { get; set; }
    public int Actifs { get; set; }
    public int EnRupture { get; set; }
    public decimal ValeurStock { get; set; }
}

