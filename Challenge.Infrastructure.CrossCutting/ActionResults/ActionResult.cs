using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Challenge.Infrastructure.CrossCutting.ActionResults
{
    public class ActionResult<TResult>
    {
        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public bool Success { get; set; }

        public static ActionResult<TResult> CreateSuccessResult(TResult result, HttpStatusCode statusCode = HttpStatusCode.OK, String message = "Operation Successful!")
        {
            return new ActionSuccessResult<TResult> { Success = true, Result = result, StatusCode = statusCode, Message = message };
        }

        public static ActionResult<TResult> CreateFailure(string nonSuccessMessage)
        {
            return new ActionFailureResult<TResult> { Success = false, Message = nonSuccessMessage };
        }

        public static ActionResult<TResult> CreateFailure(Exception ex, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new ActionFailureResult<TResult>
            {
                Success = false,
                Message = String.Format("{0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace),
                StatusCode = statusCode,
                Exception = ex
            };
        }
    }

    public class ActionResult
    {
        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public bool Success { get; set; }

        public static ActionResult CreateSuccessResult(HttpStatusCode statusCode = HttpStatusCode.OK, String message = "Operation Successful!")
        {
            return new ActionSuccessResult { Success = true, StatusCode = statusCode, Message = message };
        }

        public static ActionResult CreateFailure(string nonSuccessMessage, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new ActionFailureResult { Success = false, Message = nonSuccessMessage, StatusCode = statusCode };
        }

        public static ActionResult CreateFailure(Exception ex, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new ActionFailureResult
            {
                Success = false,
                Message = String.Format("{0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace),
                StatusCode = statusCode,
                Exception = ex
            };
        }
    }
}
