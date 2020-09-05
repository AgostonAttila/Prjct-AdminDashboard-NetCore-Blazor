using Application.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Application.Features.Funds.Commands.CreateFund
{
    public class CreateFundValidator : AbstractValidator<CreateFundCommand>
    {
        private readonly IFundRepositoryAsync fundRepository;

        public CreateFundCommandValidator(IFundRepositoryAsync fundRepository)
        {
            this.fundRepository = fundRepository;

            RuleFor(p => p.ISINNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
                //.MustAsync(IsUniqueBarcode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        }

        //private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        //{
        //    return await fundRepository.IsUniqueBarcodeAsync(barcode);
        //}
    }
}
