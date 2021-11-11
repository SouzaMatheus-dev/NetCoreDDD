using AutoMapper;
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
        private readonly IMapper _mapper;

        public ContasController(ContasService contasService,
            IRepository<Contas> contasRepository,
            IMapper mapper)
        {
            _contasService = contasService;
            _contasRepository = contasRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var contas = _contasService.BuscarTodasContas();
            return View(contas);
        }

        [HttpGet]
        public IEnumerable<Contas> GetContas()
        {
            var contas = _contasService.BuscarTodasContas();
            return (IEnumerable<Contas>)View(contas);
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
            conta = _mapper.Map<Contas>(modelo);

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
                return NotFound(new { message = $"Conta de id = {Id} não encontrado" });
            }

            modelo = _mapper.Map<ContasDTO>(conta);
            modelo.Bancos = _contasRepository.GetAllBancos();

            return View(modelo);
        }

        [HttpPost]
        public ActionResult Editar(ContasDTO modelo)
        {
            ValidatorContas validator = new ValidatorContas();

            var conta = _contasService.BuscarConta(modelo.Id);
            conta = _mapper.Map<Contas>(modelo);

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
                return NotFound(new { message = $"Conta de id = {Id} não encontrado" });
            }

            modelo = _mapper.Map<ContasDTO>(conta);
            modelo.Bancos = _contasService.BuscarTodosBancos();

            return View(modelo);
        }

        [HttpPost]
        public ActionResult Deletar(ContasDTO modelo)
        {
            ValidatorContas validator = new ValidatorContas();

            var conta = _contasService.BuscarConta(modelo.Id);
            conta = _mapper.Map<Contas>(modelo);

            var validationResult = validator.Validate(conta);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _contasService.Delete(conta);

            return RedirectToAction("Index");
        }
    }
}