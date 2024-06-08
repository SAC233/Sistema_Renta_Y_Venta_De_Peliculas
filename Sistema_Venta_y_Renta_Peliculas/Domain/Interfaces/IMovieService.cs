using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;

namespace Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces
{
    public interface IMovieService

    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieByIdAsync(Guid id);
        Task<Movie> CreateMovieAsync(Movie movie);
        Task<Movie> EditMovieAsync(Movie movie);
        Task<Movie> DeleteMovieAsync(Guid id);
    }
}
