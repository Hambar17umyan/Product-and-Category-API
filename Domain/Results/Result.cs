namespace Domain.Results;

public class Result
{
    /// <summary>
    /// Gets the message associated with the result.
    /// </summary>
    public string? Message { get; }

    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets the status code of the result.
    /// </summary>
    public StatusCode StatusCode { get; }

    /// <summary>
    /// Gets a value indicating whether the operation has failed.
    /// </summary>
    public bool IsFail { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class with the specified properties.
    /// </summary>
    /// <param name="isSuccess">A bool indicating whether the operation has failed.</param>
    /// <param name="statusCode">The status code of the result.</param>
    /// <param name="message">The message returned by the result.</param>
    protected Result(bool isSuccess, StatusCode statusCode = StatusCode.Success, string? message = null)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Message = message;
        IsFail = !isSuccess;
    }

    /// <summary>
    /// Gets an instance of a failed result.
    /// </summary>
    /// <param name="statusCode">The status code of the reuslt.</param>
    /// <param name="message">The message of the result.</param>
    /// <param name="value">The resulting value.</param>
    /// <returns>The Result.</returns>
    public static Result<T> GetFail<T>(StatusCode statusCode = StatusCode.NotSpecified, string? message = default, T? value = default) => Result<T>.GetFail(statusCode, message, value);

    /// <summary>
    /// Gets an instance of a successful result.
    /// </summary>
    /// <param name="value">The resulting value.</param>
    /// <param name="message">The message of the result.</param>
    /// <param name="statusCode">The status code of the reuslt.</param>
    /// <returns></returns>
    public static Result<T> GetSuccess<T>(T value, string? message = default, StatusCode statusCode = StatusCode.Success) => Result<T>.GetSuccess(value, message, statusCode);

    /// <summary>
    /// Gets an instance of a failed result.
    /// </summary>
    /// <param name="statusCode">The status code of the reuslt.</param>
    /// <param name="message">The message of the result.</param>
    /// <returns>The Result.</returns>
    public static Result GetFail(StatusCode statusCode = StatusCode.NotSpecified, string? message = default) => new(false, statusCode, message);

    /// <summary>
    /// Gets an instance of a successful result.
    /// </summary>
    /// <param name="message">The message of the result.</param>
    /// <param name="statusCode">The status code of the reuslt.</param>
    /// <returns></returns>
    public static Result GetSuccess(string? message = default, StatusCode statusCode = StatusCode.Success) => new(true, statusCode, message);
}
