using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator:AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("kategori ismi boş olamaz");
            RuleFor(x => x.HeadingName).MinimumLength(2).WithMessage("en az 2 karakter giriş yapın");
            RuleFor(x => x.HeadingName).MaximumLength(50).WithMessage("en fazla 50 karakter giriş yapın");
            RuleFor(x => x.HeadingDate).NotEmpty().WithMessage("kategori aciklamasi boş olamaz");
        }
    }
}
