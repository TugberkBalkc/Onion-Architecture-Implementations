using EksiSozluk.API.Application.CrossCuttingConcerns.Validation;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Pipelines.Validation
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validatorsOfRequests;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validatorsOfRequests)
        {
            _validatorsOfRequests = validatorsOfRequests;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _validatorsOfRequests.ToList().ForEach(validator =>
            {
                ValidationTool.Validate(validator, request);
            });

            return next();
        }
    }
}
