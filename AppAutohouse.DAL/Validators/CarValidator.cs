using FluentValidation;
using MVCAppAutohouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAutohouse.DAL.Validators
{
    class CarValidator: AbstractValidator<Car>
    {
       public CarValidator()
        {
            RuleFor(x => x.Year).GreaterThanOrEqualTo(2010).LessThan(DateTime.Now.Year);
        }
    }
}
