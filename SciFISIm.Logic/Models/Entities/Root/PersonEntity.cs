using SciFiSim.Logic.Models.Entities.People;
using SciFiSim.Logic.Models.System.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.Root
{
    public class PersonEntity : Entity
    {
        public PersonMovements movements;
        public Person personStyle;
        public TerroristBehaviour terroristBehaviour;
        public PersonEntity(Guid entityId, string fullName) : base(entityId)
        {
            this.personStyle = new Person(new Random(), fullName);
            this.movements = new PersonMovements();
        }
    }
}
