using AutoMapper;
using PTOPlanner.Data.Entities;

namespace PTOPlanner.Repository.AutoMapper
{
    public class AutoMapperConfig
    {
        #region Private Members

        private readonly MapperConfiguration _config;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AutoMapperConfig()
        {
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.User, Employee_Info>();
                cfg.CreateMap<Employee_Info, Domain.User>();
            });
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get the Mapper Config
        /// </summary>
        /// <returns></returns>
        public MapperConfiguration GetConfig()
        {
            return _config;
        }

        #endregion
    }
}
