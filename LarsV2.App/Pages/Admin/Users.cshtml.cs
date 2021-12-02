using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Pages.Admin
{
    public class UsersModel : AdminPageModel
    {
        public UserManager<IdentityUser> UserManager;

        public UsersModel(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }

        public IEnumerable<IdentityUser> Users { get; set; }

        public void OnGet()
        {
            Users = UserManager.Users.Where(e => e.UserName.ToLower() != "admin");
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            IdentityUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                await UserManager.DeleteAsync(user);
            }
            return RedirectToPage();

        }
    }
}
