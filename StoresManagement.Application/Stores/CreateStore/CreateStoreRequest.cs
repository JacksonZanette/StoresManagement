using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using StoresManagement.Domain.Models.Entities;
using StoresManagement.Domain.Models.ValueObjects;

namespace StoresManagement.Application.Stores.CreateStore;
public record CreateStoreRequest(Guid? CompanyId, string? Name, Address? Address) : IRequest<Result<Guid>>
{
    internal ValidationResult Validate() => new Validator().Validate(this);

    internal Store ToEntity()
        => new()
        {
            Id = Guid.NewGuid(),
            CompanyId = CompanyId!.Value,
            Name = Name!,
            Address = Address!
        };

    internal class Validator : AbstractValidator<CreateStoreRequest>
    {
        public Validator()
        {
            RuleFor(e => e.CompanyId).NotEmpty();
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.Address)
                .NotNull()
                .ChildRules(e =>
                {
                    e.RuleFor(x => x.StreetName).NotEmpty();
                    e.RuleFor(x => x.CityName).NotEmpty();
                    e.RuleFor(x => x.RegionName).NotEmpty();
                    e.RuleFor(x => x.PostalCode).NotEmpty();
                    e.RuleFor(x => x.Country).NotEmpty();
                });
        }
    }
}