using Pos.Model;
using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pos.Service.Model
{
    public class VmProduct:IVm
    {
        
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Fabrics { get; set; }
        public string BarCode { get; set; }
        public string DesignKey { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public int ItemId { get; set; }
        [JsonIgnore]
        public VmItem Item { get; set; }
        public int? CategoryId { get; set; }
        [JsonIgnore]
        public VmCategory? Category { get; set; }
        public int? ColorId { get; set; }
        [JsonIgnore]
        public VmColor? Color { get; set; }
        public int? SizeId { get; set; }
        [JsonIgnore]
        public VmSize? Size { get; set; }
        public int? MOUId { get; set; }
        [JsonIgnore]
        public VmMOU? MOU { get; set; }
        public int? SubCategoryId { get; set; }
        [JsonIgnore]
        public VmSubcategory? SubCategory { get; set; }
    }

}
