using System.ComponentModel;

namespace TrilhaApiDesafio.Enums
{
    public enum RequiredFieldEnum
    {
        [Description("Title needs to be filled!")]
        Title_Is_Required,
        [Description("Description needs to be filled!")]
        Description_Is_Required
    }
}
