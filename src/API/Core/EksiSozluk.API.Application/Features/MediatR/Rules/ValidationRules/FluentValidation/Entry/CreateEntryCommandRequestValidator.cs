using EksiSozluk.API.Application.Features.MediatR.Commands.Entry.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Rules.ValidationRules.FluentValidation.Entry
{
    public class CreateEntryCommandRequestValidator : AbstractValidator<CreateEntryCommandRequest>
    {
        public CreateEntryCommandRequestValidator()
        {
            this.RuleFor(e => e.UserId).NotEmpty();
            this.RuleFor(e => e.UserId).NotNull();

            this.RuleFor(e => e.EntrySubject).NotEmpty();
            this.RuleFor(e => e.EntrySubject).NotNull();
            this.RuleFor(e => e.EntrySubject).MinimumLength(5);
            this.RuleFor(e => e.EntrySubject).MaximumLength(100);

            this.RuleFor(e => e.EntryContent).NotEmpty();
            this.RuleFor(e => e.EntryContent).NotNull();
            this.RuleFor(e => e.EntryContent).MinimumLength(50);
        }
    }
}
