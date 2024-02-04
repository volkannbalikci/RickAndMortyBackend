using RickAndMorty.Application.Utilities.Responses.ContentResponse.Common;
using RickAndMorty.Application.Utilities.Responses.NoContentResponse.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Utilities.Responses.ContentResponse
{
    public class SuccessfulContentResponse<TData> : ContentResponseBase<TData>
    {
        public SuccessfulContentResponse(TData data, string message, string title) : base(true, data, message, title)
        {
        }

        public SuccessfulContentResponse(TData data, string message) : base(true, data)
        {
        }

        public SuccessfulContentResponse(TData data) : base(true, data)
        {
        }
    }
}
