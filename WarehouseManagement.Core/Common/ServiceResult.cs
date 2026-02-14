namespace WarehouseManagement.Core.Common;

public enum ErrorType
{
    None,
    NotFound,
    ValidationError,
    Conflict
}

public class ServiceResult<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }
    public ErrorType ErrorType { get; set; } = ErrorType.None;

    public static ServiceResult<T> Ok(T data) =>
        new() { Success = true, Data = data };

    public static ServiceResult<T> Fail(string message, ErrorType errorType = ErrorType.ValidationError) =>
        new() { Success = false, ErrorMessage = message, ErrorType = errorType };

    public static ServiceResult<T> NotFound(string message) =>
        Fail(message, ErrorType.NotFound);

    public static ServiceResult<T> Conflict(string message) =>
        Fail(message, ErrorType.Conflict);
}