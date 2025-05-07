using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Reposatories
{
    public class UnitOfWork(StoreDbContext context) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _Reposatories =new Dictionary<string, object>();
        public IGenericReposatory<TEntity, Tkey> GetReposatory<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            //TypeNme
            var TypeNme = typeof(TEntity).Name;

            if (_Reposatories.ContainsKey(TypeNme))
            {
                return (IGenericReposatory<TEntity, Tkey>)_Reposatories[TypeNme];

            }
            var repo = new GenericReposatory<TEntity, Tkey>(context);

            _Reposatories.Add(TypeNme, repo);

            return repo;

        }

        public async Task<int> SaveChangesAsync()
        {
          return await context.SaveChangesAsync();
        }
    }
}
