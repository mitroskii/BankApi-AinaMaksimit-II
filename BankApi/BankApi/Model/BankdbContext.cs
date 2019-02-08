using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BankApi.Model
{
    public partial class BankdbContext : DbContext
    {
        public BankdbContext()
        {
        }

        public BankdbContext(DbContextOptions<BankdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.IBAN).ValueGeneratedNever();

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_Account_Bank");

                entity.HasOne(d => d.BankNavigation)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Account_Customer");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Customer_Bank");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasOne(d => d.IBANNavigation)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.IBAN)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Transaction_Account");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}