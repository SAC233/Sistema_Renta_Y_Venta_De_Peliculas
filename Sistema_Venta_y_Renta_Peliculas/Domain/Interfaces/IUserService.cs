using Microsoft.AspNetCore.Identity;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;

namespace Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(Guid Id);
        Task CheckRoleAsync(string roleName);//Verifica que el rol existe
        Task AddUserToRoleAsync(User user, string roleName);//Para agregarlo al rol
        Task<bool> IsUserInRoleAsync(User user, string roleName);//Para ver que este en el rol asignado
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(Guid Id);
    }
}
