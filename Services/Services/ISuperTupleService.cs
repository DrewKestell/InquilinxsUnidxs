using DataAccess.Context;
using DataAccess.Model;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services
{
    public interface ISuperTupleService
    {
        IEnumerable<SuperTuple<T>> GetAll<T>(Expression<Func<ApplicationContext, IEnumerable<IEntity<T>>>> expression);
    }
}