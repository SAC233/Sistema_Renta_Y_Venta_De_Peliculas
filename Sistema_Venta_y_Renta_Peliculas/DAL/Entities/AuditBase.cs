using System.ComponentModel.DataAnnotations;

namespace Sistema_Venta_y_Renta_Peliculas.DAL.Entities
{
    public class AuditBase
    {
        [Key] //Sígnifica que será PK
        [Required] //Este campo será obligatorio
        public virtual Guid Id { get; set; } //Esta será el PK de todas las tablas
        public virtual DateTime? CreateDate { get; set; } //Para guardar todo registro con su fecha
        public virtual DateTime? ModifiedDate { get; set;} //Para guardar todo registro que se modifica con su fecha
    }
}
