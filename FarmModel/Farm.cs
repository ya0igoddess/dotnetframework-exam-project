using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FilterableList;

namespace FarmModel
{
    public enum AnimalsKinds { Cow, Hen, Sheep, Goat, All };
    public enum AnimalSex { Male, Female };
    public enum Action {Milking, Egg_Collecting, Sheering, Butching, Feed };

    public class Farm : INotifyPropertyChanged
    {
       public FilterableList<Animal>animalsList = new FilterableList<Animal>();

        /// <summary>
        /// Returns readonly list of animals contained in the farm.
        /// </summary>
         public IReadOnlyList<Animal> AnimalsList
         {
           get { return animalsList as IReadOnlyList<Animal>; }
         }
        public event PropertyChangedEventHandler PropertyChanged;

        public void AddAnimal(AnimalsKinds kind, 
            AnimalSex sex,               
            int age, 
            double weight)
        {
            Animal animal;

            switch(kind)
            {
                case AnimalsKinds.Cow:
                    animal = new Cow(sex, age, weight);
                    break;
                case AnimalsKinds.Goat:
                    animal = new Goat(sex, age, weight);
                    break;
                case AnimalsKinds.Hen:
                    animal = new Hen(sex, age, weight);
                    break;
                case AnimalsKinds.Sheep:
                    animal = new Sheep(sex, age, weight);
                    break;

                default:
                    throw new Exception("List view must specify kind of animal.");
            }

            animalsList.Add(animal);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AnimalsList"));
        }

        public void SetFilterToAnimalsList(AnimalsKinds kinds)
        {
            if (AnimalsKinds.All == kinds)
            {
                animalsList.FilterFunction = t => true;
            }
            else
            {
                animalsList.FilterFunction = t => kinds == t.AnimalKind;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AnimalsList"));
        }

        /// <summary>
        /// Performs selected action to some group of animals.
        /// </summary>
        /// <param name="performableAction">Selected action to perform</param>
        /// <param name="selectedAnimals">List of animals to perform action</param>
        /// <returns>Collection of strings, describing </returns>
        public ICollection<string> PerformActionToAnimals(Action performableAction, IEnumerable<Animal> selectedAnimals)
        {
            List<string> resultLog = new List<string>();
            foreach(Animal animal in selectedAnimals)
            {
               resultLog.Add(animal.PerformAction(performableAction));
            }
            
            if (performableAction==Action.Butching)
            {
                foreach (Animal animal in selectedAnimals.ToArray())
                    animalsList.Remove(animal);
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AnimalsList"));
            return resultLog;
        }
        
    }
}
