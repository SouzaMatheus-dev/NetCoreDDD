using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasBancarias.Domain.Models
{
    public class Bancos : BaseEntity
    {
        public Bancos()
        {
        }

        public Bancos(int id, string codigo, string nome) : this()
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
        }

        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
    }
}