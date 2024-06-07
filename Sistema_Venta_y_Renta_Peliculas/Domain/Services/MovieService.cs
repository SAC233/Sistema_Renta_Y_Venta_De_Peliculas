using Microsoft.EntityFrameworkCore;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;
using Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces;

namespace Sistema_Venta_y_Renta_Peliculas.Domain.Services
{
    public class MovieService : IMovieService
    {
        private readonly DataBaseContext _context;

        public MovieService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            try
            {
                var movie = await _context.Movies.ToListAsync();

                return movie;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<Movie> GetMovieByIdAsync(Guid id)
        {
            try
            {
                var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

                return movie;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            try
            {
                movie.Id = Guid.NewGuid();
                movie.CreateDate = DateTime.Now;
                _context.Movies.Add(movie);

                await _context.SaveChangesAsync();

                return movie;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Movie> EditMovieAsync(Movie movie)
        {
            try
            {
                movie.ModifiedDate = DateTime.Now;

                _context.Movies.Update(movie);

                await _context.SaveChangesAsync();

                return movie;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Movie> DeleteMovieAsync(Guid id)
        {
            try
            {
                var movie = await GetMovieByIdAsync(id);

                if (movie == null)
                {
                    return null;
                }

                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();

                return movie;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
