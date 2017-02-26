using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace UseCases.Presenters
{
    public class EntityValidationErrorsPresenter
    {
        public string EntityName { get; }
        public IDictionary<string, IEnumerable<string>> ValidationErrors { get; }

        public EntityValidationErrorsPresenter(DbEntityValidationResult entity)
        {
            EntityName = entity.Entry.Entity.GetType().Name;

            ValidationErrors = entity.ValidationErrors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(group => group.Key, group => group.Select(e => e.ErrorMessage));
        }
    }
}