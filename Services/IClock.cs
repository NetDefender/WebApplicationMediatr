namespace WebApplicationMediatr.Services
{
    public interface IClock
    {
        DateTime Now
        {
            get;
        }
    }

    public sealed class Clock : IClock
    {
        public DateTime Now => DateTime.Now;
    }
}