using Microsoft.AspNetCore.Mvc;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;
using Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces;

namespace Sistema_Venta_y_Renta_Peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {

        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesAsync()
        {
            var movies = await _movieService.GetMoviesAsync(); //Esta llamando el metodo GetMoviesAsync y se guarda en la variable movies

            if (movies == null || !movies.Any())
            {
                return NotFound();//Que retorne un 404 si es nulo o si esta vacio con el Any negado, Any: para ver si al menos hay 1 elemento
            }
            return Ok(movies); //En caso de que si tenga peliculas me retorna un 200 y la lista de paises
        }


        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Movie>> GetMoviesByIdAsync(Guid id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id); //Esta llamando el metodo GetMovieByIdAsync y se guarda en la variable movies

            if (movie == null) //Aqui el any no funciona por que es para listas, colecciones y arreglos, y en este caso es solo 1 elemento el que me trae
            {
                return NotFound();//Estatus Code "NotFound": 404, Que retorne un 404 si es nulo o si esta vacio con el Any negado, Any: para ver si al menos hay 1 elemento
            }
            return Ok(movie); //Estatus Code "Ok": 200, En caso de que si tenga peliculas me retorna un 200 y la pelicula
        }


        //CREATE
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Movie>> CreateMovieAsync(Movie movie)
        {
            try
            {
                var newMovie = await _movieService.CreateMovieAsync(movie);
                if (newMovie == null) return NotFound();//Validamos tambien que no sea nuleable
                return Ok(newMovie);
            }
            catch (Exception ex) //validamos duplicidad en la excepciones
            {
                if (ex.Message.Contains("duplicate"))//Si dentro de la excepcion tengo un "Duplicate"
                    return Conflict(String.Format("{0} ya existe", movie.MovieName));
                return Conflict(ex.Message);

            }
        }


        //EDIT
        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Movie>> EditMovieAsync(Movie movie)
        {
            try
            {
                var editedMovie = await _movieService.EditMovieAsync(movie);
                if (editedMovie == null) return NotFound();
                return Ok(editedMovie);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))//Si dentro de la excepcion tengo un "Duplicate"
                    return Conflict(String.Format("{0} ya existe", movie.MovieName));
                return Conflict(ex.Message);

            }
        }


        //DELETE
        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Movie>> DeleteMovieAsync(Guid id)
        {

            if (id == null) return BadRequest();

            var deletedMovie = await _movieService.DeleteMovieAsync(id);
            if (deletedMovie == null) return NotFound();
            return Ok(deletedMovie);

        }
    }
}