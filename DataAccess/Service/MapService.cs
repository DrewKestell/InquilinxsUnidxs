using DataAccess.FormObject;
using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Service
{
    public class MapService : Service
    {
        public List<Building> GetBuildings()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Buildings
                    .Include("State")
                    .ToList();
            }
        }

        public void UpdateGeolocation(List<MapBuildingFormObject> formObjects)
        {
            using (var context = this.GetApplicationContext())
            {
                foreach (var building in formObjects)
                {
                    var buildingToUpdate = context.Buildings.Single(b => b.ID == building.ID);
                    buildingToUpdate.Latitude = building.Latitude;
                    buildingToUpdate.Longitude = building.Longitude;
                }                
                context.SaveChanges();
            }
        }
    }
}