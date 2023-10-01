using AutoMapper;
using Pos.Infrustructure;
using Pos.Model;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using Pos.Shared.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Repository.Repository
{
    public class ColorRepository: RepositoryBase<Color, VmColor, int>, IColorRepository
    {
        public ColorRepository(IMapper mapper, PosDbContext dbContext) : base(mapper, dbContext)
        {

        }
    }
}
