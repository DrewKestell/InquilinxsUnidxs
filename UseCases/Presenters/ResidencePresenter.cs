using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UseCases.Presenters
{
    public class ResidencePresenter
    {
        public IEnumerable<SuperTuple<int>> AllBuildings { get; }
        public string BuildingAddress { get; }
        public int BuildingID { get; }
        public int ID { get; }
        public string Name { get; }                
        public IEnumerable<Tuple<int, string>> Renters { get; }
        public IEnumerable<CommentPresenter> ResidenceComments { get; }


        public ResidencePresenter(IEnumerable<SuperTuple<int>> allBuildings)
        {
            AllBuildings = allBuildings;
        }

        public ResidencePresenter(ResidenceDTO residence, IEnumerable<SuperTuple<int>> allBuildings) : this(allBuildings)
        {
            ID = residence.ID;
            Name = residence.Name;
            BuildingID = residence.Building.ID;
            BuildingAddress = residence.Building.FullAddress;
            Renters = residence.Renters.Select(r => Tuple.Create(r.ID, r.FullName)).ToList();
            ResidenceComments = residence.ResidenceComments.OrderByDescending(c => c.LastUpdated).Select(c => new CommentPresenter(c)).ToList();
        }
    }
}