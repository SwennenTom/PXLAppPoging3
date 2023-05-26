using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PXLApp.Models;
using PXLApp.CustomModelValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PXLApp.Models
{
    public class Vak
    {
        [Key]
        public int VakId { get; set; }

        [Required(ErrorMessage = "Geef de naam van het vak.")]
        [MaxLength(100)]
        public string? VakNaam { get; set; }

        [Required(ErrorMessage = "Geef het aantal studiepunten.")]
        public int? Studiepunten { get; set; }

        [ForeignKey("Handboek")]
        [HandboekCheck]
        public int? HandboekId { get; set; }

        public Handboek? Handboek { get; set; }

        public Vak() { }

        public Vak(string vakNaam, int studiepunten, int handboekId)
        {
            VakNaam = vakNaam;
            Studiepunten = studiepunten;
            HandboekId = handboekId;
        }
    }
}
