using Microsoft.EntityFrameworkCore;
using TodoWebAppAPI.models;

namespace TodoWebAppAPI.Data
{
    public class TodosAPIDbContext : DbContext
    {
        public TodosAPIDbContext(DbContextOptions options) : base(options)   
        {
        }
       public DbSet<Todo> Todos { get; set; }
    }
}
