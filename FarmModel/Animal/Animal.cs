using System;
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
        private double growCoefficient = 1;

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

        public void PerformAction(Action action)
        {
            switch (action)
            {
                case Action.Egg_Collecting:
                    eggsCollectingAction.PerformAction();
                    break;
                case Action.Feed:
                    GrowUp();
                    break;
                case Action.Milking:
                    milkingAction.PerformAction();
                    break;
                case Action.Sheering:
                    sheeringAction.PerformAction();
                    break;
                case Action.Butching:
                    ButchUp();
                    break;
                default:
                    throw new ArgumentException("Invalid Action argument.");
            }
        }

        private void OnPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
