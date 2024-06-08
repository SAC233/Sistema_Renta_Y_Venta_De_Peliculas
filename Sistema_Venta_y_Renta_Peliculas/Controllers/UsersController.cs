using Microsoft.AspNetCore.Mvc;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;
using Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces;
using Sistema_Venta_y_Renta_Peliculas.Domain.Services;

namespace Sistema_Venta_y_Renta_Peliculas.Controllers
{
    [Route("api/[controller]")] //Esta es el nombre inicial de mi RUTA, URL o PATH
    [ApiController]//por que no es un controlador de tipo API
    public class UsersController : Controller
    {

        private readonly IUserService _userService; //me conecto a la interfaz, pero nunca al servicio, por temas de seguridad no se puede acceder directamente
        public UsersController(IUserService userService) //Este constructor se parametriza o sobrecarga con la dependendicia que se esta inyectando, parta poder y utilizar los metodos que hay alli
        {
            _userService = userService;
        }

 
        //GET POR ID
        [HttpGet, ActionName("Get")] //ActionName: Datanotation del nombre con el que quiero complementar para la ruta
        [Route("GetById/{id}")] //URL: api/.....,Datanotation
        public async Task<ActionResult<User>> GetUserByIdAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id); //Esta llamando el metodo GetMovieByIdAsync y se guarda en la variable movies

            if (user == null) //Aqui el any no funciona por que es para listas, colecciones y arreglos, y en este caso es solo 1 elemento el que me trae
            {
                return NotFound();//Estatus Code "NotFound": 404, Que retorne un 404 si es nulo o si esta vacio con el Any negado, Any: para ver si al menos hay 1 elemento
            }
            return Ok(user); //Estatus Code "Ok": 200, En caso de que si tenga peliculas me retorna un 200 y la pelicula
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

            if (Id == Guid.Empty) return BadRequest();//No entendi este

            var deletedUser = await _userService.DeleteUserAsync(Id);
            if (deletedUser == null) return NotFound();
            return Ok(deletedUser);

        }

        //CheckRole
        [HttpGet, ActionName("CheckRole")]
        [Route("CheckRole/{roleName}")]
        public async Task<ActionResult> CheckRoleAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return BadRequest();

            await _userService.CheckRoleAsync(roleName);
            return Ok();
        }


        //Si necesito pedir datos esto es lo que debo hacer
        //AddUserToRole
        [HttpPost, ActionName("AddUserToRole")]
        [Route("AddUserToRole/{roleName}")]
        public async Task<ActionResult> AddUserToRoleAsync([FromBody] User user, string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return BadRequest();//No entendi este

            await _userService.AddUserToRoleAsync(user, roleName);
            return Ok();
        }

        //IsUserInRole
        [HttpPost, ActionName("IsUserInRole")]
        [Route("IsUserInRole/{roleName}")]
        public async Task<ActionResult> IsUserInRoleAsync([FromBody] User user, string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return BadRequest();//No entendi este

            bool response = await _userService.IsUserInRoleAsync(user, roleName);
            return Ok(response);
        }
    }
}
