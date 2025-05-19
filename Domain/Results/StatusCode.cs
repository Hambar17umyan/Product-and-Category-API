using System.ComponentModel;

namespace Domain.Results;

public enum StatusCode
{
    [Description("Status unspecified.")]
    NotSpecified = 10500,
    [Description("No error.")]
    Success = 10200,
    [Description("The request was null.")]
    ArgumentNullError = 10400,
    [Description("The request was invalid.")]
    ArgumentInvalidError = 10401,
    NotFound = 10501,
}
