using Microsoft.EntityFrameworkCore;
using TrainEdgeAPI.Models;

namespace TrainEdgeAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
        public DbSet<Student> Students { get; set; }
    }
}
