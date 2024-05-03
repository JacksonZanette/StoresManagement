using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoresManagement.Application.CreateCompany;

public class CreateStoreRequestHandler : IRequestHandler<CreateStoreRequest, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreateStoreRequest request, CancellationToken cancellationToken) => throw new NotImplementedException();
}