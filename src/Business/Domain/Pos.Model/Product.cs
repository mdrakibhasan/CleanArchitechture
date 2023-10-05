﻿using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pos.Model
{
    public class Product:BaseEntity,IEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Fabrics { get; set; }
        public string BarCode { get; set; }

        public string DesignKey { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int ItemId { get; set; }
        [JsonIgnore]
        public Item Item { get; set; }
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

    }
}
