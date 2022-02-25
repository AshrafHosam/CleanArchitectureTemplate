using FluentValidation;
using Mock.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepo categoryRepo;

        public CreateCategoryCommandValidator()
        {
        }

        public CreateCategoryCommandValidator(ICategoryRepo _categoryRepo)
        {
            categoryRepo = _categoryRepo;

            RuleFor(c => c.Name).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");


            //RuleFor(c => c).MustAsync(IsCategoryNameUnique).WithMessage("A category with the same name already exists");
        }
    }
}
