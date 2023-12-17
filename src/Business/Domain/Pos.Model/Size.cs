using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pos.Model
{
    public class Size : BaseEntity, IEntity
    {
        public string SizeName
        {
            get; set;
        }
    }
}
