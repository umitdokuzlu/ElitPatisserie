using ElitPatisserie.Business.Abstract;
using ElitPatisserie.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ElitPatisserie.MVC.Controllers
{
    [AllowAnonymous]
    public class MenuListController : Controller
    {
        private readonly IProductService _productService;

        public MenuListController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {            
            return View();
        }
    }
}
