using ElitPatisserie.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElitPatisserie.MVC.ViewComponents.MenuSLiderList
{
    public class MenuSliderList:ViewComponent
    {
        private readonly IMenuSliderService _menuSliderService;

        public MenuSliderList(IMenuSliderService menuSliderService)
        {
            _menuSliderService = menuSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _menuSliderService.GetAllAsync());
        }
    }
}
