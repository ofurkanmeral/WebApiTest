using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validations
{
    public class ProductValidator:AbstractValidator<ProductDto>
    {
        //Demekki neymiş AbstractValidatorden kalıtım alır generic method constractrın içinde set edilir
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is Required").NotEmpty().WithMessage("{PropertyName} is Required").MinimumLength(3).WithMessage("{PropertyName} 3 karakterden az olamaz");
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} 0 dan büyük olmalı");
            RuleFor(x => x.CategoryID).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} 0dan büyük olmalı");
        }
    }
}
