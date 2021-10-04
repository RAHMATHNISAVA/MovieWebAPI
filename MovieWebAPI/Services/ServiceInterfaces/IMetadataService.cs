using MovieWebApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Services.ServiceInterface
{
   public interface IMetadataService
    {
        Metadata[] Get(int movieId);
        bool Post(Metadata metadata);
    }
}
