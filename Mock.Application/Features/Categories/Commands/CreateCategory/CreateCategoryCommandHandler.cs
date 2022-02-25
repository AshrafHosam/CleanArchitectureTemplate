using AutoMapper;
using MediatR;
using Mock.Application.Contracts.Infrastructure;
using Mock.Application.Contracts.Persistence;
using Mock.Application.Models.Mail;
using Mock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mock.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IAsyncRepo<Category> _categoryRepo;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        public CreateCategoryCommandHandler(ICategoryRepo categoryRepo, IMapper mapper, IEmailService emailService)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _emailService = emailService;
        }
        public CreateCategoryCommandHandler(IAsyncRepo<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        /* public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
         {
             //throw new NotImplementedException();
             var validator = new CreateCategoryCommandValidator(_categoryRepo);
             var validationResult = await validator.ValidateAsync(request);

             if (validationResult.Errors.Count > 0) throw new Exceptions.ValidationException(validationResult);

             var category = _mapper.Map<Category>(request);
             category = await _categoryRepo.AddAsync(category);

             var email = new Email()
             {
                 To = "ashrafhosam1997@gmail.com",
                 Subject = "A new category has been added ",
                 Body = $"A new category was created :{request}"
             };
             try
             {
                 await _emailService.SendEmail(email);
             }
             catch (Exception)
             {
                 throw;
             }
             return category.Id;
         }*/

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateCategoryCommandResponse();

            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCategoryCommandResponse.Success = false;
                createCategoryCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCategoryCommandResponse.Success)
            {
                var category = new Category() { Name = request.Name };
                category = await _categoryRepo.AddAsync(category);
                createCategoryCommandResponse.CategoryVM = _mapper.Map<CategoryVM>(category);
            }

            return createCategoryCommandResponse;
        }
    }
}
