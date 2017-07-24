namespace DomainModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoginCustomerExtension")]
    public partial class LoginCustomerExtension
    {
        public int Id { get; set; }

        public int CustomerID { get; set; }

        public int LRNCounter { get; set; }

        public int MessageCounter { get; set; }

        [StringLength(2)]
        public string CreatedYear { get; set; }
    }
}
