namespace Panda.Data
{
    using Microsoft.EntityFrameworkCore;
    using Panda.Models;

    public class PandaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Package> Packages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // User
            builder.Entity<User>()
                .HasKey(user => user.Id);

            builder.Entity<User>()
                .Property(user => user.Username)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<User>()
                .Property(user => user.Email)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<User>()
                .Property(user => user.Password)
                .IsRequired();

            // Package
            builder.Entity<Package>()
                .HasKey(p => p.Id);

            builder.Entity<Package>()
                .Property(p => p.Description)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<Package>()
                .HasOne(p => p.Recipient)
                .WithMany(u => u.Packages)
                .HasForeignKey(p => p.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Receipt
            builder.Entity<Receipt>()
                .HasKey(r => r.Id);

            builder.Entity<Receipt>()
                .HasOne(r => r.Recipient)
                .WithMany(u => u.Receipts)
                .HasForeignKey(p => p.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Receipt>()
                .HasOne(r => r.Package);


            base.OnModelCreating(builder);
        }
    }
}
