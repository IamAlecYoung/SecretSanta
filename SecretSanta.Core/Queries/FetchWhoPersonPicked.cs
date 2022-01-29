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
            public whopickedwho picked { get; set; }
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
                        var recds = db.WhoPickedWho
                            .Where(q => q.Person1 == request.PersonId)
                            .AsNoTracking()
                            .FirstOrDefault();

                        if (recds != null)
                        {
                            result.Success = true;
                            result.picked = recds;
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
