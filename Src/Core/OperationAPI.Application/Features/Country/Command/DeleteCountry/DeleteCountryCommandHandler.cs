using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.Country.Command.DeleteCountry
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, bool>
    {

        private readonly ICountryService service;

        public DeleteCountryCommandHandler(ICountryService service)
        {
            this.service = service;
        }
        public async Task<bool> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var ObjDelete = await service.GetByIdAsync(request.id);

            if (ObjDelete == null)
            {
                // throw new Exception
                throw new NotFoundException(nameof(CountryDomain), $" With Id = [{request.id}]");
            }

            // exe
            var res = await service.DeleteAsync(ObjDelete);

            // return
            return res;
        }
    }
    
}
