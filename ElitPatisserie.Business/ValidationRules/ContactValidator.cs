using ElitPatisserie.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Business.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez");
            RuleFor(x => x.Phone1).NotEmpty().WithMessage("Telefon boş geçilemez");
            RuleFor(x => x.Phone2).NotEmpty().WithMessage("Telefon boş geçilemez");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş geçilemez");
            RuleFor(x => x.Address).MaximumLength(300).WithMessage("Adres 300 karakteri geçemez");

        }
    }
}
