using System;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project.Controllers;
using Project.Models;

namespace Project.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Db context)
        {
            
            context.Roles.AddOrUpdate(p => p.Name,
                new IdentityRole {Name = "Admin"},
                new IdentityRole {Name = "Advisor"},
                new IdentityRole {Name = "User"});
            context.SaveChanges();

            var userManger = new UserManager<ApplicationUser>((new UserStore<ApplicationUser>(new Db())));
            var admins = new[] { "Admin", "Admin2" };
            foreach (var userName in admins)
            {
                var user = userManger.FindByName(userName);
                if (user == null)
                {
                    var newUser = new ApplicationUser() { UserName = userName };
                    userManger.Create(newUser, "SomePassword");
                    userManger.AddToRole(newUser.Id, "Admin");
                    context.SaveChanges();
                }
            }

            var advisors = new[] { "Advisor" };
            foreach (var userName in advisors)
            {
                var user = userManger.FindByName(userName);
                if (user == null)
                {
                    var newUser = new ApplicationUser() { UserName = userName };
                    userManger.Create(newUser, "SomePassword");
                    userManger.AddToRole(newUser.Id, "Advisor");
                    context.SaveChanges();
                }
            }
            context.SaveChanges();
        }
    }
}
