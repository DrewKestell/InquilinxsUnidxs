using DataAccess.Context;
using DataAccess.Model;
using Services.DTO;
using Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services
{
    public class SuperTupleService : ISuperTupleService
    {
        readonly ApplicationContext context; 

        public SuperTupleService(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<SuperTuple<T>> GetAll<T>(Expression<Func<ApplicationContext, IEnumerable<IEntity<T>>>> expression) =>
            ((IEnumerable<IEntity<T>>)context.GetType()
                .GetProperty(((MemberExpression)expression.Body).Member.Name)
                .GetValue(context))
                .Convert();

    }
}