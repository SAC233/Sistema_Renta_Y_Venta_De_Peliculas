using Microsoft.AspNetCore.Mvc;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;
using Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces;
using Sistema_Venta_y_Renta_Peliculas.Domain.Services;

namespace Sistema_Venta_y_Renta_Peliculas.Controllers
{
    [Route("api/[controller]")] //Listo pero necesito poner en role o Customer o Admin 
    [ApiController]
    public class UsersController : Controller
    {

        private readonly IUserService _userService;
        
        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
        {
            var user = await _userService.GetUsersAsync(); 

            if (user == null || !user.Any())
            {
                return NotFound();
            }
            return Ok(user); 
        }

        //GET POR ID
        [HttpGet, ActionName("Get")] 
        [Route("GetById/{id}")] 
        public async Task<ActionResult<User>> GetUserByIdAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id); 

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user); 
        }


        //CREATE
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<User>> AddUserAsync(User user)
        {
            try
            {
                var newUser = await _userService.AddUserAsync(user);
                if (newUser == null) return NotFound();//Validamos tambien que no sea nuleable
                return Ok(newUser);
            }
            catch (Exception ex) //validamos duplicidad en la excepciones
            {
                if (ex.Message.Contains("duplicate"))//Si dentro de la excepcion tengo un "Duplicate"
                    return Conflict(String.Format("{0} ya existe", user.UserName));
                return Conflict(ex.Message);

            }
        }


        //EDIT
        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<User>> UpdateUserAsync(User user)
        {
            try
            {
                var editedUser = await _userService.UpdateUserAsync(user);
                if (editedUser == null) return NotFound();
                return Ok(editedUser);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))//Si dentro de la excepcion tengo un "Duplicate"
                    return Conflict(String.Format("{0} ya existe", user.UserName));
                return Conflict(ex.Message);

            }
        }


        //DELETE
        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<User>> DeleteUserAsync(Guid Id)
        {

            if (Id == Guid.Empty) return BadRequest();

            var deletedUser = await _userService.DeleteUserAsync(Id);
            if (deletedUser == null) return NotFound();
            return Ok(deletedUser);

        }
    }
}