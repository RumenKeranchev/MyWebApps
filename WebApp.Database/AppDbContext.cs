using Microsoft.EntityFrameworkCore;

namespace WebApp.Database
{
    public class AppDbContext : DbContext
    {
        private const string _connectionString = "Server=(localdb)\\ProjectModels;Database=AppDbContext;Trusted_Connection=True;MultipleActiveResultSets=true";

        //public AppDbContext(DbContextOptions<AppDbContext> options)
        //   : base(options)
        //{           
        //}

        public DbSet<TodoItem> ToDoItems { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}