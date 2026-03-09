namespace MyStack.Api.Models
{
    public class HardwareItem
    {
        // Tudo após o " = " é um valor padrão para a prop.

        public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; } = String.Empty;
        public String Brand { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
