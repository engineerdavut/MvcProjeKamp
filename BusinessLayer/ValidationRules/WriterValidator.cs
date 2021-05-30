using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterFirstName).NotEmpty().WithMessage("yazar ismi boş olamaz");
            RuleFor(x => x.WriterFirstName).MinimumLength(2).WithMessage("en az 2 karakter giriş yapın");
            RuleFor(x => x.WriterFirstName).MaximumLength(50).WithMessage("en fazla 50 karakter giriş yapın");
            RuleFor(x => x.WriterLastName).NotEmpty().WithMessage("yazar soyadı boş olamaz");
            RuleFor(x => x.WriterLastName).MinimumLength(2).WithMessage("en az 2 karakter giriş yapın");
            RuleFor(x => x.WriterLastName).MaximumLength(50).WithMessage("en fazla 50 karakter giriş yapın");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("yazar unvanı boş olamaz");
            RuleFor(x => x.WriterTitle).MinimumLength(2).WithMessage("en az 2 karakter giriş yapın");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("en fazla 50 karakter giriş yapın");

            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("yazar hakkında boş olamaz");
        }

    }
}
