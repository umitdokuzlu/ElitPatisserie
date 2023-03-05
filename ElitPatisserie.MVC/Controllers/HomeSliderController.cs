using ElitPatisserie.Business.Abstract;
using ElitPatisserie.Entity.Concrete;
using ElitPatisserie.MVC.Validate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ElitPatisserie.MVC.Controllers
{
    public class HomeSliderController : Controller
    {
        private readonly IHomeSliderService _homeSliderService;

        public HomeSliderController(IHomeSliderService homeSliderService)
        {
            _homeSliderService = homeSliderService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _homeSliderService.GetAllAsync());
        }
        [HttpGet]
        public IActionResult HomeSliderAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HomeSliderAdd(HomeSlider homeSlider,IFormFile picture)
        {
            if (!MyValidateImage.IsImage(picture))
            {
                ModelState.AddModelError("Picture", "Lütfen geçerli bir resim dosyası seçiniz!");               
                return View(homeSlider);
            }
            if (picture != null)
            {
                // Yeni resim seçilmiş, önce eski resmi sil
                if (!string.IsNullOrEmpty(homeSlider.Picture))
                {
                    string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ElitCafe", "assets", "images", homeSlider.Picture);
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
                homeSlider.Picture = newImageName;
            }

            await _homeSliderService.AddAsync(homeSlider);
            return RedirectToAction("Index", "HomeSlider");
        }
        [HttpGet]
        public async Task<IActionResult> HomeSliderUpdate(int id)
        {
            var result = await _homeSliderService.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> HomeSliderUpdate(HomeSlider homeSlider,IFormFile picture)
        {
            if (!MyValidateImage.IsImage(picture))
            {
                ModelState.AddModelError("Picture", "Lütfen geçerli bir resim dosyası seçiniz!");                
                return View(homeSlider);
            }
            if (picture != null)
            {
                // Yeni resim seçilmiş, önce eski resmi sil
                if (!string.IsNullOrEmpty(homeSlider.Picture))
                {
                    string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ElitCafe", "assets", "images", homeSlider.Picture);
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
                homeSlider.Picture = newImageName;
            }

            _homeSliderService.Update(homeSlider);
            return RedirectToAction("Index", "HomeSlider");
        }

        public async Task<IActionResult> HomeSliderDelete(HomeSlider homeSlider)
        {
            
            var any=await _homeSliderService.GetAllAsync();
            if (any.Count()<=1)
            {
                ModelState.AddModelError("Picture", "En az bir tane fotoğraf olmalıdır");
                return RedirectToAction("Index", "HomeSlider");
            }

            var home = await _homeSliderService.GetByIdAsync(homeSlider.Id);
            if (home != null)
            {
                //resmin fiziksel dosyasını sil
                if (!string.IsNullOrEmpty(home.Picture))
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ElitCafe", "assets", "images", home.Picture);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _homeSliderService.Delete(home);
                return RedirectToAction("Index", "HomeSlider");
            }
            else
            {
                return NotFound();
            }
                        
        }
    }
}

// slide-03.jpg slide-02.jpg slide-01.jpg