namespace Flight.ViewModels;

public class PagedResult<T>
{
    public PagedResult(int total, IList<T> rows)
    {
        Total = total;
        Rows = rows ?? new List<T>();
    }

    public int Total { get; }
    
    public IList<T> Rows { get;  }
}