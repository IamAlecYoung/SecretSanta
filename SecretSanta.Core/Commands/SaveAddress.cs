using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSanta.Core.Commands
{
    public class SaveAddressDetails
    {
        public class Command : IRequest<bool>
        {
            public int PeepID { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string Address3 { get; set; }
            public string Postcode { get; set; }
            public string Extra { get; set; }
            public string Creepy { get; set; }
            public string Consent { get; set; }
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
                    var record = _db.Peeps
                            .FirstOrDefault(e => e.ID == request.PeepID);

                        // Have to remove the old record as it's part of a composite key
                        if (record != null)
                        {
                            if (request.Consent == "Yes")
                            {
                                record.address1 = request.Address1;
                                record.address2 = request.Address2;
                                record.address3 = request.Address3;
                                record.postcode = request.Postcode;
                                record.extra = request.Extra;
                                record.creepy = request.Creepy;
                                record.consent = request.Consent;
                            }
                            else
                            {
                                record.consent = request.Consent;
                            }
                            _db.SaveChanges();
                        }
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
