using System;
using System.ComponentModel.DataAnnotations;

namespace PXLApp.Models
{
    public class AcademieJaar
    {
        [Key]
        public int AcademieJaarId { get; set; }

        [Required(ErrorMessage = "Geef een datum.")]
        public DateTime? StartDatum { get; set; }

        public AcademieJaar() { }

        public AcademieJaar(DateTime startDatum)
        {
            StartDatum = startDatum.Date;
        }
    }
}
