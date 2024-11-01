using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentElectionAPI.Services;

namespace StudentElectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ElectionDbContext dbContext;
        public CandidateController(ElectionDbContext context)
        {
            dbContext = context;
        }

        [HttpGet("President")]
        public async Task<IActionResult> GetAllPresident()
        {
            if (dbContext == null)
            {
                return NotFound();
            }
            var president = await dbContext.Candidates.Where(c => c.PositionID == 1)
                                                .Include(s => s.Student)
                                                .Select(c => new
                                                {
                                                    CandidaeId = c.Id,
                                                    FullName = $"{c.Student.FirstName} {c.Student.LastName}",
                                                    Position = "President",
                                                    StudentCourse = c.Student.Course,
                                                    YearLevel = c.Student.Year,
                                                    TotalVotes = c.VoteCount

                                                }).ToListAsync();

            return Ok(president);
        }

        [HttpGet("VicePresident")]
        public async Task<IActionResult> GetAllVPresident()
        {
            var vPresident = await dbContext.Candidates.Where(c => c.PositionID == 2)
                                                       .Include(s => s.Student)
                                                       .Select(c => new
                                                       {
                                                           CandidaeId = c.Id,
                                                           FullName = $"{c.Student.FirstName} {c.Student.LastName}",
                                                           Position = "Vice-President",
                                                           StudentCourse = c.Student.Course,
                                                           YearLevel = c.Student.Year,
                                                           TotalVotes = c.VoteCount

                                                       }).ToListAsync();

            return Ok(vPresident);
        }

        [HttpGet("Secretary")]
        public async Task<IActionResult> GetAllSecretary()
        {
            var vPresident = await dbContext.Candidates.Where(c => c.PositionID == 3)
                                                       .Include(s => s.Student)
                                                       .Select(c => new
                                                       {
                                                           CandidaeId = c.Id,
                                                           FullName = $"{c.Student.FirstName} {c.Student.LastName}",
                                                           Position = "Secretary",
                                                           StudentCourse = c.Student.Course,
                                                           YearLevel = c.Student.Year,
                                                           TotalVotes = c.VoteCount

                                                       }).ToListAsync();

            return Ok(vPresident);
        }
    }
}
