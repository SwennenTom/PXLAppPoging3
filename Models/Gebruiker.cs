using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PXLApp.Models;

namespace PXLApp.Models
{
    public class Gebruiker
    {
        [Key]
        public int GebruikerId { get; set; }

        [Required(ErrorMessage ="Geef een familienaam.")]
        [MaxLength(50)]
        public string? Naam { get; set; }

        [Required(ErrorMessage = "Geef een voornaam.")]
        [MaxLength(50)]
        public string? Voornaam { get; set; }

        [Required(ErrorMessage = "Geef een emailadres.")]
        [EmailAddress(ErrorMessage = "Geef een correct emailadres.")]
        [MaxLength(100)]
        public string? Email { get; set; }

        public Gebruiker() { }

        public Gebruiker(string naam, string voornaam, string email)
        {
            Naam = naam;
            Voornaam = voornaam;
            Email = email;
        }
    }

}
