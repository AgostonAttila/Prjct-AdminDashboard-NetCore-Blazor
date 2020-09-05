using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Funds.Queries.GetAllFunds
{
    public class GetAllFundsQuery : IRequest<PagedResponse<IEnumerable<GetAllFundsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllFundsQueryHandler : IRequestHandler<GetAllFundsQuery, PagedResponse<IEnumerable<GetAllFundsViewModel>>>
    {
        private readonly IFundRepositoryAsync _fundRepository;
        private readonly IMapper _mapper;
        public GetAllFundsQueryHandler(IFundRepositoryAsync fundRepository, IMapper mapper)
        {
            _fundRepository = fundRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllFundsViewModel>>> Handle(GetAllFundsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllFundsParameter>(request);
            var fund = await _fundRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var fundViewModel = _mapper.Map<IEnumerable<GetAllFundsViewModel>>(fund);
            return new PagedResponse<IEnumerable<GetAllFundsViewModel>>(fundViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
