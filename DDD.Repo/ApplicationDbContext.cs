using DDD.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {

        }
        public DbSet<Address> Address { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }

    }
    public class ApplicationDbContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {
            var user = new List<User>
            {
                new User()
                {
                    Name ="Oriahi Emmanuel",
                    Email ="oriahi@gmail.com",
                    Password ="_Emma01",
                    Userprofile =new UserProfile
                    {
                        FirstName ="Oriahi",
                        LastName ="Emmanuel",
                        Address =new Address
                        {
                            HomeAddress ="Ikeja Lagos"
                        }
                    }
                },


                new User()
                {
                    Name ="Chuks Mabi",
                    Email ="mabichuks@gmail.com",
                    Password ="Chuks02@",
                    Userprofile =new UserProfile
                    {
                        FirstName ="Chuks",
                        LastName ="Mabi",
                        Address =new Address
                        {
                            HomeAddress ="23, Yaba Lagos "
                        }
                    }
                },


                new User()
                {
                    Name ="Gaby Olowoniwa",
                    Email ="gabriel@gmail.com",
                    Password ="gabysl@w",
                    Userprofile =new UserProfile
                    {
                        FirstName ="Gaby",
                        LastName ="Olowoniwa",
                        Address =new Address
                        {
                            HomeAddress ="02 surulere Lagos "
                        }
                    }
                }
            };
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
