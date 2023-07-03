using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<Model>? Models { get; set; }
    }
}
