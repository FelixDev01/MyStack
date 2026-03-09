namespace MyStack.Api.DTOs
{
    public class HardwareResponseDTO
    {
        public HardwareResponseDTO(Guid id, string name, string brand, decimal price, DateTime createdAt, DateTime lastUpdatedAt)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Price = price;
            CreatedAt = createdAt;
            LastUpdatedAt = lastUpdatedAt;
        }

        public Guid Id { get; set; }
        public String Name { get; set; } = String.Empty;
        public String Brand { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
