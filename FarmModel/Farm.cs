using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FilterableList;
using System.IO;
using System.Globalization;

namespace FarmModel
{
    public enum AnimalsKinds { Cow, Hen, Sheep, Goat, All };
    public enum AnimalSex { Male, Female };
    public enum Action {Milking, Eggs_Collecting, Sheering, Butching, Feed };

    public class Farm : INotifyPropertyChanged
    {
       private FilterableList<Animal>animalsList = new FilterableList<Animal>();

        /// <summary>
        /// Returns readonly list of animals contained in the farm.
        /// </summary>
         public IList<Animal> AnimalsList
         {
           get { return animalsList; }
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

        public void SaveFarmToFile(string fileName)
        {
            if (File.Exists(fileName)) File.Delete(fileName);

            using (FileStream fs = File.Create(fileName))
            {
                CultureInfo culture = CultureInfo.InvariantCulture;

                foreach (Animal animal in animalsList.GetAll())
                {
                    byte[] convertedStr = UTF8Encoding.UTF8.GetBytes(animal.ToString() + '\n'); ;
                    fs.Write(convertedStr, 0, convertedStr.Length);    
                }
            }
        }

        public Farm LoadNewFarm(string fileName)
        {
            Farm result = new Farm();
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                CultureInfo culture = CultureInfo.InvariantCulture;

                string[] args = line.Split(' ');
                if (args.Length != 4)
                {
                    throw new ArgumentException("Invalid animal record in file");
                }

                result.AddAnimal((AnimalsKinds)Enum.Parse(typeof(AnimalsKinds),args[0]),
                                 (AnimalSex)Enum.Parse(typeof(AnimalSex),args[1]),
                                  int.Parse(args[2]),
                                  double.Parse(args[3],culture));
            }
            return result;
        }
    }
}
