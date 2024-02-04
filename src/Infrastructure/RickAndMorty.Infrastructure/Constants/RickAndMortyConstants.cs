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


        public const string ErrorTitle = "Hata";
        public const string SuccessfulTitle = "Başarılı";
        public const string InformationTitle = "Bilgi";
        public const string WarningTitle = "Dikkat";

        public const string CharactersListedMessage = "Karakterler Listelendi";
        public const string EpisodesListedMessage = "Bölümler Listelendi";
        public const string LocationsListedMessage = "Konumlar Listelendi";


    }
}
