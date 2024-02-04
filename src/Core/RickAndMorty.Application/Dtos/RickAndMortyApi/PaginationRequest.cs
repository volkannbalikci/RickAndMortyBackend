using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Dtos.RickAndMortyApi
{
    public class PaginationRequest
    {
        public int Index { get; set; } = 0;
        public int Count { get; set; } = 5;
    }
}
