using FluentValidation;
using ProductsHub.Communication.Requests;

namespace ProductsHub.API.UseCases.Clients.SharedValidator;

public class RequestClientValidator : AbstractValidator<RequestClientJson>
{
    public RequestClientValidator()
    {
        RuleFor(client => client.Name).NotEmpty().WithMessage("Name can not be empty.");
        RuleFor(client => client.Email).EmailAddress().WithMessage("Invalid e-mail.");
    }
}
