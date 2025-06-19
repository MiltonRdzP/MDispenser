using MDispenser.Domain.Interfaces;

namespace MDispenser.Infrastructure
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime GetCurrentTime() => DateTime.UtcNow;
    }
}
