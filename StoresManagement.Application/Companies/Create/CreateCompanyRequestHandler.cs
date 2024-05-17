using FluentResults;
using MediatR;
using StoresManagement.Application.Extensions;
using StoresManagement.Core.Common;
using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Application.Companies.Create;

public class CreateCompanyRequestHandler(IRepository<Company> companiesRepository) : IRequestHandler<CreateCompanyRequest, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validate();

        if (!validationResult.IsValid)
            return validationResult.ToFluentResult();

        var company = request.ToEntity();

        await companiesRepository.AddAsync(company, cancellationToken);
        await companiesRepository.CommitAsync(cancellationToken);

        return Result.Ok(company.Id);
    }
}