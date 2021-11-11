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

        [Required]
        public int NumeroConta { get; set; }

        [Required]
        public int NumeroAgencia { get; set; }

        [Required]
        public string CpfOuCnpj { get; set; }

        [Required]
        public string NomeOuRazaoSocial { get; set; }

        public int BancoId { get; set; }
        public bool EhAtivo { get; set; }
        public List<Bancos> Bancos { get; set; }
    }
}