using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Funds.Commands.DeleteFundById
{
    public class DeleteFundByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteFundByIdCommandHandler : IRequestHandler<DeleteFundByIdCommand, Response<int>>
        {
            private readonly IFundRepositoryAsync _fundRepository;
            public DeleteFundByIdCommandHandler(IFundRepositoryAsync fundRepository)
            {
                _fundRepository = fundRepository;
            }
            public async Task<Response<int>> Handle(DeleteFundByIdCommand command, CancellationToken cancellationToken)
            {
                var fund = await _fundRepository.GetByIdAsync(command.Id);
                if (fund == null) throw new ApiException($"Fund Not Found.");
                await _fundRepository.RemoveAsync(fund);
                return new Response<int>(fund.Id);
            }
        }
    }
}
