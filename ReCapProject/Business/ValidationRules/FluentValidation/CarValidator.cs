using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(2010).LessThanOrEqualTo(DateTime.Now.Year);
            RuleFor(c => c.DailyPrice).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(c => c.Description).MinimumLength(2);
        }
    }
}
