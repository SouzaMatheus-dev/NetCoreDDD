using ContasBancarias.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContasBancarias.Web.DTOs
{
    public class ContasDTO
    {
        public int Id { get; set; }

        public int NumeroConta { get; set; }

        public int NumeroAgencia { get; set; }

        public string CpfOuCnpj { get; set; }

        public string NomeOuRazaoSocial { get; set; }

        public bool EhAtivo { get; set; }

        public int BancoId { get; set; }
        public List<Bancos> Bancos { get; set; }
    }
}