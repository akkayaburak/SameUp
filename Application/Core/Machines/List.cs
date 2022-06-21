using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Core.Machines
{
    public class List
    {
        public class Query : IRequest<Result<List<Machine>>>
         {
             public int categoryId { get; set; }
         }

        public class Handler : IRequestHandler<Query, Result<List<Machine>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Machine>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var machines = await _context.Machines.ToListAsync();
                return Result<List<Machine>>.Success(machines);
            }
        }
    }
}