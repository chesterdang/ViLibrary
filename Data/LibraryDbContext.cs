using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<ReturnedUser> ReturnedUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ReceivedUser> ReceivedUsers { get; set; }
        public DbSet<RequestedUser> RequestedUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Book> Books { get; set; }

        public LibraryDbContext()
        {

        }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString)
                .UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration for User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.UserAdNo).IsRequired().HasMaxLength(50);
                entity.Property(e => e.UserEmail).IsRequired().HasMaxLength(100);
                entity.Property(e => e.UserPass).IsRequired().HasMaxLength(100);
            });

            // Configuration for Admin
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminId);
                entity.Property(e => e.AdminName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.AdminEmail).IsRequired().HasMaxLength(100);
                entity.Property(e => e.AdminPass).IsRequired().HasMaxLength(100);
            });

            // Configuration for Book
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId);
                entity.Property(e => e.BookName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.BookAuthor).IsRequired().HasMaxLength(100);
                entity.Property(e => e.BookISBN).IsRequired().HasMaxLength(20);
                entity.Property(e => e.BookPrice).IsRequired();
                entity.Property(e => e.BookCopies).IsRequired();
            });

            // Configuration for ReturnedUser
            modelBuilder.Entity<ReturnedUser>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.UserId });
                entity.HasOne(e => e.User)
                    .WithMany(u => u.ReturnedUsers)
                    .HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Book)
                    .WithMany(b => b.ReturnedUsers)
                    .HasForeignKey(e => e.BookId);
                entity.Property(e => e.BookName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.DateReturned).IsRequired();
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(100);
            });

            // Configuration for ReceivedUser
            modelBuilder.Entity<ReceivedUser>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.UserId });
                entity.HasOne(e => e.User)
                    .WithMany(u => u.ReceivedUsers)
                    .HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Book)
                    .WithMany(b => b.ReceivedUsers)
                    .HasForeignKey(e => e.BookId);
                entity.Property(e => e.BookName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.DateReceived).IsRequired();
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(100);
            });

            // Configuration for RequestedUser
            modelBuilder.Entity<RequestedUser>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.UserId });
                entity.HasOne(e => e.User)
                    .WithMany(u => u.RequestedUsers)
                    .HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Book)
                    .WithMany(b => b.RequestedUsers)
                    .HasForeignKey(e => e.BookId);
                entity.Property(e => e.BookName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.DateRequested).IsRequired();
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    AdminId = 1,
                    AdminName = "admin",
                    AdminEmail = "admin@admin.com",
                    AdminPass = "Admin123@" // Ensure this is hashed in a real application
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
