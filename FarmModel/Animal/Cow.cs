using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel
{
    class Cow : Animal
    {
        public Cow(AnimalSex sex, int age, double weight) : base(sex,age,weight)
        {
            
            AnimalKind = AnimalsKinds.Cow;
            if (sex == AnimalSex.Female)
            {
                milkingAction = new Actions.MilkingWithCowMilk();
            }
            else
            {
                milkingAction = new Actions.MilkingNoMilk();
            }
            eggsCollectingAction = new Actions.CollectingNoEggs();
            sheeringAction = new Actions.SheeringNoWool();

        }
    }
}
