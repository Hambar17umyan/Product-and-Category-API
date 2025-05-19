using System.Diagnostics.CodeAnalysis;

namespace Domain.Results;

public class Result<T> : Result
{
    /// <summary>
    /// Gets or sets the resulting value.
    /// </summary>
    public T? Value { get; private set; }

    /// <summary>
    /// Gets an instance of a failed result.
    /// </summary>
    /// <param name="statusCode">The status code of the reuslt.</param>
    /// <param name="message">The message of the result.</param>
    /// <param name="value">The resulting value.</param>
    /// <returns>The Result.</returns>
    public static Result<T> GetFail(StatusCode statusCode = StatusCode.NotSpecified, string? message = default, T? value = default) => new(false, value, statusCode, message);

    /// <summary>
    /// Gets an instance of a successful result.
    /// </summary>
    /// <param name="value">The resulting value.</param>
    /// <param name="message">The message of the result.</param>
    /// <param name="statusCode">The status code of the reuslt.</param>
    /// <returns></returns>
    public static Result<T> GetSuccess(T? value, string? message = default, StatusCode statusCode = StatusCode.Success) => new(true, value, statusCode, message);

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class with the specified properties.
    /// </summary>
    /// <param name="isSuccess">A bool indicating whether the operation has failed.</param>
    /// <param name="value">The resulting value.</param>
    /// <param name="statusCode">The status code of the result.</param>
    /// <param name="message">The message returned by the result.</param>
    private Result(bool isSuccess, T? value = default, StatusCode statusCode = StatusCode.NotSpecified, string? message = default)
        : base(isSuccess, statusCode, message)
    {
        Value = value;
    }
}
