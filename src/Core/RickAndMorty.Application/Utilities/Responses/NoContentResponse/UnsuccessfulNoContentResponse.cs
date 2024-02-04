using RickAndMorty.Application.Utilities.Responses.NoContentResponse.Common;

namespace RickAndMorty.Application.Utilities.Responses.NoContentResponse
{
    public class UnsuccessfulNoContentResponse : NoContentResponseBase
    {
        public UnsuccessfulNoContentResponse(bool isSuccess, string message, string title) : base(false, message, title)
        {
        }

        public UnsuccessfulNoContentResponse(string message) : base(false, message)
        {
        }

        public UnsuccessfulNoContentResponse() : base(false)
        {
        }
    }
}
