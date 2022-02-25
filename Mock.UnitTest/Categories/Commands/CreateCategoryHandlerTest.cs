using AutoMapper;
using Microsoft.Extensions.Configuration;
using Mock.Application.Contracts.Persistence;
using Mock.Application.Features.Categories;
using Mock.Application.Profiles;
using Mock.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Mock.UnitTest.Mocks;
using System.Threading;
using Mock.Application.Features.Categories.Commands.CreateCategory;

namespace Mock.UnitTest.Categories.Commands
{
    public class CreateCategoryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepo<Category>> _mockCategoryRepo;
        public CreateCategoryHandlerTest()
        {
            _mockCategoryRepo = RepoMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }


        [Fact]
        public async Task Can_create_category()
        {
            //var handler = new CreateCategoryCommandHandler(_mockCategoryRepo.Object, _mapper, null);
            var handler = new CreateCategoryCommandHandler(_mockCategoryRepo.Object, _mapper);
            await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

            var allCategories = await _mockCategoryRepo.Object.GetAllAsync();
            allCategories.Count().ShouldBe(5);
        }

    }
}