using DataAccess.FormObject;
using Services;
using System.Collections.Generic;

namespace UseCases
{
    public class UpdateGeolocation : IUpdateGeolocation
    {
        readonly IMapService mapService;

        public UpdateGeolocation(IMapService mapService)
        {
            this.mapService = mapService;
        }

        public void Execute(IEnumerable<MapBuildingFormObject> formObjects) => mapService.UpdateGeolocation(formObjects);
    }
}