using PXLApp.CustomModelValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PXLApp.Models
{
    public class Inschrijving
    {
        [Key]
        public int InschrijvingId { get; set; }

        [ForeignKey("Student")]
        [InschrijvingsCheck]
        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        [ForeignKey("VakLector")]
        public int? VakLectorId { get; set; }
        public VakLector? VakLector { get; set; }

        [ForeignKey("AcademieJaar")]
        public int? AcademieJaarId { get; set; }
        public AcademieJaar? AcademieJaar { get; set; }

        public Inschrijving() { }

        public Inschrijving(int studentId, int vakLectorId, int academieJaarId)
        {
            StudentId = studentId;
            VakLectorId = vakLectorId;
            AcademieJaarId = academieJaarId;
        }
    }
}
