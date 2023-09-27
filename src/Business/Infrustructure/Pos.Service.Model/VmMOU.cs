using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Model
{
    public class VmMOU:IVm
    {
        public int Id { get; set; }
        public string UniteName { get; set; }
    }
}
