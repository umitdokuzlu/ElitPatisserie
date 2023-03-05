using ElitPatisserie.Business.Abstract;
using ElitPatisserie.Business.ValidationRules;
using ElitPatisserie.Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElitPatisserie.MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        ContactValidator validations = new ContactValidator();

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contactService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> ContactUpdate(int id)
        {
            var result = await _contactService.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult ContactUpdate(Contact contact)
        {
            ValidationResult results = validations.Validate(contact);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            _contactService.Update(contact);
            return RedirectToAction("Index", "Contact");
        }

    }
}
