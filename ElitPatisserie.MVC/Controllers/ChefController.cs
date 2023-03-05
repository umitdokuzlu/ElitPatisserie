using ElitPatisserie.Business.Abstract;
using ElitPatisserie.Business.ValidationRules;
using ElitPatisserie.Entity.Concrete;
using ElitPatisserie.MVC.Validate;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ElitPatisserie.MVC.Controllers
{
    public class ChefController : Controller
    {
        private readonly IChefService _chefService;
        ChefValidator validations=new ChefValidator();

        public ChefController(IChefService chefService)
        {
            _chefService = chefService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _chefService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> ChefUpdate(int id)
        {
            var result = await _chefService.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> ChefUpdate(Chef chef,IFormFile picture)
        {

            ValidationResult results = validations.Validate(chef);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            if (!MyValidateImage.IsImage(picture))
            {
                ModelState.AddModelError("Picture", "Lütfen geçerli bir resim dosyası seçiniz!");
                return View(chef);
            }
            if (picture != null)
            {
                // Yeni resim seçilmiş, önce eski resmi sil
                if (!string.IsNullOrEmpty(chef.Picture))
                {
                    string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ElitCafe", "assets", "images", chef.Picture);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Yeni resmi kaydet
                string newImageName = Guid.NewGuid() + Path.GetExtension(picture.FileName);
                string location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ElitCafe", "assets", "images", newImageName);

                using (var stream = new FileStream(location, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }

                // Ürünün resim url'sini güncelle
                chef.Picture = newImageName;
            }
            _chefService.Update(chef);
            return RedirectToAction("Index", "Chef");
        }
       

    }
}
//chefs-01.jpg