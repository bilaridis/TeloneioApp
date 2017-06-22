using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Models
{
    public partial class Class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class()
        {
            CalculatedTaxes = new HashSet<CalculatedTax>();
        }

        [StringLength(50)]
        public string ClassID { get; set; }

        public string Description { get; set; }

        public int TARICCODE { get; set; }

        public int TARFIRSTADDCODE { get; set; }

        public int TARSECONDADDCODE { get; set; }

        public int NATADDCODE { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Sort { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CalculatedTax> CalculatedTaxes { get; set; }
    }
}
