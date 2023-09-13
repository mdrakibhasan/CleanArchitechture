using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model
{
    public class Product:BaseEntity,IEntity
    {
        public string ProductName { get; set; }

    }
}
