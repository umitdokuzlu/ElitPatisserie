using ElitPatisserie.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Business.ValidationRules
{
    public class MenuSliderValidator:AbstractValidator<MenuSlider>
    {
        public MenuSliderValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adı boş geçilemez!");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Adı 5 karakterden az olamaz!");
            RuleFor(x => x.Name).MaximumLength(15).WithMessage("Adı 15 karakterden fazla olamaz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez!");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Açıklama 50 karakterden az olamaz!");
            RuleFor(x => x.Description).MaximumLength(80).WithMessage("Açıklama 80 karakterden fazla olamaz!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Açıklama boş geçilemez!");

        }
    }
}
