using System.ComponentModel.DataAnnotations;

namespace StudentElectionAPI.Models
{
    public class StudentDto
    {
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }

        public string? Email { get; set; }

        [Required(ErrorMessage = "Course is Required")]
        public string? Course { get; set; }


        [Required(ErrorMessage = "Course is Required")]
        public int Year { get; set; }


        [Required(ErrorMessage = "Voter is Required")]
        public bool IsVoter { get; set; }
    }
}
