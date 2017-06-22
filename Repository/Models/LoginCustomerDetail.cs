using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Models
{
    public partial class LoginCustomerDetail
    {
        public int Id { get; set; }

        [Required]
        public string GUID { get; set; }

        public string Email { get; set; }

        public string LoginUserName { get; set; }

        public string LoginPassword { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        [StringLength(50)]
        public string EORI_TIN { get; set; }

        public DateTime? ExpirationOfSubscription { get; set; }

        public DateTime? InstallationOfSubscription { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? IsBetaUser { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsSelected { get; set; }
    }
}
