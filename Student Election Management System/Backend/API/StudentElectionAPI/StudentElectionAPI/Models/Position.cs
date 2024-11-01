using System.ComponentModel.DataAnnotations;

namespace StudentElectionAPI.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        public string? PositionName { get; set; }
    }
}
