using ElitPatisserie.Business.Abstract;
using ElitPatisserie.Business.ValidationRules;
using ElitPatisserie.Entity.Concrete;
using ElitPatisserie.MVC.Models;
using ElitPatisserie.MVC.Validate;
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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        ProductValidator validations = new ProductValidator();

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int id)
        {
            List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString(),
                                               }).ToList();
            ViewBag.v = categories;
            var values = await _productService.GetByCategoryWithId(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult ProductAdd()
        {

            List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.Id.ToString(),
                                           }).ToList();
            ViewBag.v = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductAdd(Product product, IFormFile picture)
        {
            ValidationResult results = validations.Validate(product);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString(),
                                                   }).ToList();
                ViewBag.v = categories;
                return View();
            }

            if (!MyValidateImage.IsImage(picture))
            {
                ModelState.AddModelError("Picture", "Lütfen geçerli bir resim dosyası seçiniz!");
                List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString(),
                                                   }).ToList();
                ViewBag.v = categories;
                return View(product);
            }
            if (picture != null)
            {
                // Yeni resim seçilmiş, önce eski resmi sil
                if (!string.IsNullOrEmpty(product.Picture))
                {
                    string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ElitCafe", "assets", "images", product.Picture);
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
                product.Picture = newImageName;
            }

            await _productService.AddAsync(product);
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> ProductUpdate(int id)
        {
            
            List<SelectListItem> values = (from x in _categoryService.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.Id.ToString(),
                                           }).ToList();
            ViewBag.v = values;
            var result = await _productService.GetByIdAsync(id);
            return View(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(Product product,IFormFile picture)
        {
            ValidationResult results = validations.Validate(product);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString(),
                                                   }).ToList();
                ViewBag.v = categories;
                return View();
            }

            if (!MyValidateImage.IsImage(picture))
            {
                ModelState.AddModelError("Picture", "Lütfen geçerli bir resim dosyası seçiniz!");
                List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString(),
                                                   }).ToList();
                ViewBag.v = categories;
                return View(product);
            }
            if (picture != null)
            {
                // Yeni resim seçilmiş, önce eski resmi sil
                if (!string.IsNullOrEmpty(product.Picture))
                {
                    string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ElitCafe", "assets", "images", product.Picture);
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
                product.Picture = newImageName;
            }

            _productService.Update(product);
            return RedirectToAction("Index", "Product");
        }

        
        public async Task<IActionResult> ProductDelete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product!=null)
            {
                //resmin fiziksel dosyasını sil
                if (!string.IsNullOrEmpty(product.Picture))
                {
                    var filePath= Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "ElitCafe", "assets", "images", product.Picture);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
                
                _productService.Delete(product);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return NotFound();
            }
            
        }
        
    }
}
