﻿using MediatR;
using StoresManagement.Application.GetCompany;
using StoresManagement.Domain.Repositories;

namespace StoresManagement.Application.ListCompanies;

internal class ListCompaniesQueryRequestHandler(ICompaniesRepository repository)
    : IRequestHandler<ListCompaniesQueryRequest, IEnumerable<GetCompanyResponse>>
{
    public async Task<IEnumerable<GetCompanyResponse>> Handle(ListCompaniesQueryRequest request, CancellationToken cancellationToken)
    {
        var companies = await repository.GetAsync(cancellationToken);
        return companies.Select(GetCompanyResponse.FromEntity);
    }
}