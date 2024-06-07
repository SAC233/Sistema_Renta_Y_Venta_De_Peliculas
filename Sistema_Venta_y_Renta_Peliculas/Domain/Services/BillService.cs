using Microsoft.EntityFrameworkCore;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;
using Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces;

namespace Sistema_Venta_y_Renta_Peliculas.Domain.Services
{
    public class BillService : IBillService
    {
        private readonly DataBaseContext _context;

        public BillService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bill>> GetBillAsync()
        {
            try
            {
                var bill = await _context.Bills.ToListAsync();

                return bill;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<Bill> GetBillByIdAsync(Guid id)
        {
            try
            {
                var bill = await _context.Bills.FirstOrDefaultAsync(b => b.Id == id);

                return bill;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Bill> CreateBillAsync(Bill bill)
        {
            try
            {
                bill.Id = Guid.NewGuid();
                bill.CreateDate = DateTime.Now;
                _context.Bills.Add(bill);

                await _context.SaveChangesAsync();

                return bill;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
