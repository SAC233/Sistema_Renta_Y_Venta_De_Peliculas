using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sistema_Venta_y_Renta_Peliculas.DAL.Entities
{
    public class Payment:AuditBase
    {
        [Display(Name = "Payment Type")]
        [MaxLength(30, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string PaymentType { get; set; }

        [Display(Name = "Time Limit")]
        [MaxLength(30, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public DateTime Term { get; set; }

        //Así es como se relaciona a la tabla Movie con EF Core:
        [Display(Name = "Movie")]
        public Movie? Movie { get; set; }

        //FK Movie
        [Display(Name = "Movie ID")]
        public Guid MovieId { get; set; }

        //Así es como se relaciona a la tabla PaymentMethod con EF Core:
        [Display(Name = "Payment Method")]
        public PaymentMethod? PaymentMethod { get; set; }

        //FK PaymentMethod
        [Display(Name = "Payment Method ID")]
        public Guid PaymentMethodID { get; set; }


    }
}
