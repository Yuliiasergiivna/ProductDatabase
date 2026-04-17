using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using ProductLibrary.ASPMVC.Handlers;
using ProductLibrary.ASPMVC.Models.User;
using ProductLibrary.BLL.Services;
using ProductLibrary.BLL.Entities;


namespace ProductLibrary.ASPMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _bllService;
        private readonly UserSession _userSession;

        public UserController(UserService bllService, UserSession userSession)
        {
            _bllService = bllService;
            _userSession = userSession;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterForm form)
        {
            if (!ModelState.IsValid) return View(form);

            try
            {
                User newUser = new User(Guid.NewGuid(), form.Email, form.Password);

                Guid userId = _bllService.Create(newUser);

                if (userId != Guid.Empty)
                {
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", "L'inscription a échoué.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erreur lors de l'inscription : " + ex.Message);
            }

            return View(form);
        }

        [HttpGet]
        [TypeFilter<AllowAnonymousFilter>]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter<AllowAnonymousFilter>]
        public IActionResult Login(LoginForm form)
        {
            try
            {
                if (!ModelState.IsValid) return View(form);

                Guid userId = _bllService.CheckPassword(form.Email, form.Password);
                if (userId != Guid.Empty)
                {
                    _userSession.UserId = userId;
                    _userSession.Email = form.Email;

                    return RedirectToAction("Index", "Product");
                }

                ModelState.AddModelError("", "Email ou mot de pass n'ont pas correct");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Une erreur est survenue : " + ex.Message);
            }
            return View(form);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }

}
