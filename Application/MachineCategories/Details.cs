using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.MachineCategories
{
    public class Details
    {
         public class Query : IRequest<Result<MachineCategory>>
         {
             public int Id { get; set; }
         }

        public class Handler : IRequestHandler<Query, Result<MachineCategory>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<MachineCategory>> Handle(Query request, CancellationToken cancellationToken)
            {
                var machineCategory = await _context.MachineCategories.FindAsync(request.Id);

                return Result<MachineCategory>.Success(machineCategory);
            }
        }
    }
}