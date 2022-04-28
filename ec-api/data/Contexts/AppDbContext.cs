namespace persistence.Contexts
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;
    using models;

    /// <summary>
    /// Class AppDbContext
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AppDbContext : DbContext
    {

        /// <summary>
        /// override method OnModelCreating
        /// </summary>
        /// <param name="builder">ModelBuilder</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Dessert>().ToTable("Dessert");
            builder.Entity<Dessert>().Property(dessert => dessert.Id).ValueGeneratedOnAdd();
            builder.Entity<Dessert>().Property(dessert => dessert.Name);
            builder.Entity<Dessert>().Property(dessert => dessert.Price);
        }

        public DbSet<Dessert> Desserts { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
