using Microsoft.EntityFrameworkCore;
using To_do_list.Data.Entities;

namespace To_do_list.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Issue> Issues { get; set; }
    }
}
