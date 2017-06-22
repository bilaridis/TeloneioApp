using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Models
{
    public partial class CalculatedTax
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassID { get; set; }

        [Required]
        [StringLength(5)]
        public string TypeOfTax { get; set; }

        public decimal? RateOfTax { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Sort { get; set; }

        public virtual Class Class { get; set; }
    }
}
