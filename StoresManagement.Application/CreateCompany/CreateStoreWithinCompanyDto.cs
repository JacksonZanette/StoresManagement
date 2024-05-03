using FluentValidation;
using StoresManagement.Domain.Models.Entities;
using StoresManagement.Domain.Models.ValuedObjects;

namespace StoresManagement.Application.CreateCompany;
public record CreateStoreWithinCompanyDto(string Name, Address Address)
{
    internal Store ToEntity(Guid companyId)
        => new()
        {
            Id = Guid.NewGuid(),
            CompanyId = companyId,
            Name = Name,
            Address = Address
        };

    internal class Validator : AbstractValidator<CreateStoreWithinCompanyDto>
    {
        public Validator()
        {
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.Address).NotNull();
            RuleFor(e => e.Address)
                .ChildRules(e =>
                {
                    e.RuleFor(x => x.StreetName).NotEmpty();
                    e.RuleFor(x => x.CityName).NotEmpty();
                    e.RuleFor(x => x.RegionName).NotEmpty();
                    e.RuleFor(x => x.PostalCode).NotEmpty();
                    e.RuleFor(x => x.Country).NotEmpty();
                })
                .When(e => e.Address is not null);
        }
    }
}