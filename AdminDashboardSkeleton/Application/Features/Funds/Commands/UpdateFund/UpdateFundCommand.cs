using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Funds.Commands.UpdateFund
{
    public class UpdateFundCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string ISINNumber { get; set; } = "";
        public string Currency { get; set; } = "";
        public string Name { get; set; } = "";
        public string Management { get; set; } = "";
        public string Focus { get; set; } = "";
        public string Type { get; set; } = "";
        public string PerformanceYTD { get; set; } = "";
        public string Performance1Year { get; set; } = "";
        public string Performance3Year { get; set; } = "";
        public string Performance5Year { get; set; } = "";
        public string PerformanceFromBeggining { get; set; } = "";
        public string PerformanceActualMinus9 { get; set; } = "";
        public string PerformanceActualMinus8 { get; set; } = "";
        public string PerformanceActualMinus7 { get; set; } = "";
        public string PerformanceActualMinus6 { get; set; } = "";
        public string PerformanceActualMinus5 { get; set; } = "";
        public string PerformanceActualMinus4 { get; set; } = "";
        public string PerformanceActualMinus3 { get; set; } = "";
        public string PerformanceActualMinus2 { get; set; } = "";
        public string PerformanceActualMinus1 { get; set; } = "";
        public string PerformanceAverage { get; set; } = "";

        public string VolatilityArrayAsString { get; set; }
        public string SharpRateArrayAsString { get; set; }
        public string BestMonthArrayAsString { get; set; }
        public string WorstMonthArrayAsString { get; set; }
        public string MaxLossArrayAsString { get; set; }
        public string OverFulFilmentArrayAsString { get; set; }

        public string Url { get; set; }

        public string MonthlyPerformanceAsString { get; set; }
        public class UpdateFundCommandHandler : IRequestHandler<UpdateFundCommand, Response<int>>
        {
            private readonly IFundRepositoryAsync _fundRepository;
            public UpdateFundCommandHandler(IFundRepositoryAsync fundRepository)
            {
                _fundRepository = fundRepository;
            }
            public async Task<Response<int>> Handle(UpdateFundCommand command, CancellationToken cancellationToken)
            {
                var fund = await _fundRepository.GetByIdAsync(command.Id);

                if (fund == null)
                {
                    throw new ApiException($"Fund Not Found.");
                }
                else
                {
                    fund.Name = command.Name;
                    fund.ISINNumber = command.ISINNumber;
                    fund.Management = command.Management;
                    await _fundRepository.UpdateAsync(fund);
                    return new Response<int>(fund.Id);
                }
            }
        }
    }
}
