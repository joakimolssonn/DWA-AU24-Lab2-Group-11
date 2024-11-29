using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DWA_AU24_Lab2_Group_11.Models;
using System.Threading.Tasks;
using System.Linq;

namespace DWA_AU24_Lab2_Group_11.Controllers
{
    // This controller handles administrative actions and is accessible only to users with the "Admin" role.
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        // Constructor to inject UserManager and RoleManager services.
        public AdminController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Action to display the list of users and their roles.
        public IActionResult Index()
        {
            // Retrieve all users from the UserManager.
            var users = _userManager.Users.ToList();

            // Create a model to pass to the view.
            var model = new Views.Admin.IndexModel
            {
                Users = users
            };

            // Return the view with the model.
            return View(model);
        }

        // Action to make a user an admin.
        [HttpPost]
        public async Task<IActionResult> MakeAdmin(string id)
        {
            // Find the user by their ID.
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                // Check if the "Admin" role exists, and create it if it doesn't.
                if (!await _roleManager.RoleExistsAsync("Admin"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                // Add the user to the "Admin" role if they are not already in it.
                if (!await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
            }

            // Redirect back to the Index action.
            return RedirectToAction("Index");
        }
    }
}

