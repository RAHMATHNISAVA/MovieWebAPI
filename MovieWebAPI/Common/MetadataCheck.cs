using MovieWebApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Common
{
    public static class MetadataCheck
    {
        public static bool IsValid(this Metadata m)
        {
            return m.Title.HasValue() &&
                   m.Language.HasValue() &&
                   m.Duration.HasValue();
        }

        private static bool HasValue(this string value) => !string.IsNullOrEmpty(value);
    }
}
