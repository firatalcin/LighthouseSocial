namespace LighthouseSocialProject.Application.Common;

public class Result<T>
{
    public bool Success { get; }
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }

    public Result(bool success, T? data, string? errorMessage)
    {
        Success = success;
        Data = data;
        ErrorMessage = errorMessage;
    }
    
    public static Result<T> Ok(T data) => new Result<T>(true, data, null);
    public static Result<T> Fail(string errorMessage) => new Result<T>(false, default, errorMessage);
}

public class Result
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }

    protected Result(bool success, string? errorMessage)
    {
        Success = success;
        ErrorMessage = errorMessage;
    }
    
    public static Result Ok() => new Result(true, null);
    public static Result Fail(string error) => new Result(false, error);
}