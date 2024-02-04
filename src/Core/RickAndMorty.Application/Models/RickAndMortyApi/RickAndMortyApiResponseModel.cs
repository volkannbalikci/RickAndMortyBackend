using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.RickAndMortyApi.Models
{
    public class RickAndMortyApiResponseModel<TModel>
        where TModel : IRickAndMortyApiDto
    {
        public RickAndMortyApiInfoModel info { get; set; }
        public List<TModel> results { get; set; }
    }
}
