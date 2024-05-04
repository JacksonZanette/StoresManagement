using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using StoresManagement.Domain.Models.ValueObjects;
using System.Text.Json.Serialization;

namespace StoresManagement.Application.Stores.UpdateStore;
public sealed record UpdateStoreRequest([property: JsonIgnore] Guid Id, Guid? CompanyId, string? Name, Address? Address) : IRequest<Result>
{
    internal ValidationResult Validate() => new Validator().Validate(this);

    internal class Validator : AbstractValidator<UpdateStoreRequest>
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