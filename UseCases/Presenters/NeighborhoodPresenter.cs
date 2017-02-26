using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UseCases.Presenters
{
    public class NeighborhoodPresenter
    {
        public IEnumerable<Tuple<int, string>> Buildings { get; }
        public int ID { get; }
        public string Name { get; }

        public NeighborhoodPresenter() { }

        public NeighborhoodPresenter(NeighborhoodDTO neighborhood)
        {
            Buildings = neighborhood.Buildings.Select(b => Tuple.Create(b.ID, b.FullAddress));
            ID = neighborhood.ID;
            Name = neighborhood.Name;
        }
    }
}