
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PXLApp.Models;

namespace PXLApp.Models
{
    public class Student
    {
        //[Key]
        public int StudentId { get; set; }

        //[ForeignKey("Gebruiker")]
        public int? GebruikerId { get; set; }
        public Gebruiker? Gebruiker { get; set; }

        public Student() { }

        public Student(int gebruikerId)
        {
            GebruikerId = gebruikerId;

        }
    }

}
