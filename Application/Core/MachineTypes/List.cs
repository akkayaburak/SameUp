using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Core.MachineTypes
{
    public class List
    {
        public class Query : IRequest<Result<List<MachineType>>>
         {
             public int categoryId { get; set; }
         }

        public class Handler : IRequestHandler<Query, Result<List<MachineType>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<MachineType>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var machineTypes = await _context.MachineTypes
                .Where(x => x.MachineCategoryId == request.categoryId)
                .ToListAsync();

                return Result<List<MachineType>>.Success(machineTypes);
            }
        }
    }
}