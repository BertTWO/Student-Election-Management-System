using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentElectionAPI.Models
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }


        [ForeignKey("Position")]
        public int PositionID { get; set; }

        [Required]
        public Student? Student { get; set; }


        public int VoteCount { get; set; } = 0;

    }
}
