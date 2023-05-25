
using System;

namespace Recipe
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        private double OriginalQuantity { get; set; }

        public Ingredient(string name, double quantity, string unitOfMeasurement)
        {
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
            OriginalQuantity = quantity;
        }

        public void Scale(double factor)
        {
            Quantity = OriginalQuantity * factor;
        }

        public void Reset()
        {
            Quantity = OriginalQuantity;
        }
    }

    public class Recipe
    {
        private Ingredient[] Ingredients { get; }
        private string[] Steps { get; }

        public Recipe(int numIngredients, int numSteps)
        {
            Ingredients = new Ingredient[numIngredients];
            Steps = new string[numSteps];
        }

        public void AddIngredient(int index, Ingredient ingredient)
        {
            Ingredients[index] = ingredient;
        }

        public void AddStep(int index, string step)
        {
            Steps[index] = step;
        }

        public void Scale(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Scale(factor);
            }
        }

        public void Reset()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Reset();
            }
        }

        public void Display()
        {
            Console.WriteLine("Recipe:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.UnitOfMeasurement} of {ingredient.Name}");
            }

            Console.WriteLine("Steps:");
            foreach (var step in Steps)
            {
                Console.WriteLine(step);
            }
        }
    }

    class Program
    {
        private const string? V = "new";

        static void Main(string[] args)
        {
            Recipe? recipe = null;

            while (true)
            {
                Console.WriteLine("Enter 'new' to create a new recipe.");
                Console.WriteLine("Enter 'display' to show the recipe details.");
                Console.WriteLine("Enter 'scale' to scale the recipe.");
                Console.WriteLine("Enter 'reset' to reset the recipe.");
                Console.WriteLine("Enter 'clear' to clear the recipe.");
                Console.WriteLine("Enter 'exit' to exit the program.");

                string? command = Console.ReadLine()?.ToLower();

                switch (command)
                {
                    case V:
                        Console.Write("Enter the number of ingredients: ");
                        int numIngredients;
                        if (!int.TryParse(Console.ReadLine(), out numIngredients))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            continue;
                        }

                        Console.Write("Enter the number of steps: ");
                        int numSteps;
                        if (!int.TryParse(Console.ReadLine(), out numSteps))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            continue;
                        }

                        recipe = new Recipe(numIngredients, numSteps);

                        for (int i = 0; i < numIngredients; i++)
                        {
                            Console.WriteLine($"Ingredient #{i + 1}:");
                            Console.Write("Enter the name of the ingredient: ");
                            string? name = Console.ReadLine();

                            Console.Write("Enter the quantity of the ingredient: ");
                            if (!double.TryParse(Console.ReadLine(), out double quantity))
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                                continue;
                            }

                            Console.Write("Enter the unit of measurement for the ingredient: ");
                            string? unitOfMeasurement = Console.ReadLine();

#pragma warning disable CS8604 // Possible null reference argument.
                            Ingredient? ingredient = new Ingredient(name, quantity, unitOfMeasurement);
#pragma warning restore CS8604 // Possible null reference argument.
                            recipe.AddIngredient(i, ingredient);
                        }

                }
            }
        }
    } 
}          
