using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.programmingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageEntityCommandValidator : AbstractValidator<CreateProgrammingLanguageEntityCommand>
    {
        public CreateProgrammingLanguageEntityCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
