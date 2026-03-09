namespace MyStack.Api.DTOs
{
    public record CreateHardwareItem(string Name, string Brand, decimal Price);
    public record HardwareResponse(Guid Id, string Name, string Brand, decimal Price, DateTime CreatedAt);
    public record HardwareResponseUpdate(Guid Id, string Name, string Brand, decimal Price, DateTime CreatedAt);

}
