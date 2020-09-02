namespace BuyList.Domain.Interfaces.Commands
{
    public interface IResponse
    {
        bool Success { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}