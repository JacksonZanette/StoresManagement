using FluentResults;
using MediatR;
using StoresManagement.Application.Extensions;
using StoresManagement.Domain.Repositories;

namespace StoresManagement.Application.CreateCompany;

public class CreateCompanyRequestHandler(ICompanyRepository companyRepository) : IRequestHandler<CreateCompanyRequest, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validate();

        if (!validationResult.IsValid)
            return validationResult.ToFluentResult();

        var company = request.ToEntity();

        await companyRepository.CreateAsync(company, cancellationToken);

        return Result.Ok(company.Id);
    }
}