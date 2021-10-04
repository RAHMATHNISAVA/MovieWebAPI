using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Repository.RepositoryInterface
{
   public interface IMoviesRepository
    {
        ILookup<int, int> GetStatsLookup();
    }
}
