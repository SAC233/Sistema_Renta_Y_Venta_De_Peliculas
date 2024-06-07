using Microsoft.EntityFrameworkCore;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;
using Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces;

namespace Sistema_Venta_y_Renta_Peliculas.Domain.Services
{
    public class PayMethodService : IPayMethodService
    {
        private readonly DataBaseContext _context;

        public PayMethodService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentMethod>> GetPayMenthodAsync()
        {
            try
            {
                var payMethod = await _context.PaymentMethods.ToListAsync();

                return payMethod;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<PaymentMethod> GetPayMethodByIdAsync(Guid id)
        {
            try
            {
                var payMethod = await _context.PaymentMethods.FirstOrDefaultAsync(pm => pm.Id == id);

                return payMethod;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<PaymentMethod> CreatePayMethodAsync(PaymentMethod payMeth)
        {
            try
            {
                payMeth.Id = Guid.NewGuid();
                payMeth.CreateDate = DateTime.Now;
                _context.PaymentMethods.Add(payMeth);

                await _context.SaveChangesAsync();

                return payMeth;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<PaymentMethod> EditPayMethodAsync(PaymentMethod payMeth)
        {
            try
            {
                payMeth.ModifiedDate = DateTime.Now;

                _context.PaymentMethods.Update(payMeth);

                await _context.SaveChangesAsync();

                return payMeth;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<PaymentMethod> DeletePayMethodAsync(Guid id)
        {
            try
            {
                var payMeth = await GetPayMethodByIdAsync(id);

                if (payMeth == null)
                {
                    return null;
                }

                _context.PaymentMethods.Remove(payMeth);
                await _context.SaveChangesAsync();

                return payMeth;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
