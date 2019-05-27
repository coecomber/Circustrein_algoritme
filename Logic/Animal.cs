using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Enums;

namespace Logic
{
    public class Animal
    {
        public AnimalSize Size { get; }
        public AnimalEatOptions Eat { get; }

        public Animal(AnimalSize animalSize, AnimalEatOptions animalEatOption)
        {
            Size = animalSize;
            Eat = animalEatOption;
        }

        public AnimalSize GetAnimalSize()
        {
            return Size;
        }

        public AnimalEatOptions GetAnimalEat()
        {
            return Eat;
        }

        public override string ToString()
        {
            return "Grootte: " + Size + "  Eet: " + Eat;
        }
    }
}
