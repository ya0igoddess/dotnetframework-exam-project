using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel
{
    class Sheep : Animal
    {
        public Sheep(AnimalSex sex, int age, int weight) : base(sex, age, weight)
        {

            AnimalKind = AnimalsKinds.Sheep;
            milkingAction = new Actions.MilkinNoMilk();
            eggsCollectingAction = new Actions.CollectingNoEggs();
            sheeringAction = new Actions.SheeringWithSheepWool();

        }
    }
}
