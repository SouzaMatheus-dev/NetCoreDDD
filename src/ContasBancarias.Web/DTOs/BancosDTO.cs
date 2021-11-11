using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContasBancarias.Web.DTOs
{
    public class BancosDTO
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Ativo { get; set; }
    }
}