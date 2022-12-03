using System;
using System.Linq;
using MediatR;
using System.Threading.Tasks;
using SecretSanta.Core.Domain;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace SecretSanta.Core.Queries
{
    public class FetchPeep
    {
        public class Query : IRequest<Result>
        {
            public int UserID { get; set; }
            public string Year { get; set; }
        }

        public class Result
        {
            public bool Success { get; set; }
            public string Exception { get; set; }
            public Peeps Peep { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Result>
        {
            private Domain.Contexts.SantaContext _db;
            public QueryHandler(Domain.Contexts.SantaContext db) => _db = db;
            
            public Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new Result { Success = false };
                
                try
                {
                    // Find a random result within the current year
                    var record = _db.Peeps
                        .Where((q => q.ID == request.UserID
                            && q.Year == request.Year))
                        .AsNoTracking()
                        .FirstOrDefault();
                    
                    if (record != null)
                    {
                        result.Success = true;
                        result.Peep = record;
                    }
                } 
                catch (Exception ex)
                {
                    result.Exception = ex.Message;
                }

                return Task.FromResult(result);
            }
        }
    }
}
