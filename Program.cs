using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Security.AccessControl;
using System.Security.Authentication.ExtendedProtection;

namespace BuilderDesignPattern
{
    class Pizza
    {
        public string Size { get; set; }
        public string Crust { get; set; }
        public string Sauce { get; set; }
        public string Cheese { get; set; }
        public List<string> Toppings { get; set; } = new List<string>();

        public void Display()
        {
            Console.WriteLine("Size:" + Size);
            Console.WriteLine("Crust:" + Crust);
            Console.WriteLine("Sauce:" + Sauce);
            Toppings.ForEach(topping => Console.WriteLine(topping));
        }
    }

    /*  This Interface helps in achieving the separation of concerns and the step-by-step 
        construction of complex objects   */
    interface IPizzaBuilder
    {
        void SetSize(string size);
        void SetCrust(string crust);
        void SetSauce(string sauce);
        void SetCheese(string cheese);
        void AddTopping(string topping);
        Pizza Build(); // Add Build method
    }
    // Concrete builder class - Implements the construction steps.
    class MargheritaPizzaBuilder : IPizzaBuilder
    {
        private Pizza pizza = new Pizza();

        public void SetSize(string size) { pizza.Size = size; }
        public void SetCrust(string crust) { pizza.Crust = crust; }
        public void SetSauce(string sauce) { pizza.Sauce = sauce; }
        public void SetCheese(string cheese) { pizza.Cheese = cheese; }
        public void AddTopping(string topping) { pizza.Toppings.Add(topping); }
        public Pizza Build()
        {
            return pizza;
        }
    }

    // Another Concrete Class
    class PepperoniPizzaBuilder : IPizzaBuilder
    {
        private Pizza pizza = new Pizza();

        public void SetSize(string size) { pizza.Size = size; }
        public void SetCrust(string crust) { pizza.Crust = crust; }
        public void SetSauce(string sauce) { pizza.Sauce = sauce; }
        public void SetCheese(string cheese) { pizza.Cheese = cheese; }
        public void AddTopping(string topping) { pizza.Toppings.Add(topping); }

        public Pizza Build()
        {
            return pizza;
        }
    }

    // Director class (Client Code)
    // The Director is only responsible for producing products in a particular order.
    class PizzaDirector
    {
        private IPizzaBuilder builder;
        public PizzaDirector(IPizzaBuilder builder)  // Pass the object of concrete class to get the customized Pizza
        {
            this.builder = builder;
        }
        public Pizza ConstructMargheritaPizza()   
        {
            // Customize the Margherita pizza here for which builder design pattern is introduced. 
            builder.SetSize("Large");
            builder.SetCrust("Thin Crust");
            builder.SetSauce("Tomato");
            builder.SetCheese("Mozzarella");
            builder.AddTopping("Basil");

            return builder.Build();       // This will return Pizza of required settings
        }
        public Pizza ConstructPepperoniPizza()
        {
            // Customize the Pepperoni pizza here 
            builder.SetSize("Medium");
            builder.SetSauce("Hot Sauce");
            builder.SetCheese("Mozzarella");
            builder.AddTopping("Pepperoni");

            return builder.Build();
        }
    }
  
    // Execution the program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Margherita Pizza Ready");
            var margheritaBuilder = new MargheritaPizzaBuilder();  
            var margheritaDirector = new PizzaDirector(margheritaBuilder);       

            Pizza margheritaPizza = margheritaDirector.ConstructMargheritaPizza();  //This will return Pizza in Margherita style
            margheritaPizza.Display();                                              // Display Constructed pizza details

            Console.WriteLine(".............................");

            Console.WriteLine("Pepperoni Pizza Ready");
            var pepperoniBuilder = new PepperoniPizzaBuilder();
            var pepperoniDirector = new PizzaDirector(pepperoniBuilder);    //This will return Pizza in Pepperoni style

            Pizza pepperoniPizza = pepperoniDirector.ConstructPepperoniPizza();
            pepperoniPizza.Display();

        }
    }










}











/*In the pizza example, the Builder design pattern is used to construct pizza objects with various configurations while keeping
 * the construction process separate from the pizza object itself. */
/*Pizza:  This class represents the complex object that we want to build, which is a pizza.
*/
/*A pizza is often considered a complex object in software design because it consists of multiple components, properties, and configurations that can vary widely based on customer preferences*/
/*Why pizza is Complex object here*/
/*Multiple Properties: A pizza has various properties that can be customized, including its size, crust type, sauce, cheese type, and toppings. Each of these properties can have different options or variations, making the pizza a complex entity.*/
/*Combinations: The possible combinations of pizza properties and ingredients can be vast. For example, you can have a large or small pizza, thin or thick crust, various sauce options, different types of cheese, and a wide array of toppings. This leads to a combinatorial explosion of possibilities.*/
/*Customization: Customers can customize their pizzas based on their preferences. Some may prefer a vegetarian pizza with no meat toppings, while others may want a meat lover's pizza with multiple meat toppings. The ability to customize a pizza's properties adds complexity to its creation.*/
/*Consistency: The Builder pattern helps maintain consistency in pizza construction. It ensures that a pizza is created step by step, following a specific sequence of actions, preventing incomplete or inconsistent pizza objects.*/
/*Encapsulation: By encapsulating the pizza construction process within a builder and director, you abstract away the complexity from the client code, making it easier to create pizzas with various configurations.*/
/*Overall, treating a pizza as a complex object allows you to model it effectively in software, manage its properties and customization options, and provide a structured way to create pizzas with consistent quality and properties. The Builder pattern is a useful design pattern for managing this complexity while ensuring flexibility and maintainability in pizza creation.*/


/*What is BuilderDesignPattern Design Pattern ?
When we have to use it in what scenario?
What are its benefits?
Code with example
Summarize the example in steps:
Create the PizzaBuilder interface and concrete builder classes (MargheritaPizzaBuilder and PepperoniPizzaBuilder) as shown in previous examples.

Define the Pizza class to represent the pizza with various properties like size, crust, sauce, cheese, and toppings.

Implement a PizzaDirector class to orchestrate the pizza construction process.

In your client code, use the director and the appropriate builder to create the desired pizzas.*/

/*
The essence of it: advantages and disadvantages of the Builder Design Pattern
We should use the Builder Design Pattern when we want:

To get rid of the multiple constructors of a class, where one differs from the others just by the number of parameters.
As long as this pattern allows us to build objects step by step, using only those steps that we need, we can simplify our code by reducing the number of these constructors, or, much better, by getting rid of them entirely.
Our code to create different representations of some Product (different variants of coffee tables, armchairs, and sofas).*/


When to use Builder Design Pattern:
   -- When we have to create varients of a product like different type of coeffe, Different types of Pizza, Cars etc.

    content:
   - What is BuilderDesignPattern
  - Scenario When to use it.
    -What are the benefits.
    We don't need to create different constructor for each object.
    -Summarize the example in steps

    What is BuilderDesignPattern?
    -- builder Design Pattern is used to construct complex objects( i.e. Objects having variety of configurations , Optional Parameters).
    -- 

