using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;

namespace Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces
{
    public interface IBillService
    {
        Task<IEnumerable<Bill>> GetBillAsync();
        Task<Bill> GetBillByIdAsync(Guid id);
        Task<Bill> CreateBillAsync(Bill bill);

        //una factura no se puede ni editar ni eliminar
    }
}
