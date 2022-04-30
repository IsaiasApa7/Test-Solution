using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Test_Solution.Models.dbModels;

namespace Test_Solution.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TestSolutionContext>();

                if (!context.Statuses.Any())
                {
                    context.Statuses.AddRange(new Status()
                    {
                        StatusName = "Satisfactory"
                    },
                    new Status()
                    {
                        StatusName = "Unsatisfactory"

                    });

                    context.SaveChanges();
                }

            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {

        //        //Roles 
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Supervisor))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Supervisor));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.Inspector))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Inspector));


        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //        string supervisorUserEmail = "a&bPosSolution@gmail.com";

        //        var supervisorUser = await userManager.FindByEmailAsync(supervisorUserEmail);
        //        if (supervisorUser == null)
        //        {
        //            var newSupervisorUser = new ApplicationUser()
        //            {
        //                UserName = "A&BPosSoution",
        //                Email = supervisorUserEmail,
        //                EmailConfirmed = true,
        //                FirstName = "A&B",
        //                LastName = "PosSolution"

        //            };
        //            await userManager.CreateAsync(newSupervisorUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newSupervisorUser, UserRoles.Supervisor);
        //        }

        //        string inspectorUserEmail = "Inspector@PosSolution.com";

        //        var inspectorUser = await userManager.FindByEmailAsync(inspectorUserEmail);
        //        if (inspectorUser == null)
        //        {
        //            var newInspectorUser = new ApplicationUser()
        //            {
        //                UserName = "inspector-user",
        //                Email = inspectorUserEmail,
        //                EmailConfirmed = true,
        //                FirstName = "Inspector",
        //                LastName = "First"

        //            };
        //            await userManager.CreateAsync(newInspectorUser, "1234@Coding?");
        //            await userManager.AddToRoleAsync(newInspectorUser, UserRoles.Inspector);
        //        }
        //    }
        //}

    }
}
