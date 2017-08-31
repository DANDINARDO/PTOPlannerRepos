using AutoMapper;
using PTOPlanner.Repository.AutoMapper;

namespace PTOPlanner.Repository.Repositories
{
    public abstract class RepositoryBase
    {
        protected Data.Entities.PTOPlanner _dbContext;
        protected IMapper _mapper;
         
        public RepositoryBase()
        {
            _dbContext = new Data.Entities.PTOPlanner();
            var config = new AutoMapperConfig().GetConfig();
            _mapper = config.CreateMapper();
        }
    }
}
