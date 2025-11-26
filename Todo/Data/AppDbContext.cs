using Microsoft.EntityFrameworkCore;
using Todo.API.Models;

namespace Todo.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet <TodoModel> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=todosApp.db");   
        }
    }
}
