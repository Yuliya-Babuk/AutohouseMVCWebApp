using AppAutohouse.DAL.Entities;
using FluentValidation;
using System;

namespace AppAutohouse.DAL.Validators
{
    //TODO: not in use
    class CarValidator: AbstractValidator<Car>
    {
       public CarValidator()
        {
            RuleFor(x => x.Year).GreaterThanOrEqualTo(2010).LessThan(DateTime.Now.Year);
        }
    }
}
