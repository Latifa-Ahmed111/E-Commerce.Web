using DomainLayer.Models;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracts
{
    public interface ISpeesfication<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {
        public Expression <Func<TEntity, bool>>? Criteria { get; }
        List<Expression<Func<TEntity, object>>>includeExpression { get; }






    }
}
