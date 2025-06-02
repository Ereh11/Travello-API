
namespace Travello_Application.Common.Result;
public class GeneralResult
{
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public List<ResultError>? Errors { get; set; } = null;
    public static GeneralResult MappingSuccessResult(string message)
    {
        return new GeneralResult
        {
            Success = true,
            Message = message,
        };
    }


}
public class GeneralResult<T> : GeneralResult
{
    public T? Data { get; set; }
    public static GeneralResult<T> MappingSuccessResult(T data, string message)
    {
        return new GeneralResult<T>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }
}
public class ResultError
{
    public string Message { get; set; } = string.Empty;
    public string? Code { get; set; } = null;
}
