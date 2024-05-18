using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uplay.Application.Models.Abouts.Validators
{
    public class SaveAboutFileRequestValidator : BaseValidator<SaveAboutFileRequest>
    {
        public SaveAboutFileRequestValidator()
        {
            RuleFor(a => a.File).NotNull().NotEmpty().WithMessage("File is required"); ;
        }
    }
}
