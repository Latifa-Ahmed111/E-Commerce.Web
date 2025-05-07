using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Presistance.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Reposatories
{
    public class GenericReposatory<TEntity, Tkey>(StoreDbContext context) : IGenericReposatory<TEntity, Tkey> where TEntity :BaseEntity<Tkey>
    {

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        =>await context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(Tkey id)
            => await context.Set<TEntity>().FindAsync(id);
        

        public void Add(TEntity entity)
        => context.Set<TEntity>().Add(entity);
        public void Update(TEntity entity)
        => context.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity)
        => context.Set<TEntity>().Remove(entity);




    }
}
