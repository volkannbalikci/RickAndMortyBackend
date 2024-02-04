using RickAndMorty.Application.RickAndMortyApi.Models;

namespace RickAndMorty.Application.RickAndMortyApi.Dtos
{
    public class GetCharacterDetailsDto : IRickAndMortyApiDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public string image { get; set; }
        public GetLocationDto origin { get; set; }
        public GetLocationDto location { get; set; }
        public List<GetEpisodeDto> episode { get; set; }

    }

}
