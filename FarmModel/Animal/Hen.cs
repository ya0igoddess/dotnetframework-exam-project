using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel
{
    class Hen : Animal
    {
        public Hen(AnimalSex sex, int age, int weight): base(sex,age,weight)
        {
            AnimalKind = AnimalsKinds.Hen;

            milkingAction = new Actions.MilkinNoMilk();
            eggsCollectingAction = new Actions.CollectingWithHenEggs();
            sheeringAction = new Actions.SheeringNoWool();

        }
    }
}
