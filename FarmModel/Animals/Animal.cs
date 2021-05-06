using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel
{
    public abstract class Animal
    {

        public int Age { get; private set; }
        public int Weight { get; private set; }
        public AnimalSex Sex { get; private set; }
        public Animal AnimalKind { get; private set; }
        
    }
}
