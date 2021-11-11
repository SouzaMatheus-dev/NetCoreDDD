using ContasBancarias.Domain.Interfaces;
using ContasBancarias.Domain.Models;
using ContasBancarias.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContasBancarias.Web.Controllers
{
    public class ContasController : Controller
    {
        private readonly ContasService _contasService;
        private readonly IRepository<Contas> _contasRepository;

        public ContasController(ContasService contasService,
            IRepository<Contas> contasRepository)
        {
            _contasService = contasService;
            _contasRepository = contasRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var contatos = _contasService.BuscarTodasContas();
            return View(contatos);
        }

        [HttpGet]
        public IEnumerable<Contas> GetContas()
        {
            var contatos = _contasService.BuscarTodasContas();
            return (IEnumerable<Contas>)View(contatos);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            var modelo = new ContasDTO();
            modelo.Bancos = _contasService.BuscarTodosBancos();

            return View(modelo);
        }

        [HttpPost]
        public ActionResult Cadastrar(ContasDTO modelo)
        {
            ValidatorContas validator = new ValidatorContas();

            Contas conta = new Contas();
            conta = SetDtoToConta(modelo, conta);

            var validationResult = validator.Validate(conta);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _contasService.Save(conta);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var modelo = new ContasDTO();
            var conta = _contasService.BuscarConta(Id);

            if (conta == null)
            {
                return NotFound(new { message = $"Conta de id={Id} não encontrado" });
            }

            modelo = SetContaToDto(modelo, conta);
            modelo.Bancos = _contasRepository.GetAllBancos();

            return View(modelo);
        }

        [HttpPost]
        public ActionResult Editar(ContasDTO modelo)
        {
            ValidatorContas validator = new ValidatorContas();

            var conta = _contasService.BuscarConta(modelo.Id);
            conta = SetDtoToConta(modelo, conta);

            var validationResult = validator.Validate(conta);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _contasService.Edit(conta);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Deletar(int Id)
        {
            var modelo = new ContasDTO();
            var conta = _contasService.BuscarConta(Id);

            if (conta == null)
            {
                return NotFound(new { message = $"Conta de id={Id} não encontrado" });
            }

            modelo = SetContaToDto(modelo, conta);
            modelo.Bancos = _contasService.BuscarTodosBancos();

            return View(modelo);
        }

        [HttpPost]
        public ActionResult Deletar(ContasDTO modelo)
        {
            ValidatorContas validator = new ValidatorContas();

            var conta = _contasService.BuscarConta(modelo.Id);
            conta = SetDtoToConta(modelo, conta);

            var validationResult = validator.Validate(conta);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _contasService.Delete(conta);

            return RedirectToAction("Index");
        }

        public ContasDTO SetContaToDto(ContasDTO modelo, Contas conta)
        {
            modelo.Id = conta.Id;
            modelo.NomeOuRazaoSocial = conta.NomeOuRazaoSocial;
            modelo.NumeroAgencia = conta.NumeroAgencia;
            modelo.NumeroConta = conta.NumeroConta;
            modelo.EhAtivo = conta.EhAtivo;
            modelo.CpfOuCnpj = conta.CpfOuCnpj;
            modelo.BancoId = conta.BancoId;

            return modelo;
        }

        public Contas SetDtoToConta(ContasDTO modelo, Contas conta)
        {
            conta.NomeOuRazaoSocial = modelo.NomeOuRazaoSocial;
            conta.NumeroAgencia = modelo.NumeroAgencia;
            conta.NumeroConta = modelo.NumeroConta;
            conta.EhAtivo = modelo.EhAtivo;
            conta.CpfOuCnpj = modelo.CpfOuCnpj;
            conta.BancoId = modelo.BancoId;

            return conta;
        }
    }
}