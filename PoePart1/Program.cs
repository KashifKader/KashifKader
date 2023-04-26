using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace PoePart1
{
    internal class Program
    {


        class Ingredient
        {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }

            public override string ToString()
            {
                return $"{Quantity} {Unit} of {Name}";
            }
        }

        class Recipe
        {
            public Ingredient[] _ingredients;
            public string[] _steps;

            public Recipe(int numIngredients, int numSteps)
            {
                _ingredients = new Ingredient[numIngredients];
                _steps = new string[numSteps];
            }

            public void EnterIngredient(int index, string name, double quantity, string unit)
            {
                _ingredients[index] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
            }

            public void EnterStep(int index, string description)
            {
                _steps[index] = description;
            }

            public void DisplayRecipe()
            {
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in _ingredients)
                {
                    Console.WriteLine("- " + ingredient.ToString());
                }

                Console.WriteLine("\nSteps:");
                for (int i = 0; i < _steps.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {_steps[i]}");
                }
            }

            public void ScaleRecipe(double factor)
            {
                foreach (var ingredient in _ingredients)
                { 
                  
                    
                    ingredient.Quantity = factor * ingredient.Quantity;
                }
            }

            public void ResetQuantities()
            {
                foreach (var ingredient in _ingredients)
                {
                    ingredient.Quantity *=0;
                }
            }

            public void ClearRecipe()
            {
                _ingredients = new Ingredient[_ingredients.Length];
                _steps = new string[_steps.Length];
            }
        }

        
        
            static void Main(string[] args)
            {
                Console.Write("Enter the number of ingredients: ");
                int numIngredients = int.Parse(Console.ReadLine());

                Console.Write("Enter the number of steps: ");
                int numSteps = int.Parse(Console.ReadLine());

                Recipe recipe = new Recipe(numIngredients, numSteps);

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"Enter details for ingredient {i + 1}:");

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Quantity: ");
                    double quantity = double.Parse(Console.ReadLine());

                    Console.Write("Unit: ");
                    string unit = Console.ReadLine();

                    recipe.EnterIngredient(i, name, quantity, unit);
                }

                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"Enter step {i + 1}:");
                    recipe.EnterStep(i, Console.ReadLine());
                }

                recipe.DisplayRecipe();

                while (true)
                {
                    Console.WriteLine("\nSelect an option:");
                    Console.WriteLine("1. Scale recipe");
                    Console.WriteLine("2. Reset quantities");
                    Console.WriteLine("3. Clear recipe");
                    Console.WriteLine("4. Exit");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                        
                            double factor = double.Parse(Console.ReadLine());
                        
                            recipe.ScaleRecipe(factor);
                            recipe.DisplayRecipe();
                            break;

                        case 2:
                        
                            recipe.ResetQuantities();
                            recipe.DisplayRecipe();
                            break;

                        case 3:
                        recipe.ClearRecipe();
                        break ;

                    case 4: 
                       break ;
                            

                        

                             

                    }



                }
            }
        }
    }



  







        


   



