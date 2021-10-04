using MovieWebApplication.Common;
using MovieWebApplication.Model;
using MovieWebApplication.Repository.RepositoryInterface;
using MovieWebApplication.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieWebApplication.Services
{
    public class MetadataService : IMetadataService
    {
       // private readonly IQueryRepository _query;
        private readonly IMetadataRepository _context;

        public MetadataService(//IQueryRepository query,
            IMetadataRepository context)
        {
            //_query = query;
            _context = context;
        }

        //save metadat to given list
        public bool Post(Metadata metadata)
        {
            try
            {
                return _context.Insert(metadata);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //get metadata by given id
        public Metadata[] Get(int movieId)
        {
            try
            {
                var allMetadata = _context.GetMetadata();
                var movies = GetById(allMetadata, movieId);
                //if (!movies.Any()) throw new Exception("No movies found by that Id");
                return movies;

            }
            catch(Exception ex)
            {
                throw ex;
            }


        }

        // Filter the metadata by movieId, grouping by language, selecting the highest id and ordering by language 
        private static Metadata[] GetById(IEnumerable<Metadata> metadata, int movieId)
        {
            try
            {
                return metadata
                    .Where(m => m.MovieId == movieId && m.IsValid())
                    .GroupBy(m => m.Language, m => m)
                    .Select(g => g.OrderByDescending(m => m.Id).FirstOrDefault())
                    .OrderBy(m => m?.Language)
                    .ToArray();
            }

             catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

