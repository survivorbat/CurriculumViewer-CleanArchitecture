using System;
using System.Collections.Generic;
using System.Text;
using CurriculumViewer.Database;
using CurriculumViewer.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace CurriculumViewer.Infrastructure.SeedData
{
    public class IdentitySeedData
    {
        private ApplicationIdentityDbContext context;

        private UserManager<ApplicationUser> userMgr;
        private RoleManager<IdentityRole> roleMgr;

        public IdentitySeedData(ApplicationIdentityDbContext context, UserManager<ApplicationUser> userMgr, RoleManager<IdentityRole> roleMgr)
        {
            this.context = context;
            this.userMgr = userMgr;
            this.roleMgr = roleMgr;
        }

        public void Seed()
        {
            SeedRoles();
            SeedUsers();

            context.SaveChanges();
        }

        private void SeedUsers()
        {
            if (userMgr.FindByNameAsync("Admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "admin@avans";

                IdentityResult result = userMgr.CreateAsync
                    (user, "Admin@123").Result;

                if (result.Succeeded)
                {
                    userMgr.AddToRoleAsync(user,
                        "Admin").Wait();
                }
            }


            if (userMgr.FindByNameAsync("User").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "User";
                user.Email = "user@avans";

                IdentityResult result = userMgr.CreateAsync
                    (user, "User@123").Result;

                if (result.Succeeded)
                {
                    userMgr.AddToRoleAsync(user,
                        "User").Wait();
                }
            }
        }

        private void SeedRoles()
        {
            if (!roleMgr.RoleExistsAsync
                ("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleMgr.
                    CreateAsync(role).Result;
            }


            if (!roleMgr.RoleExistsAsync
                ("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleMgr.
                    CreateAsync(role).Result;
            }
        }
    }
}
