using FluentResults;
using FluentValidation.Results;

namespace StoresManagement.Application.Extensions;

public static class ValidationResultExtensions
{
    public static Result ToFluentResult(this ValidationResult validationResult)
    {
        return validationResult.IsValid
            ? Result.Ok()
            : Result.Fail(validationResult.Errors.Select(e => e.ErrorMessage));
    }
}