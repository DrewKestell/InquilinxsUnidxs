using DataAccess.Model;
using Services.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Services.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<SuperTuple<T>> Convert<T>(this IEnumerable<IEntity<T>> entities) =>
            entities.Select(e => SuperTuple.Create(e.ID, e.Name));
    }
}