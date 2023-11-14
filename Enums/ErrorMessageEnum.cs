using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrilhaApiDesafio.Enums
{
    public enum ErrorMessageEnum
    {
        [Description("An entity was not found in the database!")]
        Entity_Not_Found,
        [Description("Enter a valid date!")]
        Invalid_Date
    }
}
