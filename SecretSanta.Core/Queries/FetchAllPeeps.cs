using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using System.Threading.Tasks;
using SecretSanta.Core.Domain;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace SecretSanta.Core.Queries
{
    public class FetchAllPeeps
    {
        public class Query : IRequest<Result>
        {
            public string Year { get; set; }
            public bool Randomise { get; set; }
        }

        public class Result
        {
            public bool Success { get; set; }
            public string Exception { get; set; }
            public List<Peeps> Peeps { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Result>
        {
            public Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new Result { Success = false };
                
                try
                {
                    using (var db = new Domain.Contexts.SantaContext())
                    {
                        // Find a random result within the current year
                        var records = db.Peeps
                            .Where((q => q.Year == request.Year))
                            .AsNoTracking();
                        
                        if (records != null)
                        {
                            if(request.Randomise)
                                records = records.OrderBy(r => Guid.NewGuid()); // Retrieve a random result
                            
                            result.Success = true;
                            result.Peeps = records.ToList();
                        }
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
