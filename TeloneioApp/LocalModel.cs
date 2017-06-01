namespace TeloneioApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LocalModel : DbContext
    {
        public LocalModel()
            : base("name=LocalModel")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }

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
        }
    }
}
