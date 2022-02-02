using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSanta.Core.Commands
{
    public class SaveNewPick
    {
        public class Command : IRequest<bool>
        {
            public int Picker { get; set; }
            public int NewPickee { get; set; }
            public string Year { get; set; }
        }

        public class CommandHander : IRequestHandler<Command, bool>
        {
            public Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var success = false;
                
                try
                {
                    using (var db = new Domain.Contexts.SantaContext())
                    {
                        var record = db.WhoPickedWho
                            .FirstOrDefault(e => e.Person1 == request.Picker
                                                 && e.Year == request.Year);

                        // Create new object
                        var newPerson = new Core.Domain.whopickedwho()
                        {
                            Person1 = request.Picker,
                            Person2 = request.NewPickee,
                            Year = request.Year
                        };
                        
                        // Have to remove the old record as it's part of a composite key
                        if (record != null)
                        {
                            db.Remove(record);
                            db.SaveChanges();
                        }

                        db.WhoPickedWho.Add(newPerson);
                        db.SaveChanges();
                        success = true;
                    }
                } 
                catch (Exception ex)
                {
                    success = false;
                }

                return Task.FromResult(success);
            }
        }
    }
}
