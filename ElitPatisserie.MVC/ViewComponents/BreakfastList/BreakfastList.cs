using ElitPatisserie.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElitPatisserie.MVC.ViewComponents.BreakfastList
{
    public class BreakfastList:ViewComponent
    {
        private readonly IProductService _productService;

        public BreakfastList(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _productService.GetByCategory("Kahvaltı"));
        }
    }
}
