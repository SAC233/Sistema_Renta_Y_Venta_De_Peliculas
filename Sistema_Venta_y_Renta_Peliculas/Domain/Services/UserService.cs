using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;
using Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces;

namespace Sistema_Venta_y_Renta_Peliculas.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly DataBaseContext _context;

        public UserService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                var user = await _context.Users.ToListAsync();

                return user;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<User> GetUserByIdAsync(Guid Id)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                user.Id = Guid.NewGuid();
                user.CreateDate = DateTime.Now;
                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                return user;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            try
            {
                user.ModifiedDate = DateTime.Now;

                _context.Users.Update(user);

                await _context.SaveChangesAsync();

                return user;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<User> DeleteUserAsync(Guid Id)
        {
            try
            {
                var user = await GetUserByIdAsync(Id);

                if (user == null)
                {
                    return null;
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}