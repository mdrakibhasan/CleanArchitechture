using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model
{
    public class MOU : BaseEntity, IEntity
    {
        public string UniteName { get; set; }
        public int Value { get; set; }

    }
}
