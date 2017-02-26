using DataAccess.FormObject;
using System.Collections.Generic;

namespace UseCases
{
    public interface IUpdateGeolocation
    {
        void Execute(IEnumerable<MapBuildingFormObject> formObjects);
    }
}