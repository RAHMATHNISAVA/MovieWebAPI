using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieWebApplication.Model;

namespace MovieWebApplication.Services.ServiceInterface
{
   public interface IMovieService
   {
        Statsdata[] Get();
    }
}
