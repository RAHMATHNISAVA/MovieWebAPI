using System;
using System.Collections.Generic;
using CsvHelper;
using System.Linq;
using System.Threading.Tasks;
using MovieWebApplication.Model;
using MovieWebApplication.Repository.RepositoryInterface;
using System.IO;
using System.Globalization;

namespace MovieWebApplication.Repository
{
    public class MetadataRepository : IMetadataRepository
    {
        private readonly List<Metadata> _database;
        private readonly IQueryRepository _queryRepository;
        private const string MetadataPath = "Data/metadata.csv";
        public MetadataRepository(IQueryRepository QueryRepository)
        {
            _database = new List<Metadata>();
            _queryRepository = QueryRepository;
        }

        //get all metadata
        public Metadata[] GetMetadata()
        {
            using (var reader = _queryRepository.GetReader("SampleData/metadata.csv"))
            {
                try
                {
                    var x = reader.GetRecords<Metadata>();
                    return x.ToArray();
                }
                finally
                {
                    _queryRepository.SafeClose(reader);
                }
            }
        }

        //get all metadata by given criteria
        public Metadata[] GetMetadataFilter()
        {
            var metadata = GetMetadata();
            return metadata
                .GroupBy(m => m.MovieId, m => m)
                .Select(g => g.OrderByDescending(o => o.Id))
                .Select(g => g.FirstOrDefault(f => f.Language == "EN"))
                .ToArray();
        }

        //metadata saved to given list
        public bool Insert(Metadata metadata)
        {
            _database.Add(metadata);
            return true;
        }

          

    }
}
