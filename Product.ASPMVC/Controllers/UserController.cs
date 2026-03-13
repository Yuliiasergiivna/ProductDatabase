using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using ProductLibrary.ASPMVC.Handlers;
using ProductLibrary.BLL.Services;

namespace ProductLibrary.ASPMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly BLL.Services.UserService _bllService;
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
        [TypeFilter<AllowAnonymousFilter>]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter<AllowAnonymousFilter>]
        public IActionResult Login(string email, string password)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException("Le formulaire n'est pas valide.");
                Guid userId = _bllService.CheckPassword(email, password);
                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }

    }
