using System;
using System.Collections.Generic;

namespace Types
{
    class Program
    {
        //Enum
        public enum Days {
            None = 0,
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7
        }

        //Void
        public static void MyMethod(
        //Named Argument
        int firstArgument, 

        //Optional Argument
        string secondArgument = "default value", 

        //Optional Argument
        bool thirdArgument = false){ }
        static void Main(string[] args)
        {
            //Value type
            int random_num = 42;
            Console.WriteLine("Value type: {0}", random_num);

            //reference type(Enum: Line 20)
            var Day = Days.thursday;
            Console.WriteLine("From enum: {0}", Day.ToString());

            //Using your own type(Line 50)
            var my_type = new Point(-23, 122);

            //Calling MyMethod(Line 20)
            MyMethod(1, thirdArgument: true);

            //using Deck class
            var deck = new Deck(10);

            //Advise user to check out code that wasn't showed:
            Console.WriteLine("Please check out my code to see the following: Creating own types(classes) at line 112 & 117, chaining constructors at line 110");

            var calc = new Calculator();
            //create object of class product
            var p = new Product{
                Price = 14.99M
            };
            //Use extenion method and pass new created object as parameter
            var total = calc.CalculateDiscount(p);
            //return result
            Console.WriteLine("From extension method: Price: ${0}", total);

        }
    }

    //Own Type
    //
    //Difference between class and struct: Structs can't have an empty constructor or be inherited from, but a class can
    public struct Point {
        public int x, y;

        //Paramaterized Constructor
        public Point(int p1, int p2){
            x = p1;
            y = p2;
        }
    }

    //Contructor chaining
    public class ConstructorChaining {
        private int _p;
        
        //Adding multiple constructors to your type
        public ConstructorChaining() : this(3) {}
        public ConstructorChaining(int p){
            this._p = p;
        }
    }

    //Own type 2
    public class Card {
        public int Number { get; set; }
        public string Shape { get; set; }
     }

    public class Deck {
        //public field
        public static int _maximumNumberOfCards {get;set;}

        //Generic list
        public static List<Card> Cards { get; set; }

        //Constructor
        public Deck(int maximumNumberOfCards){
            _maximumNumberOfCards = maximumNumberOfCards;
        }      
    }

    //Using Generic Types
    //variable where the variable is a value type(Only nullable isn't allowed)
    //Where T: 
    // 1. struct: Value must be value type
    // 2. class: Value must be reference type
    // 3. new(): Type must have default public constructor
    // 4. <Base class name>: Type argument must be derived from specified base class
    // 5. <Interface name>: Type must be or implement specified interface
    // 6. U: Argument supplied for T must be or derive from arugment supplied for U
    public struct Nullable<T> where T: struct
    {
        private bool hasValue;
        private T value;

        public Nullable(T value) {
            //if value is passed
            this.hasValue = true;
            //private value = passed value
            this.value = value;
        }

        public bool HasValue { get {return this.hasValue; } }

        public T Value {
            //If value is accessed
            get {
                //if value = null, throw Null exception
                if(!this.hasValue) throw new ArgumentNullException();
                //Otherwise return value
                return this.value;
            }
        }

        //Accessible method
        public T GetValueOrDefault() {
            //return value
            return this.value;
        }
    }

    //Extension methods:
    //2 ways to extend existing type: 1) Extension methods, 2) Overriding
    //Product type
    public class Product
    {
        public decimal Price { get; set; }
    }

    public static class MyExtensions {
        //extension method
        public static decimal Discount(this Product product){
            return product.Price * 0.9M;
        }
    }

    //Calculate discount(using extension method)
    public class Calculator {
        public decimal CalculateDiscount(Product p){
            //use extension method
            return p.Discount();
        }
    }
}
