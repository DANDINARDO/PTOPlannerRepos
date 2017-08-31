using System.Collections.Generic;
using PTOPlanner.Repository.Domain;

namespace PTOPlanner.Repository.Repositories
{
    public interface IUserRepos
    {
        List<User> GetUsers();
        void CreateUser(User user);
    }
}