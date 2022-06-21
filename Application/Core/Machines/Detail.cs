using Domain;
using MediatR;
using Persistence;

namespace Application.Core.Machines
{
    public class Detail
    {
        public class Query : IRequest<Result<Machine>>
         {
             public int Id { get; set; }
         }

        public class Handler : IRequestHandler<Query, Result<Machine>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Machine>> Handle(Query request, CancellationToken cancellationToken)
            {
                var machine = await _context.Machines.FindAsync(request.Id);

                return Result<Machine>.Success(machine);
            }
        }
    }
}