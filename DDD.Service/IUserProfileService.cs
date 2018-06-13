using DDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Service
{
    public interface IUserProfileService
    {
        UserProfile GetUserProfile(int id);
    }
}
