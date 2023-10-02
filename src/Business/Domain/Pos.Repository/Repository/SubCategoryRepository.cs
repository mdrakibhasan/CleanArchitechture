using AutoMapper;
using Pos.Infrustructure;
using Pos.Model;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using Pos.Shared.GenericRepository;


namespace Pos.Repository.Repository
{
    public class SubCategoryRepository: RepositoryBase<SubCategory, VmSubcategory, int>, IRepository.ISubCategoryRepository
    {

        public SubCategoryRepository(IMapper mapper, PosDbContext dbContext) : base(mapper, dbContext)
        {

        }
    }
}
