using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasBancarias.Domain.Models
{
    public class ValidatorContas : AbstractValidator<Contas>
    {
        public ValidatorContas()
        {
            RuleFor(x => x.CpfOuCnpj)
                .NotEmpty().WithMessage("Informe um CPF ou CNPJ válido");

            RuleFor(x => x.NomeOuRazaoSocial)
                .NotEmpty().WithMessage("Informe seu Nome ou a Razão Social");

            RuleFor(x => x.NumeroConta)
                .NotEmpty().WithMessage("Informe o número da sua conta");

            RuleFor(x => x.NumeroAgencia)
                .NotEmpty().WithMessage("Informe o número da sua agência");
        }
    }
}