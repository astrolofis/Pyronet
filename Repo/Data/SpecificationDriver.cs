using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Repo.Data
{
    public class SpecificationDriver<TEntity> where TEntity:EntityBase
    {
        public static IQueryable<TEntity> GetQueryable(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query= inputQuery;
            if(spec.Criteria != null)
            {
                query=query.Where(spec.Criteria);
            }
            if(spec.OrderBy != null)
            {
                query=query.OrderBy(spec.OrderBy);
            }
            if(spec.OrderByDescending != null)
            {
                query=query.OrderByDescending(spec.OrderByDescending);
            }
            if(spec.IsPagingEnabled)
            {
                query=query.Skip(spec.Skip).Take(spec.Take);
            }
            query=spec.Includes.Aggregate(query,(current,include)=>current.Include(include));
            return query;
        }
    }
}