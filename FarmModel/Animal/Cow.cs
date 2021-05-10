using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel
{
    class Cow : Animal
    {
        public Cow(AnimalSex sex, int age, int weight) : base(sex,age,weight)
        {
            
            AnimalKind = AnimalsKinds.Cow;
            milkingAction = new Actions.MilkingWithCowMilk();
            eggsCollectingAction = new Actions.CollectingNoEggs();
            sheeringAction = new Actions.SheeringNoWool();

        }
    }
}
