using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Sistema_Venta_y_Renta_Peliculas.DAL.Entities
{
    public class PaymentMethod:AuditBase
    {
        [Display(Name = "Card Number")]
        [MaxLength(20, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string CardNumber { get; set; }

        [Display(Name = "Expiration Date")]
        [MaxLength(20, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Security Code")]
        [MaxLength(20, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string SecurityCode { get; set; }

        [Display(Name = "Card Holder Name")]
        [MaxLength(40, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string CardHolderName { get; set; }

        [Display(Name = "Holder Address")]
        [MaxLength(60, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string Address { get; set;}

        [Display(Name = "Postal Code")]
        [MaxLength(30, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string PostalCode { get; set; }

        //Así es como se relaciona 2 tablas con EF Core:
        [Display(Name = "User")]
        public User? User { get; set; }

        //FK
        [Display(Name = "User ID")]
        public Guid CountryId { get; set; }


    }
}
