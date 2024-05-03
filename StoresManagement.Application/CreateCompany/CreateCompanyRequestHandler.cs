using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoresManagement.Application.CreateCompany;

public class CreateCompanyRequestHandler : IRequestHandler<CreateCompanyRequest, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreateCompanyRequest request, CancellationToken cancellationToken) => throw new NotImplementedException();
}