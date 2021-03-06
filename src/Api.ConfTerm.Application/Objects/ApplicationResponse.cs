using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Api.ConfTerm.Application.Objects
{
    public class ApplicationResponse
    {
        public readonly List<ApplicationError> Errors = new();

        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }

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

        public virtual object ToJsonObject()
        {
            if (!Errors.Any())
                return new { Code = (int)StatusCode, Success };
            return new { Code = (int)StatusCode, Success, Errors = Errors.Select(err => err.Value) };
        }

        public ApplicationResponse BadRequest()
        {
            Success = false;
            StatusCode = HttpStatusCode.BadRequest;
            return this;
        }

        public ApplicationResponse CheckForArgument<TRequest>(TRequest request, Func<TRequest, bool> predicate, ApplicationError applicationError)
        {
            var predicateResult = predicate.Invoke(request);
            if (!predicateResult)
                BadRequest().WithError(applicationError);

            return this;
        }
        public ApplicationResponse CheckFor(bool succsess, ApplicationError applicationError)
        {
            if (!succsess)
                BadRequest().WithError(applicationError);
            return this;
        }

        public static ApplicationResponse<T> Of<T>(T data) => new() { Data = data, StatusCode = HttpStatusCode.OK, Success = true };
        public static ApplicationResponse OfNone() => new() { StatusCode = HttpStatusCode.OK, Success = true };
    }
    public class ApplicationResponse<T> : ApplicationResponse
    {
        public T Data { get; set; }
        public override object ToJsonObject()
        {
            if (!Errors.Any())
                return new { Code = (int)StatusCode, Success, Data };
            return new { Code = (int)StatusCode, Success, Data, Errors = Errors.Select(err => err.Value) };
        }
    }
}
