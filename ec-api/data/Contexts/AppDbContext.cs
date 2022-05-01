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
            builder.Entity<User>().Property(user => user.Email).IsRequired();
            builder.Entity<User>().Property(user => user.Name).IsRequired();
            builder.Entity<User>().Property(user => user.Lastname).IsRequired();
            builder.Entity<User>().Property(user => user.Password).IsRequired();
            builder.Entity<User>().Property(user => user.DateOfBirth).IsRequired();

            builder.Entity<Seller>().ToTable("Seller");
            builder.Entity<Seller>().Property(seller => seller.Id).ValueGeneratedOnAdd();
            builder.Entity<Seller>().HasOne(seller => seller.User)
                                    .WithOne(user => user.Seller)
                                    .HasForeignKey<Seller>(seller => seller.UserId);

            builder.Entity<Product>().ToTable("Product");
            builder.Entity<Product>().Property(product => product.Id).ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(product => product.Name).IsRequired();
            builder.Entity<Product>().Property(product => product.Price).IsRequired();
            builder.Entity<Product>().Property(product => product.Description).IsRequired().HasMaxLength(255);
            builder.Entity<Product>().Property(product => product.CreatedAt).ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(product => product.UpdatedAt).ValueGeneratedOnAddOrUpdate();
            builder.Entity<Product>().HasOne(product => product.Seller)
                                     .WithMany(seller => seller.Products)
                                     .HasForeignKey(product => product.SellerId);

        }

        public DbSet<Dessert> Desserts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
