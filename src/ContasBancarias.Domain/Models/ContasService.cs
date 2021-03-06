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

        public void Delete(Contas conta)
        {
            _contaRepository.Delete(conta);
        }

        public IEnumerable<Contas> BuscarTodasContas()
        {
            try
            {
                return _contaRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Bancos> BuscarTodosBancos()
        {
            try
            {
                return _contaRepository.GetAllBancos();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Contas BuscarConta(int Id)
        {
            try
            {
                return _contaRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}