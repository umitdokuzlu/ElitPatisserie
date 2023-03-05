using ElitPatisserie.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Business.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Minumum 5 karakterden az değer girilemez!");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Maksimum 20 karakterden fazla değer girilemez!");
        }
    }
}
