using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace Sistema_Venta_y_Renta_Peliculas.DAL.Entities
{
    public class DataBaseContext:DbContext
    {
        //Constructor para conectarse a la base de datos
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) 
        {
            
        }

        //Este método que es propio de EF CORE que sirve para configurar las relaciones entre las tablas en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // una relación uno a muchos entre User y paymentMethods, donde un User puede tener múltiples paymentMethods,
            // y cada paymentMethods está asociado con un User a través de la clave externa UserId.
            modelBuilder.Entity<User>()
               .HasMany(u => u.paymentMethods)
               .WithOne(p => p.User)
               .HasForeignKey(p => p.UserId);

            //una relación uno a muchos entre User y bills, donde un User puede tener múltiples bills,
            //y cada bills está asociado con un User a través de la clave externa UserId.
            modelBuilder.Entity<User>()
                .HasMany(u => u.Bills)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.userID);

            //una relación uno a muchos entre Movie y pays, donde una Movie puede tener múltiples pays,
            //y cada pays está asociado con una Movie a través de la clave externa MovieId.
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Payments)
                .WithOne(p => p.Movie)
                .HasForeignKey(p => p.MovieId);

            //una relación uno a muchos entre PaymentMethod y Payment, donde un PaymentMethod puede tener múltiples payments,
            //y cada payment está asociado con un PaymentMethod a través de la clave externa PaymentMethodID.
            // Además no se permite eliminar un PaymentMethod si existen pays asociados a él. Es decir,
            //si intentas eliminar un PaymentMethod que tiene pagos (payments) relacionados, la operación fallará.
            modelBuilder.Entity<PaymentMethod>()
               .HasMany(pm => pm.Payments)
               .WithOne(p => p.PaymentMethod)
               .HasForeignKey(p => p.PaymentMethodID)
               .OnDelete(DeleteBehavior.Restrict);

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
