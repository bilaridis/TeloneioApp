using System.Data.Entity;

namespace Repository
{
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
