namespace MDispenser.Domain.Events;

public record FoodDispensedEvent(Guid DispenserId, DateTime Time);
