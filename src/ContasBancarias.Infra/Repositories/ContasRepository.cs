using ContasBancarias.Domain.Models;
using ContasBancarias.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasBancarias.Infra.Repositories
{
    public class ContasRepository : Repository<Contas>
    {
        public ContasRepository(AppDbContext context) : base(context)
        { }

        public override Contas GetById(int id)
        {
            var query = _context.Set<Contas>().AsNoTracking().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Contas> GetAll()
        {
            var query = _context.Set<Contas>().AsNoTracking();

            return query.Any() ? query.ToList() : new List<Contas>();
        }
    }
}