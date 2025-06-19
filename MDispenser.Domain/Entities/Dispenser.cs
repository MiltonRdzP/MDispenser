namespace MDispenser.Domain.Entities;

public class Dispenser
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTime LastDispenseTime { get; private set; }

    public Dispenser(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        LastDispenseTime = DateTime.MinValue;
    }

    public void Dispense(DateTime currentTime)
    {
        // Business rule: must wait X time between servings, etc.
        LastDispenseTime = currentTime;
    }
}
