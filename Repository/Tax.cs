using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Tax
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string TaxCode { get; set; }

        public string TaxDescr { get; set; }

        public string TaxDescr2 { get; set; }
    }
}