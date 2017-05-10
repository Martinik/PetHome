using PetHome.Data.Interfaces;

namespace PetHome.Services
{
    public abstract class Service
    {
        public Service(IPetHomeContext context)
        {
            this.Context = context;
        }

        protected IPetHomeContext Context { get; }
    }
}
