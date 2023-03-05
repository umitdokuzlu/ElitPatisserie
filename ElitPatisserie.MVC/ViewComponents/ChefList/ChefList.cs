using ElitPatisserie.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElitPatisserie.MVC.ViewComponents.ChefList
{
    public class ChefList:ViewComponent
    {
        private readonly IChefService _chefService;

        public ChefList(IChefService chefService)
        {
            _chefService = chefService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _chefService.GetAllAsync();
            if (value.Count<=3)
            {

                return View(value);
            }
            else
            {
                return View();
            }
        }
    }
}
