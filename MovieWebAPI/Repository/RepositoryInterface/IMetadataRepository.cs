using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieWebApplication.Model;

namespace MovieWebApplication.Repository.RepositoryInterface
{
   public interface IMetadataRepository
    {
        bool Insert(Metadata metadata);
        Metadata[] GetMetadata();
        Metadata[] GetMetadataFilter();
    }
}
