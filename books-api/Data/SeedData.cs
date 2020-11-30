﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.Data
{
    public class SeedData
    {

        public async static Task Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
           await SeedRoles(roleManager);
            await SeedUsers(userManager);

        }
        private async static Task SeedUsers(UserManager<IdentityUser>userManager)
        {
            if (await userManager.FindByEmailAsync("Admin@bookstore.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin",
                    Email = "Admin@bookstore.com"
                };
              var result =  await userManager.CreateAsync(user,"P@ssword1");
                if(result.Succeeded)
                {
                    await  userManager.AddToRoleAsync(user, "Administrator");
                }
            }

            if (await userManager.FindByEmailAsync("Customer1@gmail.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "Customer1",
                    Email = "Customer1@gmail.com"
                };
                var result = await userManager.CreateAsync(user, "P@ssword1");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Customer");
                }
            }

            if (await userManager.FindByEmailAsync("Customer2@gmail.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "Customer2",
                    Email = "Customer2@gmail.com"
                };
                var result = await userManager.CreateAsync(user, "P@ssword1");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Customer");
                }
            }
        }

        private async static Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if(!await roleManager.RoleExistsAsync("Administrator"))
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                await roleManager.CreateAsync(role);
            }

            if (!await roleManager.RoleExistsAsync("Customer"))
            {
                var role = new IdentityRole
                {
                    Name = "Customer"
                };
                await roleManager.CreateAsync(role);
            }
        }
       
    }
}
