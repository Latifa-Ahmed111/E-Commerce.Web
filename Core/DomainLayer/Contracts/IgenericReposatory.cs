using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracts
{
    public  interface IGenericReposatory<TEntity,Tkey> where TEntity: BaseEntity<Tkey>
    {

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Tkey id);

        Task<IEnumerable<TEntity>> GetAllAsync(ISpeesfication<TEntity, Tkey>Spec);
        Task<TEntity> GetByIdAsync(ISpeesfication<TEntity, Tkey> Spec);

        Task<int> CountAsync(ISpeesfication<TEntity, Tkey>Spec);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);


    }
}
