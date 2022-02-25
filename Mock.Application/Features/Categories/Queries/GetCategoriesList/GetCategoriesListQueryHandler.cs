using AutoMapper;
using MediatR;
using Mock.Application.Contracts.Persistence;
using Mock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mock.Application.Features.Categories
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryVM>>
    {
        private readonly IAsyncRepo<Category> _categoryRepo;
        private readonly IMapper _mapper;
        public GetCategoriesListQueryHandler(IAsyncRepo<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<List<CategoryVM>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = await _categoryRepo.GetAllAsync();
            return _mapper.Map<List<CategoryVM>>(allCategories);
            //throw new NotImplementedException();
        }
    }
}
