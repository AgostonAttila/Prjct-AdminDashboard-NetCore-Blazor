using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Funds.Queries.GetFundById
{
    public class GetFundByIdQuery : IRequest<Response<Fund>>
    {
        public int Id { get; set; }
        public class GetFundByIdQueryHandler : IRequestHandler<GetFundByIdQuery, Response<Fund>>
        {
            private readonly IFundRepositoryAsync _fundRepository;
            public GetFundByIdQueryHandler(IFundRepositoryAsync fundRepository)
            {
                _fundRepository = fundRepository;
            }
            public async Task<Response<Fund>> Handle(GetFundByIdQuery query, CancellationToken cancellationToken)
            {
                var fund = await _fundRepository.GetByIdAsync(query.Id);
                if (fund == null) throw new ApiException($"Fund Not Found.");
                return new Response<Fund>(fund);
            }
        }
    }
}
