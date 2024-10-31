using Microsoft.AspNetCore.Mvc;
using StudentElectionAPI.Models;
using StudentElectionAPI.Services;

namespace StudentElectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDBContext dBContext;
        public StudentsController(StudentDBContext dbContext)
        {
            dBContext = dbContext;
        }
        [HttpGet]
        public List<Student> GetAllStudents()
        {
            return dBContext.Students.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = dBContext.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public IActionResult AddStudent(StudentDto student)
        {
            dBContext.Students.Add(new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Course = student.Course,
                Email = student.Email,
                Year = student.Year,
                IsVoter = student.IsVoter
            });

            dBContext.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = dBContext.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            dBContext.Students.Remove(student);
            dBContext.SaveChanges();

            return Ok(new { message = "Student Deleted!" });
        }


        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentDto newStudent)
        {
            var student = dBContext.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }
            student.FirstName = newStudent.FirstName;
            student.LastName = newStudent.LastName;
            student.Email = newStudent.Email;
            student.Course = newStudent.Course;
            student.Year = newStudent.Year;
            student.IsVoter = newStudent.IsVoter;

            dBContext.SaveChanges();
            return Ok(new { Success = $"student with {id} id is updated!" });
        }
    }
}
