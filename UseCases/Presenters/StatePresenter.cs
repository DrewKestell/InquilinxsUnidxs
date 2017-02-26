using DataAccess.Enum;
using DataAccess.Model;

namespace UseCases.Presenters
{
    public class StatePresenter
    {
        public string Abbreviation { get; }
        public States? ID { get; }
        public string Name { get; }

        public StatePresenter() { }

        public StatePresenter(State state)
        {
            Abbreviation = state.Abbreviation;
            ID = state.ID;
            Name = state.Name;
        }
    }
}