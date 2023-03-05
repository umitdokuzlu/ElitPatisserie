using ElitPatisserie.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElitPatisserie.MVC.ViewComponents.CakeList
{
    public class CakeList:ViewComponent
    {
        private readonly IProductService _productService;

        public CakeList(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _productService.GetByCategory("Pasta"));
        }
    }
}
