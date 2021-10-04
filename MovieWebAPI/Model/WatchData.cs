using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using CsvHelper.Configuration.Attributes;

namespace MovieWebApplication.Model
{
    public class WatchData
    {
        [Name("movieId")]
        public int MovieId { get; set; }
        [Name("watchDurationMs")]
        public int WatchDurationMs { get; set; }
    }
}
