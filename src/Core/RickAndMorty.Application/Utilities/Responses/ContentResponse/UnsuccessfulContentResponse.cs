using RickAndMorty.Application.Utilities.Responses.ContentResponse.Common;

namespace RickAndMorty.Application.Utilities.Responses.ContentResponse
{
    public class UnsuccessfulContentResponse<TData> : ContentResponseBase<TData>
    {
        public UnsuccessfulContentResponse(TData data, string message, string title) : base(false, data, message, title)
        {
        }

        public UnsuccessfulContentResponse(string message, string title) : base(false, message, title)
        {
        }

        public UnsuccessfulContentResponse(TData data, string message) : base(false, data)
        {
        }

        public UnsuccessfulContentResponse(string message) : base(false, message)
        {
        }

        public UnsuccessfulContentResponse(TData data) : base(false, data)
        {
        }

        public UnsuccessfulContentResponse() : base(false)
        {
        }
    }
}
