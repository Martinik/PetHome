using PetHome.Data;

namespace PetHome.Services
{
    public abstract class Service
    {
        public Service()
        {
            this.Context = new PetHomeContext();
        }

        protected PetHomeContext Context { get; }
    }
}
