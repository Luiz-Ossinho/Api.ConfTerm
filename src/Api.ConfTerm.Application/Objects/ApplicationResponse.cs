using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;

namespace Api.ConfTerm.Application.Objects
{
    public class ApplicationResponse
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        [JsonIgnore]
        protected ICollection<ApplicationError> Errors { get; init; } = new LinkedList<ApplicationError>();

        [JsonPropertyName("Errors")]
        public IEnumerable<string> ErrorsValues { get => Errors.Select(e => e.Value); }

        public ApplicationResponse WithBadRequest(params ApplicationError[] applicationErrors)
        {
            foreach (var error in applicationErrors)
                WithError(error);

            Success = false;
            StatusCode = HttpStatusCode.BadRequest;
            return this;
        }

        public ApplicationResponse WithNotFound(params ApplicationError[] applicationErrors)
        {
            foreach (var error in applicationErrors)
                WithError(error);

            Success = false;
            StatusCode = HttpStatusCode.NotFound;
            return this;
        }

        public ApplicationResponse WithCreated()
        {
            Success = true;
            StatusCode = HttpStatusCode.Created;
            return this;
        }

        public ApplicationResponse<T> WithCreated<T>(T data)
        {
            Success = true;
            StatusCode = HttpStatusCode.Created;
            return WithData(data);
        }

        public ApplicationResponse WithCode(HttpStatusCode httpStatusCode)
        {
            StatusCode = httpStatusCode;
            return this;
        }

        public ApplicationResponse WithError(ApplicationError error)
        {
            Errors.Add(error);
            return this;
        }

        public virtual ApplicationResponse<T> WithData<T>(T data)
            => new()
            {
                Data = data,
                Success = Success,
                StatusCode = StatusCode
            };

        public static ApplicationResponse<T> Of<T>(T data) => new() { Data = data, StatusCode = HttpStatusCode.OK, Success = true };
        public static ApplicationResponse OfOk() => new() { StatusCode = HttpStatusCode.OK, Success = true };
    }
    public class ApplicationResponse<T> : ApplicationResponse
    {
        public T Data { get; set; }
    }
}
