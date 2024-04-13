namespace Flight.ViewModels;

public class CommonResult
{
    public bool Success { get;  }
    
    public string ErrorMsg { get;  }
    
    private CommonResult(bool success, string errorMsg)
    {
        Success = success;
        ErrorMsg = errorMsg;
    }
    
    public static CommonResult Succeed()
    {
        return new CommonResult(true, string.Empty);
    }

    public static CommonResult Failed(string error)
    {
        return new CommonResult(false, error);
    }
}