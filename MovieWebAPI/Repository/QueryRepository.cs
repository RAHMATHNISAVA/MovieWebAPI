using CsvHelper;
using MovieWebApplication.Repository.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Repository
{
    public class QueryRepository : IQueryRepository
    {
        public CsvReader GetReader(string path)
        {
            //reding csv file from given location
                return new CsvReader(new StreamReader(path), CultureInfo.InvariantCulture);
        }

        public void SafeClose(CsvReader reader)
        {
            //closing file after read
                if (reader is null) return;
                reader.Dispose();
        }
    }
}
