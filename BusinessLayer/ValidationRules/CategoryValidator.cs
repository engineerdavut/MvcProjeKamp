﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("kategori ismi boş olamaz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("en az 3 karakter giriş yapın");
            RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("en fazla 30 karakter giriş yapın");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("kategori aciklamasi boş olamaz");
        }
    }
}
