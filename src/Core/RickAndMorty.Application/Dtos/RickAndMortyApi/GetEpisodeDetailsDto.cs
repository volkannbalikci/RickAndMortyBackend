using RickAndMorty.Application.RickAndMortyApi.Models;

namespace RickAndMorty.Application.RickAndMortyApi.Dtos
{
    public class GetEpisodeDetailsDto : IRickAndMortyApiDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string air_date { get; set; }
        public string episode { get; set; }
        public List<GetCharacterDto> characterDetailsDtoList { get; set; }
        public string url { get; set; }
        public string created { get; set; }
    }

}
