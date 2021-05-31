using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel
{
    class Hen : Animal
    {
        public Hen(AnimalSex sex, int age, double weight): base(sex,age,weight)
        {
            AnimalKind = AnimalsKinds.Hen;

            milkingAction = new Actions.MilkingNoMilk();

            if (AnimalSex.Female == sex)
            {
                eggsCollectingAction = new Actions.CollectingWithHenEggs();
            }
            else
            {
                eggsCollectingAction = new Actions.CollectingNoEggs();
            }
            sheeringAction = new Actions.SheeringNoWool();

        }
    }
}
