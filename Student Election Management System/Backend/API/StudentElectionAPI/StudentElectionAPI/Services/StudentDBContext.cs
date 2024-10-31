using Microsoft.EntityFrameworkCore;
using StudentElectionAPI.Models;

namespace StudentElectionAPI.Services
{

    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Student> Students { get; set; }

    }
}
