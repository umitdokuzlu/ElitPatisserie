using ElitPatisserie.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElitPatisserie.MVC.ViewComponents.HomeList
{
    public class HomeList:ViewComponent
    {
        private readonly IHomeSliderService _sliderService;

        public HomeList(IHomeSliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {            
            return View( await _sliderService.GetAllAsync());
        }
    }
}
