using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uplay.Application.Models
{
    public class BaseValidator<T> : AbstractValidator<T> where T : class
    {
        public BaseValidator() : base()
        {
        }
    }

}
