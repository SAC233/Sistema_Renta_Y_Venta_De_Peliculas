using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Sistema_Venta_y_Renta_Peliculas.DAL.Entities
{
    public class Payment:AuditBase
    {
        [Display(Name = "Payment Type")]
        [MaxLength(30, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string PaymentType { get; set; } //Tipo de pago

        [Display(Name = "Time Limit")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public DateTime Term { get; set; } //Plazo de la película

        //Así es como se relaciona a la tabla Movie con EF Core:
        [JsonIgnore]
        [Display(Name = "Movie")]
        public Movie? Movie { get; set; }

        //FK Movie
        [Display(Name = "Movie ID")]
        public Guid MovieId { get; set; }

        //Así es como se relaciona a la tabla PaymentMethod con EF Core:
        [JsonIgnore]
        [Display(Name = "Payment Method")]
        public PaymentMethod? PaymentMethod { get; set; } 

        //FK PaymentMethod
        [Display(Name = "Payment Method ID")]
        public Guid PaymentMethodID { get; set; } //Id Método de Pago

    }
}
