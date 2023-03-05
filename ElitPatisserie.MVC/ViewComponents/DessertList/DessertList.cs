using ElitPatisserie.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElitPatisserie.MVC.ViewComponents.DessertList
{
    public class DessertList:ViewComponent
    {
        private readonly IProductService _productService;

        public DessertList(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _productService.GetByCategory("Tatlı"));
        }
    }
}
