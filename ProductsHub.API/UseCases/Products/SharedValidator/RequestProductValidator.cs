using FluentValidation;
using ProductsHub.Communication.Requests;

namespace ProductsHub.API.UseCases.Products.SharedValidator;

public class RequestProductValidator : AbstractValidator<RequestProductJson>
{
    public RequestProductValidator()
    {
        RuleFor(product => product.Name).NotEmpty().WithMessage("Name could not be empty.");
        RuleFor(product => product.Brand).NotEmpty().WithMessage("Brand could not be empty.");
        RuleFor(product => product.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}
