using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PXLApp.Models
{
    public class VakLector
    {
        [Key]
        public int VakLectorId { get; set; }

        [ForeignKey("Vak")]
        public int? VakId { get; set; }
        public Vak? Vak { get; set; }

        [ForeignKey("Lector")]
        public int? LectorId { get; set; }
        public Lector? Lector { get; set; }

        public VakLector() { }

        public VakLector(int vakId, int lectorId)
        {
            VakId = vakId;
            LectorId = lectorId;
        }
    }
}
