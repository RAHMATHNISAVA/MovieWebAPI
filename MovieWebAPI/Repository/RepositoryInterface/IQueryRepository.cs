using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Repository.RepositoryInterface
{
    public interface IQueryRepository
    {
        public CsvReader GetReader(string path);
        public void SafeClose(CsvReader reader);
    }
}
