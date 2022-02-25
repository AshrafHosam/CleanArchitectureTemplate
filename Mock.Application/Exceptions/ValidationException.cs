using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace Mock.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; }
        public ValidationException(FluentValidation.Results.ValidationResult validationResult)
        {
            Errors = new List<string>();
            foreach (var error in validationResult.Errors)
                Errors.Add(error.ErrorMessage);
        }
    }
}
