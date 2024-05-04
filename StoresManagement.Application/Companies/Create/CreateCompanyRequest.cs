using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Application.Companies.Create;
public record CreateCompanyRequest(string? Name, IEnumerable<CreateStoreWithinCompanyDto>? Stores = default) : IRequest<Result<Guid>>
{
    internal ValidationResult Validate() => new Validator().Validate(this);
    internal Company ToEntity()
    {
        var companyId = Guid.NewGuid();

        return new()
        {
            Id = companyId,
            Name = Name!,
            Stores = Stores?.Select(e => e.ToEntity(companyId)).ToHashSet() ?? []
        };
    }

    private class Validator : AbstractValidator<CreateCompanyRequest>
    {
        public Validator()
        {
            RuleFor(e => e.Name)
                .NotEmpty();

            RuleForEach(e => e.Stores)
                .SetValidator(new CreateStoreWithinCompanyDto.Validator());
        }
    }
}