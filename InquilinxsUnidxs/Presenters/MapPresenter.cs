using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InquilinxsUnidxs.Presenters
{
    public class MapPresenter
    {
        public List<MapBuildingPresenter> Buildings { get; private set; }

        public MapPresenter(List<Building> buildings)
        {
            Buildings = buildings.Select(b => new MapBuildingPresenter(b)).ToList();
        }
    }
}