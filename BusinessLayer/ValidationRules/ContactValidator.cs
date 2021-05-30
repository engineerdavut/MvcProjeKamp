using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage("mesaj boş olamaz");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("mail alanı boş olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("konu alanı boş olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("kullanıcı adı boş olamaz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("en az 3 karakter giriş yapın");
            RuleFor(x => x.Subject).MaximumLength(30).WithMessage("en fazla 50 karakter giriş yapın");
            
        }
    }
}
