using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Assg_4
{
    abstract class Furniture
    {
        public string WoodType { get; set; }
        public string Colour { get; set; }

        public abstract void Display();
        
        
    }

    class Chair : Furniture
    {
        public int legs;
        public void GetDetails(string woodtype, string colour, int legs)
        {
            WoodType = woodtype;
            Colour = colour;
            this.legs = legs;
        }

        public override void Display()
        {
            Console.WriteLine($"Order for chair with \nWood type : {WoodType} \nColour : {Colour} \nLegs : {legs} \nhas been noted\n");
        }
    }

    class BookShelf : Furniture
    {
        public int Shelf;
        public void GetDetails(string woodtype, string colour, int Shelf)
        {
            WoodType = woodtype;
            Colour = colour;
            this.Shelf = Shelf;
        }

        public override void Display()
        {
            Console.WriteLine($"Order for bookshelf with \nWood type : {WoodType} \nColour : {Colour} \nNo of Shelf : {Shelf} \nhas been noted");
        }
    }
}
