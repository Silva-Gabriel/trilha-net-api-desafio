using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using TrilhaApiDesafio.Enums;

namespace TrilhaApiDesafio.Response
{
    public class ErrorResponse : ControlResponse
    {
        public static ObjectResult EntityNotFoundResponse()
        {
            var description = GetEnumDescription(ErrorMessageEnum.Entity_Not_Found);
            var statusCode = 404;
            var response = new ObjectResult(new { ErrorMessage = ErrorMessageEnum.Entity_Not_Found, statusCode, description });
            response.StatusCode = statusCode;

            return response;
        }

        public static ObjectResult InvalidDateResponse()
        {
            var description = GetEnumDescription(ErrorMessageEnum.Invalid_Date);
            var statusCode = 400;
            var response = new ObjectResult(new { ErrorMessage = ErrorMessageEnum.Invalid_Date, statusCode, description });
            response.StatusCode = statusCode;

            return response;
        }
    }
}
