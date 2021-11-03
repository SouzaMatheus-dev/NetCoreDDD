using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasBancarias.Domain.Models
{
    public class Contas : BaseEntity
    {
        public Contas()
        {
            this.EhAtivo = true;
        }

        public int NumeroConta { get; set; }
        public int NumeroAgencia { get; set; }
        public string CpfOuCnpj { get; set; }
        public string NomeOuRazaoSocial { get; set; }
        public DateTime DataAbertura { get; } = DateTime.Now;
        public bool EhAtivo { get; set; }
        public int BancoId { get; set; }
        public Bancos Banco { get; set; }
    }
}