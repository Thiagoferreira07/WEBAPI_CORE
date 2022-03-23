using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WEBAPI_CORE.Application.Interfaces.Repositories;
using WEBAPI_CORE.Domain.Entities;

namespace WEBAPI_CORE.Application.Features.Funcionarios.Commands.CreateFuncionario
{
    public class CreateFuncionarioCommandValidator : AbstractValidator<CreateFuncionarioCommand>
    {
        private readonly IFuncionarioRepositoryAsync funcionarioRepository;

        public CreateFuncionarioCommandValidator(IFuncionarioRepositoryAsync funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;


            RuleFor(p => p.Nome_Lider)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(IsUniqueBarcode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Numero_de_chapa)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(IsUniqueBarcode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Sobrenome)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueBarcode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }

        private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        {
            return await funcionarioRepository.IsUniqueBarcodeAsync(barcode);
        }
    }
}
