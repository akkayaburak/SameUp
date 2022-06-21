using Domain;
using MediatR;
using Persistence;

namespace Application.MachineCategories
{
    public class Details
    {
         public class Query : IRequest<MachineCategory>
         {
             public int Id { get; set; }
         }

        public class Handler : IRequestHandler<Query, MachineCategory>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<MachineCategory> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.MachineCategories.FindAsync(request.Id);
            }
        }
    }
}