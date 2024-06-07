using Microsoft.EntityFrameworkCore;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;
using Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces;

namespace Sistema_Venta_y_Renta_Peliculas.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly DataBaseContext _context;

        public PaymentService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetPaymentAsync()
        {
            try
            {
                var payment = await _context.Payments.ToListAsync();

                return payment;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<Payment> GetPaymentByIdAsync(Guid id)
        {
            try
            {
                var payment = await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);

                return payment;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            try
            {
                payment.Id = Guid.NewGuid();
                payment.CreateDate = DateTime.Now;
                _context.Payments.Add(payment);

                await _context.SaveChangesAsync();

                return payment;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Payment> EditPaymentAsync(Payment payment)
        {
            try
            {
                payment.ModifiedDate = DateTime.Now;

                _context.Payments.Update(payment);

                await _context.SaveChangesAsync();

                return payment;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Payment> DeletePaymentAsync(Guid id)
        {
            try
            {
                var payment = await GetPaymentByIdAsync(id);

                if (payment == null)
                {
                    return null;
                }

                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();

                return payment;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
