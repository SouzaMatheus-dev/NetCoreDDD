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
            var contatos = _contasRepository.GetAll();
            return View(contatos);
        }

        [HttpGet]
        public IEnumerable<Contas> GetContas()
        {
            var contatos = _contasRepository.GetAll();
            return (IEnumerable<Contas>)View(contatos);
        }

        //[HttpGet("{id}")]
        //public ActionResult<Contas> GetConta(int id)
        //{
        //    var contato = _contasRepository.GetById(id);
        //    if (contato == null)
        //    {
        //        return NotFound(new { message = $"Conta de id={id} não encontrado" });
        //    }
        //    return contato;
        //}

        [HttpGet]
        public ActionResult Cadastrar()
        {
            var modelo = new Contas();
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Cadastrar(Contas modelo)
        {
            ValidatorContas validator = new ValidatorContas();
            var validationResult = validator.Validate(modelo);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _contasService.Save(modelo);

            return Ok();
        }
    }
}