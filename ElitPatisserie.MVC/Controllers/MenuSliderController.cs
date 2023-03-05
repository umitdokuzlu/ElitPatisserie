using ElitPatisserie.Business.Abstract;
using ElitPatisserie.Business.ValidationRules;
using ElitPatisserie.Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElitPatisserie.MVC.Controllers
{
    public class MenuSliderController : Controller
    {
        private readonly IMenuSliderService _menuSliderService;
        MenuSliderValidator validations=new MenuSliderValidator();

        public MenuSliderController(IMenuSliderService menuSliderService)
        {
            _menuSliderService = menuSliderService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _menuSliderService.GetAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> MenuSliderUpdate(int id)
        {
            var result = await _menuSliderService.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult MenuSliderUpdate(MenuSlider menuSlider)
        {
            ValidationResult results = validations.Validate(menuSlider);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            _menuSliderService.Update(menuSlider);
            return RedirectToAction("Index", "MenuSlider");
        }

    }
}
