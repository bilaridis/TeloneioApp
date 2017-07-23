using System.Data.Entity;
using DomainModel.Models;

namespace DomainModel
{
    public class LocalModel : DbContext
    {
        public LocalModel()
            : base("name=LocalModel")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Tax> Taxes { get; set; }

        public virtual DbSet<Package> Packages { get; set; }

        public virtual DbSet<CalculatedTax> CalculatedTaxes { get; set; }

        public virtual DbSet<Class> Classes { get; set; }

        public virtual DbSet<LoginCustomerDetail> LoginCustomerDetails { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LoginCustomerExtension> LoginCustomerExtensions { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tax>()
                        .Property(e => e.TaxCode)
                        .IsUnicode(false);

            modelBuilder.Entity<Tax>()
                        .Property(e => e.TaxDescr)
                        .IsUnicode(false);

            modelBuilder.Entity<Tax>()
                        .Property(e => e.TaxDescr2)
                        .IsUnicode(false);

            modelBuilder.Entity<CalculatedTax>()
                .Property(e => e.ClassID)
                .IsUnicode(false);

            modelBuilder.Entity<CalculatedTax>()
                .Property(e => e.TypeOfTax)
                .IsUnicode(false);

            modelBuilder.Entity<CalculatedTax>()
                .Property(e => e.RateOfTax)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Class>()
                .Property(e => e.ClassID)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.CalculatedTaxes)
                .WithRequired(e => e.Class)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoginCustomerExtension>()
                .Property(e => e.CreatedYear)
                .IsFixedLength();
        }
    }
}