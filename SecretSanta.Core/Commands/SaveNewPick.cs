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
            public bool PickedAlready { get; set; }
        }

        public class CommandHander : IRequestHandler<Command, bool>
        {
            private Domain.Contexts.SantaContext _db;
            public CommandHander(Domain.Contexts.SantaContext db) => _db = db;
            
            public Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var success = false;
                
                try
                {
                    var record = _db.WhoPickedWho
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
                        _db.Remove(record);
                        _db.SaveChanges();
                    }

                    _db.WhoPickedWho.Add(newPerson);
                    _db.SaveChanges();

                    // Indicate the person has picked someone
                    var PersonHasPickedSomeone = _db.Peeps.Single(s => s.ID == request.Picker);
                    PersonHasPickedSomeone.ToPick = true;
                    // Have they already used up their RePick option
                    if (request.PickedAlready == true)
                    {
                        PersonHasPickedSomeone.WhatNo = false;
                    }
                    _db.SaveChanges();

                    // Indicate this person has been picked
                    var PersonHasBeenPicked = _db.Peeps.Single(s => s.ID == request.NewPickee);
                    PersonHasBeenPicked.BeenPicked = true;
                    _db.SaveChanges();

                    success = true;
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
