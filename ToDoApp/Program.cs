using System;

namespace ToDoApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var app = new TodoApp();

            Console.WriteLine("Type help to show options");

            // Write a command line terminal symbol
            Console.Write(">");

            var inputLine = Console.ReadLine();
            while (inputLine != null && !inputLine.Equals("") && !inputLine.ToLower().Equals("exit"))
            {
                if (inputLine.StartsWith("Add "))
                {
                    // If the user wants to add a item
                    var text = inputLine.Split(new[] { "Add " }, StringSplitOptions.None)[1];
                    app.Add(text);
                }
                else if (inputLine.StartsWith("Do #"))
                {
                    // If the user wants to set a item to done
                    try
                    {
                        var doNumber = int.Parse(inputLine.Split(new[] { "Do #" }, StringSplitOptions.None)[1]);
                        app.Do(doNumber);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("A number must be specified to set a item to done.");
                    }
                }
                else if (inputLine.ToLower().Equals("print"))
                {
                    // If the user wants to print out all items
                    app.Print();
                }
                else if (inputLine.ToLower().Equals("help"))
                {
                    // If the user wants to see which command to use
                    app.Help();
                }
                else
                {
                    // If the user type something that is not recognised by the program
                    Console.WriteLine("Command not recognised, type help to see all options");
                }

                // Write a command line terminal symbol
                Console.Write(">");

                // Read new input
                inputLine = Console.ReadLine();
            }
        }
    }
}
