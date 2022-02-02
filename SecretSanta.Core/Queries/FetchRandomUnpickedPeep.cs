using System;
using System.Linq;
using MediatR;
using System.Threading.Tasks;
using SecretSanta.Core.Domain;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace SecretSanta.Core.Queries
{
    public class FetchRandomUnpickedPeep
    {
        public class Query : IRequest<Result>
        {
        }

        public class Result
        {
            public bool Success { get; set; }
            public string Exception { get; set; }
            public Peeps picked { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Result>
        {
            public Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new Result { Success = false };
                //$queryDB = $conn->query('SELECT * FROM `peeps` WHERE `picking` = 0 and `year` = (select currentyear from settings) order by rand()');        

                try
                {
                    using (var db = new Domain.Contexts.SantaContext())
                    {
                        // Get the current year
                        var currentYear = db.Settings
                            .OrderBy(o => o.ID)
                            .FirstOrDefault()?
                            .currentyear;

                        // Find a random result within the current year
                        var record = db.Peeps
                            .Where((q => !q.picking 
                                         && q.Year == currentYear))
                            .AsNoTracking()
                            .OrderBy(r => Guid.NewGuid()) // Retrieve a random result
                            .Take(1);

                        if (record != null)
                        {
                            result.Success = true;
                            result.picked = record.FirstOrDefault();
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
