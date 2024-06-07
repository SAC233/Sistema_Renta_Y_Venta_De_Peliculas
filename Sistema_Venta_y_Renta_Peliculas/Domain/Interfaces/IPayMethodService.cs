using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;

namespace Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces
{
    public interface IPayMethodService
    {
        Task<IEnumerable<PaymentMethod>> GetPayMenthodAsync();
        Task<PaymentMethod> GetPayMethodByIdAsync(Guid id);
        Task<PaymentMethod> CreatePayMethodAsync(PaymentMethod payMeth);
        Task<PaymentMethod> EditPayMethodAsync(PaymentMethod payMeth);
        Task<PaymentMethod> DeletePayMethodAsync(Guid id);
    }
}
