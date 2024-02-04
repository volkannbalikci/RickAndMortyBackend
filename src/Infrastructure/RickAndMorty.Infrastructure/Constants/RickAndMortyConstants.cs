using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Infrastructure.Constants
{
    public static class RickAndMortyConstants
    {
        public const string RickAndMortyBaseApiUrlString = "https://rickandmortyapi.com/api";
        public const string Episode = "episode";
        public const string Character = "character";
        public const string Location = "location";

        public static string PageIndexEquals(int pageIndex) => $"?page={pageIndex + 1}";

    }
}
