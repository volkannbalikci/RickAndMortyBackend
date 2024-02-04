using RickAndMorty.Application.RickAndMortyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.RickAndMortyApi.Dtos
{
    public class GetLocationDetailsDto : IRickAndMortyApiDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string dimension { get; set; }
        public string url { get; set; }
        public string created { get; set; }
        public List<GetCharacterDto> character { get; set; }
    }
}
