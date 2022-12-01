using System;
using System.Linq;
using MediatR;
using System.Threading.Tasks;
using SecretSanta.Core.Domain;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace SecretSanta.Core.Queries
{
    public class HasIndividualPickedAlready
    {
        public class Query : IRequest<bool>
        {
            public int PersonPicking { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, bool>
        {
            private Domain.Contexts.SantaContext _db;
            public QueryHandler(Domain.Contexts.SantaContext db) => _db = db;
            
            public Task<bool> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = false;
                
                try
                {
                    var record = _db.Peeps
                        .Where(q => q.ID == request.PersonPicking)
                        .AsNoTracking()
                        .Single();

                    if (record != null)
                    {
                        result = record.picking;
                    }
                } 
                catch (Exception ex)
                {
                    //result.Exception = ex.Message;
                }

                return Task.FromResult(result);
            }
        }
    }
}
