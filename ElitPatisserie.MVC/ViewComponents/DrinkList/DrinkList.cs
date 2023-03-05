using ElitPatisserie.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElitPatisserie.MVC.ViewComponents.DrinkList
{
    public class DrinkList:ViewComponent
    {
        private readonly IProductService _productService;

        public DrinkList(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _productService.GetByCategory("Içecek"));
        }
    }
}
