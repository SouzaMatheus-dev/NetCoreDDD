using ContasBancarias.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasBancarias.Domain.Models
{
    public class ContasService
    {
        private readonly IRepository<Contas> _contaRepository;

        public ContasService(IRepository<Contas> contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public void Save(Contas conta)
        {
            _contaRepository.Save(conta);
        }

        public void Edit(Contas conta)
        {
            _contaRepository.Edit(conta);
        }
    }
}