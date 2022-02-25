using Mock.Application.Contracts.Persistence;
using Mock.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.UnitTest.Mocks
{
    public class RepoMocks
    {
        public static Mock<IAsyncRepo<Category>> GetCategoryRepository()
        {

            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Concerts"
                },
                new Category
                {
                    Id = 2,
                    Name = "Musicals"
                },
                new Category
                {
                    Id = 3,
                    Name = "Conferences"
                },
                 new Category
                {
                    Id = 4,
                    Name = "Plays"
                }
            };

            var mockCategoryRepository = new Mock<IAsyncRepo<Category>>();
            mockCategoryRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });

            return mockCategoryRepository;
        }
    }
}
