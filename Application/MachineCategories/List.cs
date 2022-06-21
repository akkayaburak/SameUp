using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.MachineCategories
{
    public class List
    {
        public class Query : IRequest<Result<List<MachineCategory>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<MachineCategory>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<MachineCategory>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var machineCategories = await _context.MachineCategories.ToListAsync();
                return Result<List<MachineCategory>>.Success(machineCategories);
            }
        }
    }
}