using Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Train
    {
        private List<Wagon> WagonList;
        private List<Animal> AnimalList;

        public Train()
        {
            AnimalList = new List<Animal>();
            WagonList = new List<Wagon>();
        }

        public void Sort()
        {
            /// <summary> Summary met mijn stappenplan om beter te begrijpen wat er hier precies gaande is
            /// Stap 1: Pak alle carnivoren van 5 punten en zet deze in een losse wagon
            /// Stap 2: Pak alle carnivoren van 3 punten en zet deze in een losse wagon
            /// Stap 3: Pak alle carnivoren van 1 punten en zet deze in een losse wagon
            /// Stap 4: Pak alle herbivoren van 5 punten en probeer deze in de wagons te plaatsen van stap 2
            /// -Als er meer grote dieren zijn kunnen de rest gevuld worden in wagons van 1 punten
            /// -Als er nog meer grote dieren zijn kunnen deze in nieuwe wagons geplaatst worden
            /// Stap 5: Pak alle herbivoren van 3 punten en probeer deze in de wagons te plaatsen met kleine vlees eters
            /// -Als er middelmatige herbivoren over zijn kunnen deze bij grote herbivoren geplaatst worden
            /// -Als er nog meer middelmatige herbivoren over zijn kunnen deze in losse wagons geplaatst worden
            /// Stap 6: Plaats alle herbivoren van 1 punt en probeer deze in de wagons te plaatsen met grote herbivoren
            /// -Als er nog kleine herbivoren over zijn kunnen deze bij grote herbivoren geplaatst worden
            /// -Als er nog meer kleine herbivoren over zijn kunnen deze bij middelmatige herbivoren geplaatst worden
            /// -Als er nog meer kleine herbivoren over zijn kunnen deze in losse wagons geplaatst worden

            foreach (var i in AnimalList)
            {
                AddBigCarnivoresToNewWagon(i);
                AddMediumCarnivoresToNewWagon(i);
                AddSmallCarnivoresToNewWagon(i);
                AddBigHerbivoreToWagon(i);
                AddMediumHerbivoreToWagon(i);
                AddSmallHerbivoreToWagon(i);
            }
        }

        public void AddBigCarnivoresToNewWagon(Animal animal)
        {
            if (animal.GetAnimalSize() == AnimalSize.Large && animal.GetAnimalEat() == AnimalEatOptions.Carnivore)
            {
                Wagon wagon = new Wagon();
                wagon.AddAnimal(animal);

                WagonList.Add(wagon);
            }
        }

        public void AddMediumCarnivoresToNewWagon(Animal animal)
        {
            bool added = false;
            bool needToAdd = false;
            if (animal.GetAnimalSize() == AnimalSize.Medium && animal.GetAnimalEat() == AnimalEatOptions.Carnivore)
            {
                needToAdd = true;

                foreach (var w in WagonList)
                {
                    if (w.freeSpacePoints >= 3)
                    {
                        bool dangerous = false;
                        List<Animal> animals = w.GetAnimals();
                        foreach (var a in animals)
                        {
                            if (a.GetAnimalEat() == AnimalEatOptions.Carnivore && a.GetAnimalSize() == AnimalSize.Large)
                            {
                                dangerous = true;
                            }
                            if (a.GetAnimalEat() == AnimalEatOptions.Carnivore && a.GetAnimalSize() == AnimalSize.Medium)
                            {
                                dangerous = true;
                            }
                        }
                        if (!dangerous)
                        {
                            added = true;
                            w.AddAnimal(animal);
                        }
                    }
                }
            }

            if (!added && needToAdd)
            {
                Wagon wagon = new Wagon();
                wagon.AddAnimal(animal);

                WagonList.Add(wagon);
            }
        }

        public void AddSmallCarnivoresToNewWagon(Animal animal)
        {
            bool added = false;
            bool needToAdd = false;
            if (animal.GetAnimalSize() == AnimalSize.Small && animal.GetAnimalEat() == AnimalEatOptions.Carnivore)
            {
                needToAdd = true;

                foreach (var w in WagonList)
                {
                    if (w.freeSpacePoints >= 1)
                    {
                        bool dangerous = false;
                        List<Animal> animals = w.GetAnimals();
                        foreach (var a in animals)
                        {
                            if (a.GetAnimalEat() == AnimalEatOptions.Carnivore)
                            {
                                dangerous = true;
                            }
                        }
                        if (!dangerous)
                        {
                            added = true;
                            w.AddAnimal(animal);
                        }
                    }
                }
            }

            if(!added && needToAdd)
            {
                Wagon wagon = new Wagon();
                wagon.AddAnimal(animal);

                WagonList.Add(wagon);
            }
        }

        public void AddBigHerbivoreToWagon(Animal animal)
        {
            bool added = false;
            bool needToAdd = false;
            if (animal.GetAnimalSize() == AnimalSize.Large && animal.GetAnimalEat() == AnimalEatOptions.Herbivore)
            {
                needToAdd = true;
                foreach(var w in WagonList)
                {
                    if(w.freeSpacePoints >= 5)
                    {
                        bool dangerous = false;
                        List<Animal> animals = w.GetAnimals();
                        foreach(var a in animals)
                        {
                            if(a.GetAnimalEat() == AnimalEatOptions.Carnivore && a.GetAnimalSize() == AnimalSize.Large)
                            {
                                dangerous = true;
                            }
                        }
                        if (!dangerous)
                        {
                            w.AddAnimal(animal);
                            added = true;
                        }
                    }
                }
            }

            if (!added && needToAdd)
            {
                Wagon wagon = new Wagon();
                wagon.AddAnimal(animal);

                WagonList.Add(wagon);
            }
        }

        public void AddMediumHerbivoreToWagon(Animal animal)
        {
            bool added = false;
            bool needToAdd = false;
            if (animal.GetAnimalSize() == AnimalSize.Medium && animal.GetAnimalEat() == AnimalEatOptions.Herbivore)
            {
                needToAdd = true;
                foreach (var w in WagonList)
                {
                    if (w.freeSpacePoints >= 3)
                    {
                        bool dangerous = false;
                        List<Animal> animals = w.GetAnimals();
                        foreach (var a in animals)
                        {
                            if (a.GetAnimalEat() == AnimalEatOptions.Carnivore && a.GetAnimalSize() == AnimalSize.Large)
                            {
                                dangerous = true;
                            }
                            if (a.GetAnimalEat() == AnimalEatOptions.Carnivore && a.GetAnimalSize() == AnimalSize.Medium)
                            {
                                dangerous = true;
                            }
                        }
                        if (!dangerous)
                        {
                            added = true;
                            w.AddAnimal(animal);
                        }
                    }
                }
            }

            if (!added && needToAdd)
            {
                Wagon wagon = new Wagon();
                wagon.AddAnimal(animal);

                WagonList.Add(wagon);
            }
        }

        public void AddSmallHerbivoreToWagon(Animal animal)
        {
            bool added = false;
            bool needToAdd = false;
            if (animal.GetAnimalSize() == AnimalSize.Small && animal.GetAnimalEat() == AnimalEatOptions.Herbivore)
            {
                needToAdd = true;
                foreach (var w in WagonList)
                {
                    if (w.freeSpacePoints >= 1)
                    {
                        bool dangerous = false;
                        List<Animal> animals = w.GetAnimals();
                        foreach (var a in animals)
                        {
                            if (a.GetAnimalEat() == AnimalEatOptions.Carnivore)
                            {
                                dangerous = true;
                            }
                        }

                        if (!dangerous)
                        {
                            added = true;
                            w.AddAnimal(animal);
                        }
                    }
                }
            }

            if (!added && needToAdd)
            {
                Wagon wagon = new Wagon();
                wagon.AddAnimal(animal);

                WagonList.Add(wagon);
            }
        }

        public void CreateAndAddAnimal(AnimalSize size, AnimalEatOptions eat)
        {
            Animal animal = new Animal(size, eat);

            AnimalList.Add(animal);
        }

        public void AddAnimal(Animal animal)
        {
            AnimalList.Add(animal);
        }

        public List<Animal> GetAnimals()
        {
            return AnimalList;
        }

        public List<Wagon> GetWagons()
        {
            return WagonList;
        }
    }
}
