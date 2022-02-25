using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Application.Features.Categories
{
    public class GetCategoriesListQuery : IRequest<List<CategoryVM>>
    {
    }
}
