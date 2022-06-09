using Domain.Base.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Basic
{
    public class ApplicationUser : IdentityBaseEntity
    {
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(14)] //The reason being is that International standards can support up to 15 digits
        public string PhoneNumber { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(320)]// {64}@{255} so => 64 + 1 + 255 = 320
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        public string BankAccountNumber { get; set; }
    }
}
