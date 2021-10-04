using MovieWebApplication.Model;
using MovieWebApplication.Repository.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Repository
{

    public class MoviesRepository : IMoviesRepository
    {
        private readonly IQueryRepository _queryRepository;

        public MoviesRepository(IQueryRepository QueryRepository)
        {
            _queryRepository = QueryRepository;
        }

        //reding data from given csv file and map them to lookup variable
        public ILookup<int, int> GetStatsLookup()
        {
            using (var reader = _queryRepository.GetReader("SampleData/stats.csv"))
            {
                try
                {
                    var records = reader.GetRecords<WatchData>();
                    return records.ToLookup(s => s.MovieId, s => s.WatchDurationMs);
                }
                finally
                {
                    _queryRepository.SafeClose(reader);
                }

            }
        }
    }
}
