using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FarmModel
{
    public enum AnimalsKinds { Cow, Hen, Sheep, Goat, All };
    public enum AnimalSex { Male, Female };
    public enum Action {Milking, Egg_Collecting, Sheering, Butching, Feed };

    public class Farm
    {
        private List<Animal> animalsList = new List<Animal>();


        public IEnumerable<Animal> GetFilteredAnimals(AnimalsKinds filter)
        {
                return from animal in animalsList
                       where animal.AnimalKind == filter
                       select animal;
        }

 
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

        /// <summary>
        /// Performs selected action to some group of animals.
        /// </summary>
        /// <param name="performableAction">Selected action to perform.</param>
        /// <param name="selectedAnimals">List of animals to perform action.</param>
        public void PerformActionToAnimals(Action performableAction, IEnumerable<Animal> selectedAnimals)
        {

            foreach (var animal in selectedAnimals)
            {
                animal.PerformAction(performableAction);
            }

            if (Action.Butching == performableAction) //butched animals must be deleted from the list
            {
                foreach (var animal in selectedAnimals)
                    animalsList.Remove(animal);
            }
        }
        
    }
}
