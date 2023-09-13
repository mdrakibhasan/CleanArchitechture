using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Model
{
    public class VmProduct:IVm
    {
        
        public int Id { get; set; }
        public string ProductName { get; set; }
    }
}
