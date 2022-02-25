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

namespace Mock.UnitTest.Categories.Queries
{
    public class GetCategoriesListQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepo<Category>> _mockCategoryRepository;

        public GetCategoriesListQueryHandlerTest()
        {
            _mockCategoryRepository = RepoMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetCategoriesListQueryHandler(_mockCategoryRepository.Object, _mapper);

            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryVM>>();

            result.Count.ShouldBe(4);
        }

    }
}
