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
        public AnimalsKinds AnimalKind { get; protected set; }
        private double growCoefficient;

        protected Actions.MilkingAction milkingAction;
        protected Actions.EggsCollectingAction eggsCollectingAction;
        protected Actions.SheeringAction sheeringAction;
        

        public Animal(AnimalSex sex, int age, int weight)
        {
            this.Sex = sex;
            this.Age = age;
            this.Weight = weight;
        }

        public void GrowUp()
        {
            Age++;
            Weight = (int)(Weight * growCoefficient);
            milkingAction.Refresh();
            eggsCollectingAction.Refresh();
            sheeringAction.Refresh();
        }

        public void ButchUp()
        {
            //TODO return meat
        }


    }
}
