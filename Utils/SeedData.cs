using m2gil_generateur_blogs.Areas.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace m2gil_generateur_blogs.Utils
{
  public class SeedData
  {
    public static async Task CreateRoles(IServiceProvider service)
    {
      //Initialising custom roles
      var RoleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
      var UserManager = service.GetRequiredService<UserManager<ApplicationUser>>();
      string[] rolesName = { "Administrateur", "Superviteur", "Membre" };
      IdentityResult identityResult;

      foreach (var roleName in rolesName)
      {
        var roleExist = await RoleManager.FindByNameAsync(roleName);
        if (roleExist==null)
        {
          //Create the role and seed them to the database
          identityResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
        }
      }

      // Super user who maintain application

      var powerUser = new ApplicationUser { 
        FirstName = "Ahmadou",
        LastName = "Kassoum",
        Email = "ahmadoukassoum7@gmail.com",
        UserName = "ahmadoukassoum7@gmail.com",
        EmailConfirmed = true
      };

      var UserPWD = "P@ssw0rd";
      var user = await UserManager.FindByEmailAsync("ahmadoukassoum7@gmail.com");

      if (user == null)
      {
        var createdUser = await UserManager.CreateAsync(powerUser, UserPWD);
        if(createdUser.Succeeded)
        {
          await UserManager.AddToRoleAsync(powerUser, "Administrateur");
        }
      }
      
    }
  }
}
