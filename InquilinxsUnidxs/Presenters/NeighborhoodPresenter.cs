using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InquilinxsUnidxs.Presenters
{
    public class NeighborhoodPresenter
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public List<Tuple<int, string>> Buildings { get; private set; }

        public NeighborhoodPresenter() { }

        public NeighborhoodPresenter(Neighborhood neighborhood)
        {
            ID = neighborhood.ID;
            Name = neighborhood.Name;
            Buildings = neighborhood.Buildings.Select(b => Tuple.Create(b.ID, b.FullAddress)).ToList();
        }
    }
}