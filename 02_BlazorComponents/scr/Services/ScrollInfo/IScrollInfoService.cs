namespace BlazorComponents.Services.ScollInfo
{
    public interface IScrollInfoService
    {
         event EventHandler<int> OnScroll; 
         int YValue { get; }
    }
}