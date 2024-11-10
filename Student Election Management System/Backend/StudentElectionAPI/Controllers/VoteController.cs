using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentElectionAPI.Models;
using StudentElectionAPI.Services;

namespace StudentElectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly ElectionDbContext dbContext;
        public VoteController(ElectionDbContext context)
        {
            this.dbContext = context;

        }


        [HttpPost("{StudentId}-{CandidateId}")]
        public ActionResult CastAVote(int StudentId, int CandidateId)
        {


            var student = dbContext.Students.Find(StudentId);

            var candidate = dbContext.Candidates.Find(CandidateId);
            if (student == null || student.IsVoter == false)
            {
                return NotFound(new { message = "You have already voted or the student does not exist." });
            }

            if (candidate == null)
            {
                return NotFound(new { message = "Candidate Id not Found" });
            }

            dbContext.Votes.Add(
                new Vote
                {
                    StudentId = student.Id,
                    CandidateId = candidate.Id
                }
            );
            candidate.VoteCount++;
            student.IsVoter = false;

            dbContext.SaveChanges();
            return Ok(new { message = $"{candidate.VoteCount} voted\n{student.FirstName} voted" });
        }


        //testing
        [HttpDelete("ResetVotes")]
        public ActionResult ResetAllVotes()
        {

            dbContext.Students.ExecuteUpdate(c => c.SetProperty(s => s.IsVoter, true));
            dbContext.Candidates.ExecuteUpdate(c => c.SetProperty(c => c.VoteCount, 0));
            dbContext.SaveChanges();
            return Ok(new { Message = "All vote has been reset to 0" });
        }
    }
}
