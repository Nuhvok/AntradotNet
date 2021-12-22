using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<IEnumerable<MovieCardResponseModel>> GetHighestGrossingMovies()
        {
            // call my MovieRepository and get the data
            var movies = await _movieRepository.Get30HighestGrossingMovies();
            // 3rd party Automapper from Nuget
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(
                    new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title }
                    );
            }

            return movieCards;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetailsById(int movieId, int userId)
        {
            var movie = await _movieRepository.GetById(movieId);

            // map movie entity into Movie Details Model
            // Automapper that can be used for mapping one object to another object

            var movieDetails = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
                Title = movie.Title,
                OriginalLanguage = movie.OriginalLanguage,
                Overview = movie.Overview,
                Rating = movie.Rating,
                Tagline = movie.Tagline,
                RunTime = movie.RunTime,
                BackdropUrl = movie.BackdropUrl,
                TmdbUrl = movie.TmdbUrl,
                ImdbUrl = movie.ImdbUrl,
                Price = movie.Price,
                ReleaseDate = movie.ReleaseDate,
                Budget = movie.Budget,
                Revenue = movie.Revenue

            };

            foreach (var movieCast in movie.CastOfMovie)
            {
                movieDetails.Casts.Add(new CastResponseModel
                {

                    Id = movieCast.CastId,
                    Character = movieCast.Character,
                    Name = movieCast.Cast.Name,
                    PosterUrl = movieCast.Cast.ProfilePath
                });
            }

            foreach (var trailer in movie.Trailers)
            {
                movieDetails.Trailers.Add(new TrailerResponseModel
                {
                    Id = trailer.Id,
                    MovieId = trailer.Id,
                    Name = trailer.Name,
                    TrailerUrl = trailer.TrailerUrl
                });
            }

            foreach (var movieGenres in movie.GenreOfMovie)
            {
                movieDetails.Genres.Add(new GenreModel { Id = movieGenres.GenreId, Name = movieGenres.Genre.Name });
            }

            //if(context)

            return movieDetails;
        }
    }
}
