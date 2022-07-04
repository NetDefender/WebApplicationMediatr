namespace WebApplicationMediatr.Services
{
    public interface ITenant
    {
        public Guid Id
        {
            get;
        }

        internal void Set(Guid id);
    }

    public sealed class Tenant : ITenant
    {
        public Guid Id
        {
            get;
            private set;
        }

        void ITenant.Set(Guid id)
        {
            Id = id;
        }
    }
}