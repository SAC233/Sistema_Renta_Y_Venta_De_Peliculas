using Sistema_Venta_y_Renta_Peliculas.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Venta_y_Renta_Peliculas.DAL.Entities
{
    public class Movie : AuditBase //Crear herencia con AuditBase
    {
        [Display(Name = "Name of the Movie")]
        [MaxLength(80, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string MovieName { get; set; } //Nombre película

        [Display(Name = "synopsis of the Movie")]
        [MaxLength(400, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        public string? MovieDescription { get; set;} //Descripción de la película

        [Display(Name = "Movie Cast")]
        [MaxLength(1000, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string MovieCast { get; set; } //Elenco de la película

        [Display(Name = "Movie Director")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string MovieDirector { get; set; } //Director de la película

        [Display(Name = "Movie Duration")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string MovieDuration { get; set; } //Duración de la película

        [Display(Name = "Purchase Cost")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        public float? PurchaseCost { get; set; } //Costo de compra

        [Display(Name = "Rental Cost")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        public float? RentalCost { get; set; } //Costo de Renta

        [Display(Name = "Type of Service", Description = "Indicates whether the movie is rented or purchased")]
        [MaxLength(10, ErrorMessage = "The field {0}  must have a maximum of {1} characters")]
        [EnumDataType(typeof(ServiceTypes))]
        public string? Service { get; set; } //Tipo de servicio adquirido por la película (Alquiler ó Compra)

        [Display(Name = "Payments")]
        public ICollection<Payment>? Payments { get; set; }
    }
}
