using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using SecretSanta.Core.Domain;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace SecretSanta.Core.Queries
{
    public class FetchWhoPersonPicked
    {
        public class Query : IRequest<Result>
        {
            public int PersonId { get; set; }
        }

        public class Result
        {
            public bool Success { get; set; }
            public string Exception { get; set; }
            public Peeps picked { get; set; }
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
                    var recds = 
                            _db.Peeps 
                                .Where(e 
                                    => _db.WhoPickedWho
                                        .Where(f => f.Person1 == request.PersonId)
                                        .Select(s => s.Person2)
                                        .FirstOrDefault() == e.ID)
                            .AsNoTracking()
                            .FirstOrDefault();

                        //SELECT * from `peeps` WHERE `ID` = (SELECT Person2 FROM whopickedwho WHERE Person1 = :whoPicked)");
                        
                        if (recds != null)
                        {
                            result.Success = true;
                            result.picked = recds;
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
