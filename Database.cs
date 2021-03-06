using Microsoft.EntityFrameworkCore;

namespace RecipeMaker
{
    public class Database : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public Database(DbContextOptions<Database> options) : base(options) { }
        
    }
}
