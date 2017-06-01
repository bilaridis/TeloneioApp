namespace TeloneioApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tax
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string TaxCode { get; set; }

        public string TaxDescr { get; set; }

        public string TaxDescr2 { get; set; }
    }
}
