using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var validationContext = new ValidationContext<object>(entity);

            var validationResult = validator.Validate(validationContext);

            var validationErrorsFailures = validationResult
                                           .Errors
                                           .Where(validationFailures => validationFailures is not null)
                                           .ToList();

            if (validationErrorsFailures.Count != 0)
                throw new ValidationException(validationErrorsFailures);
        }
    }
}
