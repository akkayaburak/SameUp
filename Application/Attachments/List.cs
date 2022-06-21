using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Attachments
{
    public class List
    {
         public class Query : IRequest<Result<List<Attachment>>>
         {
             public int machineTypeId { get; set; }
         }

        public class Handler : IRequestHandler<Query, Result<List<Attachment>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Attachment>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var attachments = await _context.Attachments
                .Where(x => x.MachineTypeId == request.machineTypeId)
                .ToListAsync();

                return Result<List<Attachment>>.Success(attachments);
            }
        }
    }
}