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


        #region Creatria 
        public BaseSpesfication(Expression<Func<TEntity, bool>>? PassedExpression)
        {
            Criteria = PassedExpression;


        }

        public Expression<Func<TEntity, bool>>? Criteria { get; private set; }
        #endregion

        #region Include
        public List<Expression<Func<TEntity, object>>> includeExpression { get; } = new List<Expression<Func<TEntity, object>>>();

        

        protected  void AddInclude(Expression<Func<TEntity, object>>IncludeExp)
        {
            includeExpression.Add(IncludeExp);

        }
        #endregion

        #region Sorting
        public Expression<Func<TEntity, object>> orderby { get; private set; }

        public Expression<Func<TEntity, object>> orderbyDes { get; private set; }

        

        protected void AddorderBy(Expression<Func<TEntity, object>> orderbyExpression) => orderby = orderbyExpression;
        protected void AddorderDes(Expression<Func<TEntity, object>> orderbyDesExpression) => orderbyDes = orderbyDesExpression;


        #endregion



        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginated { get; set; }

        protected void Applypagination(int PageSize,int PageIndex)
        {
            IsPaginated = true;
            Take = PageSize;
            Skip = (PageIndex - 1) * PageSize;
        }


    }

}
