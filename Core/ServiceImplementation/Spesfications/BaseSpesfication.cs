using DomainLayer.Contracts;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Spesfication
{
    public abstract class BaseSpesfication<TEntity, Tkey> : ISpeesfication<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {

        public BaseSpesfication(Expression<Func<TEntity, bool>>? PassedExpression)
        {
            Criteria = PassedExpression;


        }

        public Expression<Func<TEntity, bool>>? Criteria { get; private set; }

        public List<Expression<Func<TEntity, object>>> includeExpression { get; } = new List<Expression<Func<TEntity, object>>>();

        protected  void AddInclude(Expression<Func<TEntity, object>>IncludeExp)
        {
            includeExpression.Add(IncludeExp);

        }
    }
    
}
