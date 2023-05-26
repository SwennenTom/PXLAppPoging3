
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PXLApp.Models;

namespace PXLApp.Models
{
    public class Lector
    {
        [Key]
        public int LectorId { get; set; }

        [ForeignKey("Gebruiker")]
        public int? GebruikerId { get; set; }
        public Gebruiker? Gebruiker { get; set; }

        public Lector() { }

        public Lector(int gebruikerId)
        {
            GebruikerId = gebruikerId;
        }
    }

}
