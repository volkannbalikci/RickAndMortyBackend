using RickAndMorty.Application.Utilities.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Application.Utilities.Responses.ContentResponse.Common
{
    public class ContentResponseBase<TData> : IContentResponse<TData>
    {
        public TData Data { get; }

        public bool IsSuccess { get; }

        public string Title { get; }

        public string Message { get; }

        public ContentResponseBase(bool isSuccess, TData data, string message, string title) : this(isSuccess, data, message)
        {
            Title = title;
        }

        public ContentResponseBase(bool isSuccess, string message, string title) : this(isSuccess, message)
        {
            Title = title;
        }

        public ContentResponseBase(bool isSuccess, TData data, string message) : this(isSuccess, data)
        {
            Message = message;
        }

        public ContentResponseBase(bool isSuccess, string message) : this(isSuccess)
        {
            Message = message;
        }

        public ContentResponseBase(bool isSuccess, TData data)
        {
            Data = data;
            IsSuccess = isSuccess;
        }

        public ContentResponseBase(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
