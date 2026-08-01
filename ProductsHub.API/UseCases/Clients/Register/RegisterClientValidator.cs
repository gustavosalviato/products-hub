using FluentValidation;
using ProductsHub.Communication.Requests;

namespace ProductsHub.API.UseCases.Clients.Register;

public class RegisterClientValidator : AbstractValidator<ResquestClientJson>
{
    public RegisterClientValidator()
    {
        RuleFor(client => client.Name).NotEmpty().WithMessage("Name can not be empty.");
        RuleFor(client => client.Email).EmailAddress().WithMessage("Invalid e-mail.");
    }
}
