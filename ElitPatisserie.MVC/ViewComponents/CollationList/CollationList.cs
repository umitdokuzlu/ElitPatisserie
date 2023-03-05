using ElitPatisserie.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElitPatisserie.MVC.ViewComponents.CollationList
{
    public class CollationList:ViewComponent
    {
        private readonly IProductService _productService;

        public CollationList(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _productService.GetByCategory("Aperatif"));
        }
    }
}
