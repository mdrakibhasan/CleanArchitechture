using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model
{
   public class PurchaseMst : BaseEntity, IEntity
    {
        
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Vat { get; set; }
        public decimal GrandTotal { get; set; }
        public List<PurchaseDtl> PurchaseDtl { get; set; }

    }
}
