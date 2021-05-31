using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel
{
    class Goat : Animal
    {
        public Goat(AnimalSex sex, int age, double weight) : base(sex,age,weight)
        {
            growCoefficient = 1.05;
            this.AnimalKind = AnimalsKinds.Goat;

            if (sex == AnimalSex.Female)
            {

                milkingAction = new Actions.MilkingWithGoatMilk();
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
