using AutoMapper;
using Pos.Model;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Core.Mapper
{
    public class CommonMapper:Profile
    {
        public CommonMapper()
        {
            CreateMap<VmProduct, Model.Product>().ReverseMap();
        }
    }
}
