using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Task_Identity.Data;
using Task_Identity.Models.ViewModel;

namespace Task_Identity.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> usermanager;
        private readonly SignInManager<IdentityUser> signInManger;

        public AccountsController(ApplicationDbContext context , UserManager<IdentityUser> usermanager , SignInManager<IdentityUser> signInManger )

        {
            this.context = context;
            this.usermanager = usermanager;
            this.signInManger = signInManger;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.Phone,
            };

       var result =  await usermanager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            return View();
            
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
           var result = await signInManger.PasswordSignInAsync(model.Email, model.Password, model.RemmeberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

    }
}
