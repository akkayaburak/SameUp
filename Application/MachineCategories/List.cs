using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.MachineCategories
{
    public class List
    {
        public class Query : IRequest<List<MachineCategory>>
        {

        }

        public class Handler : IRequestHandler<Query, List<MachineCategory>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<MachineCategory>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.MachineCategories.ToListAsync();
            }
        }
    }
}