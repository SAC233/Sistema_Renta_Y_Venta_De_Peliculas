using Microsoft.AspNetCore.Identity;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;

namespace Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid Id);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(Guid Id);
    }
}