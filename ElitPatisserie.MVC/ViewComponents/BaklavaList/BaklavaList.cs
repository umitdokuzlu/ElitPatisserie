using ElitPatisserie.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElitPatisserie.MVC.ViewComponents.BaklavaList
{
    public class BaklavaList:ViewComponent
    {
        private readonly IProductService _productService;

        public BaklavaList(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _productService.GetByCategory("Baklava"));
        }
    }
}
