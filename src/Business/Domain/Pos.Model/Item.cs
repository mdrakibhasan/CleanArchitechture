using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model
{
    public class Item : BaseEntity, IEntity
    {
        public string Name { get; set; }

    }
}
