namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Package
    {
        public int Id { get; set; }

        public string PackageId { get; set; }

        public string PackageDescr { get; set; }
    }
}
