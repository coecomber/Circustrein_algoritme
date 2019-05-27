using Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Wagon
    {
        private List<Animal> AnimalList;

        public int freeSpacePoints;

        public Wagon()
        {
            freeSpacePoints = 10;
            AnimalList = new List<Animal>();
        }

        public List<Animal> GetAnimals()
        {
            return AnimalList;
        }

        public int GetFreeSpacePoints()
        {
            return freeSpacePoints;
        }

        public bool AddAnimal(Animal animal)
        {
            if(animal.GetAnimalSize() == AnimalSize.Large)
            {
                if(freeSpacePoints >= 5)
                {
                    freeSpacePoints = freeSpacePoints-5;
                    AnimalList.Add(animal);
                    return true;
                }
            }

            if (animal.GetAnimalSize() == AnimalSize.Medium)
            {
                if (freeSpacePoints >= 3)
                {
                    freeSpacePoints = freeSpacePoints - 3;
                    AnimalList.Add(animal);
                    return true;
                }
            }

            if (animal.GetAnimalSize() == AnimalSize.Small)
            {
                if (freeSpacePoints >= 1)
                {
                    freeSpacePoints = freeSpacePoints - 1;
                    AnimalList.Add(animal);
                    return true;
                }
            }

            return false;
        }

        public string GetAllAnimalNames()
        {
            string animals = "";
            foreach(var a in AnimalList)
            {
                animals = animals + " " + a.ToString() + " | "; 
            }

            return animals;
        }

        public override string ToString()
        {
            return freeSpacePoints + " | Dieren: " + GetAllAnimalNames();
        }
    }
}
