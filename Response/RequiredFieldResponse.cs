using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Enums;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Response
{
    public class RequiredFieldResponse : ControlResponse
    {

        public static ObjectResult TitleIsRequiredResponse()
        {
            var description = GetEnumDescription(RequiredFieldEnum.Title_Is_Required);
            var statusCode = 422;
            var response = new ObjectResult(new { ErrorMessage = RequiredFieldEnum.Title_Is_Required, statusCode, description });
            response.StatusCode = statusCode;

            return response;
        }

        internal static IActionResult DescriptionIsRequiredResponse()
        {
            var description = GetEnumDescription(RequiredFieldEnum.Description_Is_Required);
            var statusCode = 422;
            var response = new ObjectResult(new { ErrorMessage = RequiredFieldEnum.Description_Is_Required, statusCode, description });
            response.StatusCode = statusCode;

            return response;
        }
    }
}
