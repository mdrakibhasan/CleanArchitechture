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
            CreateMap<VmCategory, Model.Category>().ReverseMap();
            CreateMap<VmSize, Model.Size>().ReverseMap();
            CreateMap<VmSubcategory, Model.SubCategory>().ReverseMap();
            CreateMap<VmColor, Model.Color>().ReverseMap();
            CreateMap<VmMOU, Model.MOU>().ReverseMap();
            CreateMap<VmSupplier, Model.Supplier>().ReverseMap();
            CreateMap<VmItem, Model.Item>().ReverseMap();
            CreateMap<VmAccountsHeadType, Model.AccountsHeadType>().ReverseMap();
            CreateMap<VmAccountsHead, Model.AccountsHead>().ReverseMap();
        }
    }
}
