using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain;
using DDD.Infrastructure.Repo;

namespace DDD.Service
{
    public class UserService : IUserService
    {
        private Repository<User> userrepository;
        private Repository<UserProfile> userprofile;
        public UserService()
        {
            userrepository = new Repository<User>();
            userprofile = new Repository<UserProfile>();
        }
        public void DeleteUser(int id)
        {
            UserProfile userProfile = userprofile.Get(id);
            userprofile.Delete(userProfile);
            User user = GetUser(id);
            userrepository.Delete(user);
            userrepository.savechanges();
        }

        public void DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            return userrepository.Get(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return userrepository.GetAll();
        }

        public void InsertUser(User user)
        {
            userrepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            userrepository.Update(user);
        }
    }
}
