using ContasBancarias.Domain.Interfaces;
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
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public virtual TEntity GetById(int id)
        {
            var query = _context.Set<TEntity>().Where(e => e.Id == id);
            if (query.Any())
                return query.FirstOrDefault();
            return null;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var query = _context.Set<TEntity>();
            if (query.Any())
                return query.ToList();
            return new List<TEntity>();
        }

        public virtual List<Bancos> GetAllBancos()
        {
            var query = _context.Set<Bancos>();
            if (query.Any())
                return query.ToList();
            return new List<Bancos>();
        }

        public virtual void Save(Contas entity)
        {
            _context.Set<Contas>().Add(entity);

            _context.SaveChanges();
        }

        //public virtual void Save(TEntity entity)
        //{
        //    _context.Set<TEntity>().Add(entity);

        //    _context.SaveChanges();
        //}

        public virtual void Edit(Contas entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}