using ElitPatisserie.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Business.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez!");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Adı 5 karakterden az olamaz!");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Adı 20 karakterden fazla olamaz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez!");            
            RuleFor(x => x.Description).MinimumLength(40).WithMessage("Açıklama 40 karakterden az olamaz!");
            RuleFor(x => x.Description).MaximumLength(90).WithMessage("Açıklama 90 karakterden fazla olamaz!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş geçilemez!");


        }
    }
}
