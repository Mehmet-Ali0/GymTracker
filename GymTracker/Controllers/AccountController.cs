using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GymTracker.Models;
using GymTracker.ViewModels;


namespace GymTracker.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    userName: model.Email,
                    password: model.Password,
                    isPersistent: false,
                    lockoutOnFailure: false
                    );

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Workout");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");

            }



            return View(model);
        }







        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            
            if(ModelState.IsValid)
            {

                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user,model.Password);

                if (result.Succeeded)
                {
                    
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    
                    return RedirectToAction("Index", "Workout");
                
                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // This single line destroys the login cookie!
            await _signInManager.SignOutAsync();

            // Send them right back to your custom Login page
            return RedirectToAction("Login", "Account");
        }












    }
}
