using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BryanGabeDAL.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; } = null!;
    }
}
