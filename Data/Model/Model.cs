using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Model
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        [JsonIgnore]
        public virtual Product? Product { get; set; } 
    }
}
