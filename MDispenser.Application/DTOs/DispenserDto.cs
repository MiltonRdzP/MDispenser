namespace MDispenser.Application.DTOs
{
    public class DispenserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime LastDispenseTime { get; set; }
    }
}
