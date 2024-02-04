using RickAndMorty.Application.Utilities.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Utilities.Responses.NoContentResponse.Common
{
    public class NoContentResponseBase : INoContentResponse
    {
        public bool IsSuccess { get; }

        public string Title { get; }

        public string Message { get; }

        public NoContentResponseBase(bool isSuccess, string message, string title) : this(isSuccess, message)
        {
            Title = title;
        }

        public NoContentResponseBase(bool isSuccess, string message) : this(isSuccess)
        {
            Message = message;
        }

        public NoContentResponseBase(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
