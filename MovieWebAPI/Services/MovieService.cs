using MovieWebApplication.Model;
using MovieWebApplication.Repository.RepositoryInterface;
using MovieWebApplication.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMetadataRepository _metadata;
        private readonly IMoviesRepository _moviedata;


        public MovieService(IMetadataRepository metadata, IMoviesRepository moviedata)
        {
            _metadata = metadata;
            _moviedata = moviedata;
        }
        public Statsdata[] Get()
        {
            try
            {
                /// getting  grouped metadata with english title
                var metadata = _metadata.GetMetadataFilter();

                var lookup = _moviedata.GetStatsLookup();

                return GetStats(metadata, lookup)
                    .OrderByDescending(x => x.Watches)
                    .ThenByDescending(x => x.ReleaseYear)
                    .ToArray();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //getting metdata value corresponding to each value in watch csv file
        private static IEnumerable<Statsdata> GetStats(Metadata[] movies, ILookup<int, int> statsLookup)
        {
                foreach (var movie in movies)
                {
                    var (watches, averageDuration) = GetWatchStats(statsLookup, movie.MovieId);
                    yield return new Statsdata
                    {
                        MovieId = movie.MovieId,
                        Title = movie.Title,
                        AverageWatchDurationS = averageDuration,
                        Watches = watches,
                        ReleaseYear = movie.ReleaseYear,
                    };
                }


        }

        //finding avg watch time for given set of movie id
        private static (int watches, int averageDuration) GetWatchStats(ILookup<int, int> statsLookup, int movieId)
        {
            try
            {
                var averageDuration = (int)statsLookup[movieId].Average() / 1000;
                return (statsLookup[movieId].Count(), averageDuration);
            }
                        catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
