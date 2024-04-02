using SciFiSim.Logic.Models.Entities.People;
using SciFiSim.Logic.Models.System.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.Root
{
    public class PersonEntity
    {
        public PersonMovements movements;
        public Person personStyle;
        public PersonEntity(string fullName)
        {
            this.personStyle = new Person(new Random(), fullName);
            this.movements = new PersonMovements();
        }
    }
}
