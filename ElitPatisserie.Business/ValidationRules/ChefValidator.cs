using ElitPatisserie.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Business.ValidationRules
{
    public class ChefValidator:AbstractValidator<Chef>
    {
        public ChefValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Minumum 5 karakterden az değer girilemez!");
            RuleFor(x => x.Name).MaximumLength(25).WithMessage("Maksimum 25 karakterden fazla değer girilemez!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Unvan boş geçilemez");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Minumum 5 karakterden az değer girilemez!");
            RuleFor(x => x.Title).MaximumLength(25).WithMessage("Maksimum 25 karakterden fazla değer girilemez!");
        }
    }
}
