using DataAccess.Enum;
using DataAccess.Model;

namespace Services.DTO
{
    public class StateDTO
    {
        public States ID { get; }
        public string Abbreviation { get; }
        public string Name { get; }

        public StateDTO(State state)
        {
            ID = state.ID;
            Abbreviation = state.Abbreviation;
            Name = state.Name;
        }
    }
}