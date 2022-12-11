using m2gil_generateur_blogs.Areas.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace m2gil_generateur_blogs.Utils
{
  public class CustomRoleManagement
  {
    public static async Task CreateRoles(IServiceProvider service)
    {
      //Initialising custom roles
      var RoleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
      var UserManager = service.GetRequiredService<UserManager<ApplicationUser>>();
      string[] rolesName = { "Admin", "Superviteur", "Member", "Guest" };
      IdentityResult identityResult;

      foreach (var roleName in rolesName)
      {
        var roleExist = await RoleManager.FindByNameAsync(roleName);
        if (roleExist != null)
        {
          //Create the role and seed them to the database
          identityResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
        }
      }
      
    }
  }
}
