using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pos.Model
{
    public class PurchaseDtl : BaseEntity, IEntity
    {
        public int PurchaseMstId { get; set; }
        [JsonIgnore]
        public PurchaseMst PurchaseMst { get; set; }
        public int? ProductId { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }
        public int? CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        public int? ColorId { get; set; }
        [JsonIgnore]
        public Color? Color { get; set; }
        public int? SizeId { get; set; }
        [JsonIgnore]
        public Size? Size { get; set; }
        public int? SubCategoryId { get; set; }
        [JsonIgnore]
        public SubCategory? SubCategory { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public string BarCode { get; set; }
        public string DesignKey { get; set; }
        public decimal? Discount { get; set; }
        public decimal CostPrice { get; set; }
    }
}
