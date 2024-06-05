using Microsoft.EntityFrameworkCore;

namespace Sistema_Venta_y_Renta_Peliculas.DAL.Entities
{
    public class DataBaseContext:DbContext
    {
        //Constructor para conectarse a la base de datos
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) 
        {
            
        }

        #region DbSets

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Bill> Bills { get; set; }
        #endregion



    }
}
