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

            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().Property(user => user.Id).ValueGeneratedOnAdd();
            builder.Entity<User>().Property(user => user.Email);
            builder.Entity<User>().Property(user => user.Name);
            builder.Entity<User>().Property(user => user.Lastname);
            builder.Entity<User>().Property(user => user.Password);
            builder.Entity<User>().Property(user => user.DateOfBirth);
        }

        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
