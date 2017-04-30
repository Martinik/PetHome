using PetHome.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
