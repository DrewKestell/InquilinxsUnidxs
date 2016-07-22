using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace InquilinxsUnidxs.Presenters
{
    public class EntityValidationResultPresenter
    {
        public List<EntityValidationErrorsPresenter> Entities { get; private set; }

        public EntityValidationResultPresenter(DbEntityValidationException ex)
        {
            Entities = ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)).ToList();
        }
    }
}