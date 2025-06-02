using System;

namespace Travello_Application.Common.Result;

public static class GeneralResultMapping
{

    public static GeneralResult MapErrorToGeneralResult(
        this FluentValidation.Results.ValidationResult validationResult)
    {
        GeneralResult generalResult = new GeneralResult();
        generalResult.Success = false;
        generalResult.Message = "Validation failed";
        generalResult.Errors = new List<ResultError>();
        foreach (var error in validationResult.Errors)
        {
            generalResult.Errors.Add(new ResultError
            {
                Message = error.ErrorMessage,
                Code = error.ErrorCode
            });
        }
        return generalResult;
    }
}


