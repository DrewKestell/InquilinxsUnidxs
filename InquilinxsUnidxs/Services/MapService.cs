using DataAccess.Model;
using InquilinxsUnidxs.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InquilinxsUnidxs.Services
{
    public class MapService : DataAccess.Service.MapService
    {
        public MapPresenter GetMapPresenter()
        {
            var buildings = base.GetBuildings();
            return new MapPresenter(buildings);
        }       
    }
}