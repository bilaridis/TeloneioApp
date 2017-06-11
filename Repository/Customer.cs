using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        [StringLength(50)]
        public string EORI_TIN { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}