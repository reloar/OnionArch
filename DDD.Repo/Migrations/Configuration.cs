namespace DDD.Repo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DDD.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DDD.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.User.Add(new Domain.User
            {
                Name = "Emmanuel",
                Email = "oriahiemma@gmail.com",
                Password = "_emma26",
                Userprofile = new Domain.UserProfile
                {
                    FirstName = "Emmanuel",
                    LastName = "Oriahi",
                    UserId = 1,
                    Address = new Domain.Address
                    {
                        HomeAddress = "23 Ikeja"
                    }
                }
            });
            context.User.Add(new Domain.User
            {
                Name = "Gabriel",
                Email = "gaby@gmail.com",
                Password = "gabysl@w",
                Userprofile = new Domain.UserProfile
                {
                    FirstName = "Gabriel",
                    LastName = "Olowoniwa",
                    UserId = 1,
                    Address = new Domain.Address
                    {
                        HomeAddress = "02, Magodo Lagos"
                    }
                }
            });
            context.User.Add(new Domain.User
            {
                Name = "Hassan",
                Email = "ilyas@gmail.com",
                Password = "hc0de#",
                Userprofile = new Domain.UserProfile
                {
                    FirstName = "Hassan",
                    LastName = "Ilyas",
                    UserId = 1,
                    Address = new Domain.Address
                    {
                        HomeAddress = "17, Ijesa Lagos"
                    }
                }
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
