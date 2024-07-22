namespace Application.Services.Common
{
    public interface IPaginationParams
    {
        int PageNumber { get; }
        int PageSize { get; }
    }
}
