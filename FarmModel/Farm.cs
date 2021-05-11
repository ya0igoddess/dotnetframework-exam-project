using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace FarmModel
{
    public enum AnimalsKinds { Cow, Hen, Sheep, Goat, All };
    public enum AnimalSex { Male, Female };
    public enum Action {Milking, Egg_Collecting, Sheering, Butching, Feed };
    public class Farm
    {
        List<Animal> animals = new List<Animal>();
        

        public IEnumerable<Animal> GetFilteredAnimals(AnimalsKinds filter)
        {
            if (filter == AnimalsKinds.All)
                return animals;
            else
                return from animal in animals
                       where animal.AnimalKind == filter
                       select animal;
        }

        public void addAnimal(Animal animal)
        {
            

            animals.Add(animal);
        }

        public void addAnimal(AnimalsKinds kind, AnimalSex sex, 
                                int age, int weight)
        {
            Animal animal = null;

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
            }

            if (null == animal)
                throw new Exception("List view must specify kind of animal.");

            animals.Add(animal);
                
        }
        
    }
}
