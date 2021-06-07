using System;
using System.Globalization;
using System.ComponentModel;

namespace FarmModel
{
    public abstract class Animal : INotifyPropertyChanged
    {
        private int age;
        public int Age
        {
            get { return age;}
            private set { age = value;
                OnPropertyChanged("Age");
            }
        }
        private double weight;
        public double Weight { 
            get { return weight; }
            private set { weight = value;
                OnPropertyChanged("Weight");
            }
        }

        public AnimalSex Sex { get; private set; }
        public AnimalsKinds AnimalKind { get; protected set; }
        protected double growCoefficient; //the speed of gaining mass for current animal

        protected Actions.MilkingAction milkingAction;
        protected Actions.EggsCollectingAction eggsCollectingAction;
        protected Actions.SheeringAction sheeringAction;

        public event PropertyChangedEventHandler PropertyChanged;

        public Animal(AnimalSex sex, int age, double weight)
        {
            
            this.Sex = sex;

            if (age >= 0)
                this.Age = age;
            else
                throw new ArgumentException("Age can't be negative.");

            if (weight > 0)
                this.Weight = weight;
            else
                throw new ArgumentException("Weight must be positive.");

        }

        public string GrowUp()
        {
            Age++;
            Weight = Weight * growCoefficient;
            milkingAction.Refresh();
            eggsCollectingAction.Refresh();
            sheeringAction.Refresh();
            return string.Format("You fed {0}", AnimalKind.ToString());
        }

        public string ButchUp()
        {
            return string.Format("You butched {0} for {1} kg of meat", 
                AnimalKind.ToString(), 
                weight.ToString());
        }

        public string PerformAction(Action action)
        {
            switch (action)
            {
                case Action.Eggs_Collecting:
                   return eggsCollectingAction.PerformAction();
                case Action.Feed:
                    return GrowUp();
                case Action.Milking:
                    return milkingAction.PerformAction();
                case Action.Sheering:
                    return sheeringAction.PerformAction();
                case Action.Butching:
                   return ButchUp();
                default:
                    throw new ArgumentException("Invalid Action argument.");
            }
        }

        private void OnPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}",
                                AnimalKind.ToString(),
                                Sex.ToString(),
                                Age.ToString(),
                                Weight.ToString(CultureInfo.InvariantCulture));
        }
    }
}
