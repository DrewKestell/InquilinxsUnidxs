using DataAccess.Model;

namespace InquilinxsUnidxs.Presenters
{
    public class NeighborhoodPresenter
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public NeighborhoodPresenter() { }

        public NeighborhoodPresenter(Neighborhood neighborhood)
        {
            ID = neighborhood.ID;
            Name = neighborhood.Name;
        }
    }
}