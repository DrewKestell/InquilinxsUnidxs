using DataAccess.Enums;
using DataAccess.Models;

namespace InquilinxsUnidxs.Presenters
{
    public class StatePresenter
    {
        public States ID { get; private set; }
        public string Abbreviation { get; private set; }
        public string Name { get; private set; }

        public StatePresenter() { }

        public StatePresenter(State state)
        {
            ID = state.ID;
            Abbreviation = state.Abbreviation;
            Name = state.Name;
        }
    }
}