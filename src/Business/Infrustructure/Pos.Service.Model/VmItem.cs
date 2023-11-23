using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Model
{
    public class VmItem:IVm
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
