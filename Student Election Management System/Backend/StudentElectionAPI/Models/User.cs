using System.ComponentModel.DataAnnotations;

namespace StudentElectionAPI.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? PasswordHashed { get; set; }
    }
}
