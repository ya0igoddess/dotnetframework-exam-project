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

    public class Farm
    {
       public FilterableList<Animal>animalsList = new FilterableList<Animal>();
       // public FilterableList<Animal> AnimalsList
       // {
         //   get;
        //}

        public void AddAnimal(AnimalsKinds kind, AnimalSex sex, 
                                int age, int weight)
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
        }

        /// <summary>
        /// Performs selected action to some group of animals.
        /// </summary>
        /// <param name="performableAction">Selected action to perform.</param>
        /// <param name="selectedAnimals">List of animals to perform action.</param>
        public void PerformActionToAnimals(Action performableAction, IEnumerable<Animal> selectedAnimals)
        {
            foreach(Animal animal in selectedAnimals)
            {
                animal.PerformAction(performableAction);
            }
            
            if (performableAction==Action.Butching)
            {
                foreach (Animal animal in selectedAnimals.ToArray())
                    animalsList.Remove(animal);
            }
        }
        
    }
}
