using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace InquilinxsUnidxs.Presenters
{
    public class EntityValidationErrorsPresenter
    {
        public string EntityName { get; private set; }
        public Dictionary<string, IEnumerable<string>> ValidationErrors { get; private set; }

        public EntityValidationErrorsPresenter(DbEntityValidationResult entity)
        {
            EntityName = entity.Entry.Entity.GetType().Name;

            ValidationErrors = entity.ValidationErrors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(group => group.Key, group => group.Select(e => e.ErrorMessage));
        }
    }
}