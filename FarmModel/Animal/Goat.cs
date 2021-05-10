using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel
{
    class Goat : Animal
    {
        public Goat(AnimalSex sex, int age, int weight) : base(sex,age,weight)
        {
            this.AnimalKind = AnimalsKinds.Goat;

            milkingAction = new Actions.MilkingWithGoatMilk();
            eggsCollectingAction = new Actions.CollectingNoEggs();
            sheeringAction = new Actions.SheeringNoWool();
        }
    }
}
