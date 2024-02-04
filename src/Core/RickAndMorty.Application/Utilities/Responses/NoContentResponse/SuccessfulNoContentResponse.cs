using RickAndMorty.Application.Utilities.Responses.Common;
using RickAndMorty.Application.Utilities.Responses.NoContentResponse.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Utilities.Responses.NoContentResponse
{
    public class SuccessfulNoContentResponse : NoContentResponseBase
    {
        public SuccessfulNoContentResponse(bool isSuccess, string message, string title) : base(true, message, title)
        {
        }

        public SuccessfulNoContentResponse(string message) : base(true, message)
        {
        }

        public SuccessfulNoContentResponse() : base(true)
        {
        }
    }

}
