namespace DomainModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Language
    {
        public int Id { get; set; }

        public string LanguageId { get; set; }

        public string LanguageDescr { get; set; }
    }
}
