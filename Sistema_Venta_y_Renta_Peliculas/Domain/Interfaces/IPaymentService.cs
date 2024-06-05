using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;

namespace Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetPaymentAsync();
        Task<Payment> GetPaymentByIdAsync(Guid id);
        Task<Payment> CreatePaymentAsync(Payment payment);
        Task<Payment> EditPaymentAsync(Payment payment);
        Task<Payment> DeletePaymentAsync(Guid id);
    }
}
