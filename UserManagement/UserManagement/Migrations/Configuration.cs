namespace UserManagement.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UserManagement.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UserManagement.Models.ApplicationDbContext context)
        {

            if (!context.Users.Any(x => x.UserName == "admin@GymBooking.se"))
            {
                var UserStore = new UserStore<ApplicationUser>(context);
                var UserManager = new UserManager<ApplicationUser>(UserStore);
                var user = new ApplicationUser { UserName = "admin@GymBooking.se" };
                UserManager.Create(user, "password");
            }

            if (!context.Users.Any(x => x.UserName == "admin"))
            {
                var UserStore = new UserStore<ApplicationUser>(context);
                var UserManager = new UserManager<ApplicationUser>(UserStore);
                var user = new ApplicationUser
                {
                    UserName = "admin@GymBooking.se",
                    Email = "admin@GymBooking.se",
                    TimeOfRegistration = DateTime.Now


                };
                var result = UserManager.Create(user, "password");
                //UserManager.AddToRole(user.Id, "admin");

            }
            if (!context.Users.Any(x => x.UserName == "member@GymBooking.se"))
            {
                var UserStore = new UserStore<ApplicationUser>(context);
                var UserManager = new UserManager<ApplicationUser>(UserStore);
                var user = new ApplicationUser
                {
                    UserName = "member@GymBooking.se",
                    Email = "member@GymBooking.se",
                    TimeOfRegistration = DateTime.Now

                };
                var result = UserManager.Create(user, "password");
            }

            context.GymClasses.AddOrUpdate(y => y.Id,
                new GymClass { Name = "SwimmingClass", Duration = TimeSpan.FromHours(5), StartTime = DateTime.Now.AddHours(-10), Description = "OpenClass" },
                new GymClass { Name = "Airopic", Duration = TimeSpan.FromHours(9), StartTime = DateTime.Now.AddHours(-1), Description = "Members" },
                new GymClass { Name = "Kickboxing", Duration = TimeSpan.FromHours(10), StartTime = DateTime.Now.AddHours(-5), Description="Members"},
                new GymClass { Name = "Running", Duration = TimeSpan.FromHours(2), StartTime = DateTime.Now.AddHours(-2), Description = "OpenClass"}
                );
            context.SaveChanges();

        }
    }
}


 
 