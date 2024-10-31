using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentElectionAPI.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? LastName { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? Email { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? Course { get; set; }

        public int Year { get; set; }

        public bool IsVoter { get; set; }
    }
}
