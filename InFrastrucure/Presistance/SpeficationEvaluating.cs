using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance
{
    public static class SpeficationEvaluating
    {

        //crateQuery
        public static IQueryable<TEntity> CreateQuery<TEntity,Tkey>(IQueryable<TEntity>InputQuery,ISpeesfication<TEntity,Tkey>spec)where TEntity : BaseEntity<Tkey>
        {

            var Query = InputQuery;
            if(spec.Criteria is not null )
            {

                Query = Query.Where(spec.Criteria);
            }
            if(spec.orderby is not null)
            {
                Query=Query.OrderBy(spec.orderby);

            }
            if (spec.orderbyDes is not null)
            {
                Query = Query.OrderByDescending(spec.orderbyDes);

            }

            if (spec.includeExpression is not null&&spec.includeExpression.Count>0)
            {
                Query = spec.includeExpression.Aggregate(Query,(currentQuerty,Exp)=> currentQuerty.Include(Exp));

            }
            if(spec.IsPaginated==true)
            {

                Query = Query.Skip(spec.Skip).Take(spec.Take);

            }


            return Query;

        }
    }
}
