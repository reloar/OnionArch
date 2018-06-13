using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain;
using DDD.Infrastructure.Repo;

namespace DDD.Service
{
    public class UserProfileService : IUserProfileService
    {
        private Repository<UserProfile> userprofilerepo;
        public UserProfileService()
        {
            userprofilerepo = new Repository<UserProfile>();
        }
        public UserProfile GetUserProfile(int id)
        {
            return userprofilerepo.Get(id);
        }
    }
}
