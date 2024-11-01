using Microsoft.EntityFrameworkCore;
using StudentElectionAPI.Models;

namespace StudentElectionAPI.Services
{

    public class ElectionDbContext : DbContext
    {
        public ElectionDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<Position> Positions { get; set; }

    }
}
