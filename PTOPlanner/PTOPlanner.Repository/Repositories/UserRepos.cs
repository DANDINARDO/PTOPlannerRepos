using System.Collections.Generic;
using System.Linq;
using PTOPlanner.Data.Entities;
using PTOPlanner.Repository.Domain;

namespace PTOPlanner.Repository.Repositories
{
    public class UserRepos : RepositoryBase, IUserRepos
    {
        #region Public Methods

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>List Of User Objects</returns>
        public List<User> GetUsers()
        {
            return ReposGetUsers();
        }

        /// <summary>
        /// Create the User Entity
        /// </summary>
        /// <param name="user">User Object</param>
        public void CreateUser(User user)
        {
            ReposCreateUser(user);
        }

        #endregion

        #region Private Methods


        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>List Of User Objects</returns>
        private List<User> ReposGetUsers()
        {
            var lstEmployeeInfo = _dbContext.Employee_Info.ToList();
            var lstUsers = _mapper.Map<List<Employee_Info>, List<User>>(lstEmployeeInfo);
            return lstUsers;
        }

        /// <summary>
        /// Create the User Entity
        /// </summary>
        /// <param name="user">User Object</param>
        private void ReposCreateUser(User user)
        {
            _dbContext.Employee_Info.Add(_mapper.Map<User, Employee_Info>(user));
            _dbContext.SaveChanges();
        }

        #endregion
    }
}
