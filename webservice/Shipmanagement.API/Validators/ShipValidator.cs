using FluentValidation;
using Shipmanagement.Service.Contract;
using Shipmanagement.ViewModels;

namespace Shipmanagement.API.Validators
{
    public class ShipValidator : AbstractValidator<AddEditShipViewModel>
    {
        public ShipValidator(IShipService shipService)
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("Ship name is required");

            RuleFor(s => s.Code)
                .NotEmpty()
                
                .WithMessage("Ship code is required")
                .Must((model, value)=> shipService.IsShipCodeUnique(model.Id, model.Code))
                .WithMessage("Ship code must be unique")
                .Matches(@"[a-zA-Z]{4}-\d{4}-[a-zA-Z]{1}\d{1}")
                .WithMessage("Ship name must be in format of AAAA-1111-A1 where A = Latin alphabet and 1 = number between 0-9")
                ;

            RuleFor(s => s.Width)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ship width is required")
                .GreaterThan(0)
                .WithMessage("Ship width cannot be less than zero")
                ;

            RuleFor(s => s.Length)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ship length is required")
                .GreaterThan(0)
                .WithMessage("Ship length cannot be less than zero")
                ;

            RuleFor(s => s.LastModifiedOn)
                .Must((model, value) => shipService.IsShipModifiedAlready(model.Id, model.LastModifiedOn) == false)
                .WithMessage("Ship has been already modified by some other user. Please refresh the page to get latest data.");
        }
    }
}
