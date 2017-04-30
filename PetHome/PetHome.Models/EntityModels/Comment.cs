using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHome.Models.EntityModels
{
    public class Comment
    {
        public int Id { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }

    }
}
