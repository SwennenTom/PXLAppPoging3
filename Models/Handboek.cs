using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PXLApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PXLApp.CustomModelValidation;

namespace PXLApp.Models
{
    public class Handboek
    {
        [Key]
        public int HandboekId { get; set; }

        [Required(ErrorMessage = "Geef een titel.")]
        [MaxLength(100)]
        public string? Titel { get; set; }

        [Required(ErrorMessage = "Geef de prijs.")]
        [Column(TypeName = "decimal(18,2)")]
        public double? KostPrijs { get; set; }

        [Required(ErrorMessage = "Geef de uitgiftedatum.")]
        [DatumCheck]
        public DateTime? Uitgiftedatum { get; set; }

        [MaxLength(255)]
        public string? Afbeelding { get; set; }

        //public List<Handboek> HandboekenLijst { get; set; }

        public Handboek() { }

        public Handboek(string titel, double kostPrijs, DateTime? uitgiftedatum, string afbeelding)
        {
            Titel = titel;
            KostPrijs = kostPrijs;
            Uitgiftedatum = uitgiftedatum;
            Afbeelding = afbeelding;
            //HandboekenLijst = new List<Handboek>();
        }
    }
}
