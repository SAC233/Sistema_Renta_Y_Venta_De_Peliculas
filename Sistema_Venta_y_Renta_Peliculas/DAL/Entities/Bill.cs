using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Sistema_Venta_y_Renta_Peliculas.DAL.Entities
{
    public class Bill:AuditBase
    {
        [Display(Name = "Holder Full Name")]
        [MaxLength(30, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string FullName { get; set; } //Nombre Completo del Usuario

        [Display(Name = "Holder Email")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string Email { get; set; } //Correo electrónico del usuario

        [Display(Name = "Product Name")]
        [MaxLength(20, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string Product { get; set; } //Nombre del Producto

        //[Display(Name = "Bill Date")]
        //[Required(ErrorMessage = "Field {0} must be required")]
        //public DateTime Date { get; set; } //Fecha de la fáctura

        [Display(Name = "Service Type")]
        [MaxLength(20, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string Service { get; set; } //Tipo de servicio de la película (Alquilada ó Comprada)


        [Display(Name = "Total Cost")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public float TotalCost { get; set; } //Costo total

        [Display(Name = "Payment Term")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string PaymentTerm { get; set; } //Término de pago

        [Display(Name = "Payment Method")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string paymentMethod { get; set; } //Método de pago usado



        //Así es como se relaciona a la tabla User con EF Core:
        [JsonIgnore]
        [Display(Name = "USER")]
        public User? User { get; set; }

        //FK User
        //[JsonIgnore]
        [Display(Name = "USER ID")]
        public Guid userID { get; set; }


        //Así es como se relaciona a la tabla Pay con EF Core:
        [JsonIgnore]
        [Display(Name = "Payment")]
        public Payment? Payment { get; set; }

        //FK User
        //[JsonIgnore]
        [Display(Name = "Payment Id")]
        public Guid PaymentID { get; set; }
    }
}
