using DomainLayer.Models;
using DomainLayer.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracts
{
    public  interface IUnitOfWork
    {

        //IGenericReposatory<Product,int>ProductRepo { get; }
        Task<int> SaveChangesAsync();

        IGenericReposatory<TEntity, Tkey> GetReposatory<TEntity, Tkey>() 
            where TEntity : BaseEntity<Tkey>;
       

    }
}
