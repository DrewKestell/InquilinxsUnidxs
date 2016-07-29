using DataAccess.Contexts;
using DataAccess.Enums;
using DataAccess.Models;
using System.Data.Entity.Migrations;

namespace DataAccess.Seeders
{
    public class StateSeeder : ISeeder
    {
        public void Seed(ApplicationContext context)
        {
            context.States.AddOrUpdate(s => s.ID,
                new State
                {
                    ID = States.AL,
                    Abbreviation = States.AL.ToString(),
                    Name = "Alabama"
                },
                new State
                {
                    ID = States.AK,
                    Abbreviation = States.AK.ToString(),
                    Name = "Alaska"
                },
                new State
                {
                    ID = States.AZ,
                    Abbreviation = States.AZ.ToString(),
                    Name = "Arizona"
                },
                new State
                {
                    ID = States.AR,
                    Abbreviation = States.AR.ToString(),
                    Name = "Arkansas"
                },
                new State
                {
                    ID = States.CA,
                    Abbreviation = States.CA.ToString(),
                    Name = "California"
                },
                new State
                {
                    ID = States.CO,
                    Abbreviation = States.CO.ToString(),
                    Name = "Colorado"
                },
                new State
                {
                    ID = States.CT,
                    Abbreviation = States.CT.ToString(),
                    Name = "Connecticut"
                },
                new State
                {
                    ID = States.DE,
                    Abbreviation = States.DE.ToString(),
                    Name = "Delaware"
                },
                new State
                {
                    ID = States.FL,
                    Abbreviation = States.FL.ToString(),
                    Name = "Florida"
                },
                new State
                {
                    ID = States.GA,
                    Abbreviation = States.GA.ToString(),
                    Name = "Georgia"
                },
                new State
                {
                    ID = States.HI,
                    Abbreviation = States.HI.ToString(),
                    Name = "Hawaii"
                },
                new State
                {
                    ID = States.ID,
                    Abbreviation = States.ID.ToString(),
                    Name = "Idaho"
                },
                new State
                {
                    ID = States.IL,
                    Abbreviation = States.IL.ToString(),
                    Name = "Illinois"
                },
                new State
                {
                    ID = States.IN,
                    Abbreviation = States.IN.ToString(),
                    Name = "Indiana"
                },
                new State
                {
                    ID = States.IA,
                    Abbreviation = States.IA.ToString(),
                    Name = "Iowa"
                },
                new State
                {
                    ID = States.KS,
                    Abbreviation = States.KS.ToString(),
                    Name = "Kansas"
                },
                new State
                {
                    ID = States.KY,
                    Abbreviation = States.KY.ToString(),
                    Name = "Kentucky"
                },
                new State
                {
                    ID = States.LA,
                    Abbreviation = States.LA.ToString(),
                    Name = "Louisiana"
                },
                new State
                {
                    ID = States.ME,
                    Abbreviation = States.ME.ToString(),
                    Name = "Maine"
                },
                new State
                {
                    ID = States.MD,
                    Abbreviation = States.MD.ToString(),
                    Name = "Maryland"
                },
                new State
                {
                    ID = States.MA,
                    Abbreviation = States.MA.ToString(),
                    Name = "Massachusetts"
                },
                new State
                {
                    ID = States.MI,
                    Abbreviation = States.MI.ToString(),
                    Name = "Michigan"
                },
                new State
                {
                    ID = States.MN,
                    Abbreviation = States.MN.ToString(),
                    Name = "Minnesota"
                },
                new State
                {
                    ID = States.MS,
                    Abbreviation = States.MS.ToString(),
                    Name = "Mississippi"
                },
                new State
                {
                    ID = States.MO,
                    Abbreviation = States.MO.ToString(),
                    Name = "Missouri"
                },
                new State
                {
                    ID = States.MT,
                    Abbreviation = States.MT.ToString(),
                    Name = "Montana"
                },
                new State
                {
                    ID = States.NE,
                    Abbreviation = States.NE.ToString(),
                    Name = "Nebraska"
                },
                new State
                {
                    ID = States.NV,
                    Abbreviation = States.NV.ToString(),
                    Name = "Nevada"
                },
                new State
                {
                    ID = States.NH,
                    Abbreviation = States.NH.ToString(),
                    Name = "New Hampshire"
                },
                new State
                {
                    ID = States.NJ,
                    Abbreviation = States.NJ.ToString(),
                    Name = "New Jersey"
                },
                new State
                {
                    ID = States.NM,
                    Abbreviation = States.NM.ToString(),
                    Name = "New Mexico"
                },
                new State
                {
                    ID = States.NY,
                    Abbreviation = States.NY.ToString(),
                    Name = "New York"
                },
                new State
                {
                    ID = States.NC,
                    Abbreviation = States.NC.ToString(),
                    Name = "North Carolina"
                },
                new State
                {
                    ID = States.ND,
                    Abbreviation = States.ND.ToString(),
                    Name = "North Dakota"
                },
                new State
                {
                    ID = States.OH,
                    Abbreviation = States.OH.ToString(),
                    Name = "Ohio"
                },
                new State
                {
                    ID = States.OK,
                    Abbreviation = States.OK.ToString(),
                    Name = "Oklahoma"
                },
                new State
                {
                    ID = States.OR,
                    Abbreviation = States.OR.ToString(),
                    Name = "Oregon"
                },
                new State
                {
                    ID = States.PA,
                    Abbreviation = States.PA.ToString(),
                    Name = "Pennsylvania"
                },
                new State
                {
                    ID = States.RI,
                    Abbreviation = States.RI.ToString(),
                    Name = "Rhode Island"
                },
                new State
                {
                    ID = States.SC,
                    Abbreviation = States.SC.ToString(),
                    Name = "South Carolina"
                },
                new State
                {
                    ID = States.SD,
                    Abbreviation = States.SD.ToString(),
                    Name = "South Dakota"
                },
                new State
                {
                    ID = States.TN,
                    Abbreviation = States.TN.ToString(),
                    Name = "Tennessee"
                },
                new State
                {
                    ID = States.TX,
                    Abbreviation = States.TX.ToString(),
                    Name = "Texas"
                },
                new State
                {
                    ID = States.UT,
                    Abbreviation = States.UT.ToString(),
                    Name = "Utah"
                },
                new State
                {
                    ID = States.VT,
                    Abbreviation = States.VT.ToString(),
                    Name = "Vermont"
                },
                new State
                {
                    ID = States.VA,
                    Abbreviation = States.VA.ToString(),
                    Name = "Virginia"
                },
                new State
                {
                    ID = States.WA,
                    Abbreviation = States.WA.ToString(),
                    Name = "Washington"
                },
                new State
                {
                    ID = States.WV,
                    Abbreviation = States.WV.ToString(),
                    Name = "West Virginia"
                },
                new State
                {
                    ID = States.WI,
                    Abbreviation = States.WI.ToString(),
                    Name = "Wisconsin"
                },
                new State
                {
                    ID = States.WY,
                    Abbreviation = States.WY.ToString(),
                    Name = "Wyoming"
                });
            context.SaveChanges();
        }
    }
}