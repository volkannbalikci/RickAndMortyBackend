using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Utilities.Responses.Common
{
    public interface IContentResponse<TData> : IResponse
    {
        TData Data { get; }
    }
}
