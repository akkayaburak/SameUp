using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Core.MachineBrands
{
    public class List
    {
        public class Query : IRequest<Result<List<MachineBrand>>>
         {
             public int categoryId { get; set; }
         }

        public class Handler : IRequestHandler<Query, Result<List<MachineBrand>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<MachineBrand>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var machineBrands = await _context.MachineBrands
                .Where(x => x.MachineCategoryId == request.categoryId)
                .ToListAsync();

                return Result<List<MachineBrand>>.Success(machineBrands);
            }
        }
    }
}