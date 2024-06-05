using Sistema_Venta_y_Renta_Peliculas.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Sistema_Venta_y_Renta_Peliculas.DAL.Entities
{
    public class User:AuditBase //Crear herencia con AuditBase
    {
        [Display(Name = "User Name")]
        [MaxLength(20, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string UserName { get; set; } //Nombre del Usuario

        [Display(Name = "User Last Name")]
        [MaxLength(20, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string UserLastName { get; set; } //Apellido del Usuario

        [Display(Name = "Email Address")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string UserEmailAddress { get; set; } //Correo del Usuario

        [Display(Name = "Password")]
        [MaxLength(20, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        [Required(ErrorMessage = "Field {0} must be required")]
        public string UserPassword{ get; set; } //Contraseña del Usuario

        [Display(Name = "User Likes")]
        [MaxLength(700, ErrorMessage = "The field {0} must have a maximum of {1} characters")]
        public string? UserLikes { get; set; } //Gustos del Usuario

        [Display(Name = "Type of Role", Description = "Indicates whether the role is Administrator or Customer")]
        [MaxLength(10, ErrorMessage = "The field {0}  must have a maximum of {1} characters")]
        [EnumDataType(typeof(RoleTypes))]
        public string UserRole { get; set;} //Tipo de rol del Usuario

        [Display(Name = "Bills")]
        public ICollection<Bill>? Bills { get; set; }
    }
}
