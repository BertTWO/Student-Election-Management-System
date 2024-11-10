using System.ComponentModel.DataAnnotations;

namespace StudentElectionAPI.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CandidateId { get; set; }
    }
}
