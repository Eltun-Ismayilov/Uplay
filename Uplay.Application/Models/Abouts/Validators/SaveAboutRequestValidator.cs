using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Application.Models.Faqs;

namespace Uplay.Application.Models.Abouts.Validators
{
    public class SaveAboutRequestValidator : BaseValidator<SaveAboutRequest>
    {
        public SaveAboutRequestValidator()
        {
            RuleFor(a => a.AboutFiles).NotNull().NotEmpty()
                      .ForEach(t => t.SetValidator(new SaveAboutFileRequestValidator()));
            RuleFor(a => a.AboutTypes).NotNull().NotEmpty()
                     .ForEach(t => t.SetValidator(new SaveAboutTypeRequestValidator()));
        }
    }
}
