using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToDoApp
{
    public class TodoApp
    {
        string fileLocation = "todo-items.txt";
        List<TodoItem> items = new List<TodoItem>();
        readonly string helpOutput = @"Options
    Add [item]      Add a item to the todo application
    Do #[number]    Complete a given item
    Print           Print all todo items
    Help            Show the help options
    Exit            Exit the command line application";

        public TodoApp()
        {
            LoadItems();
        }

        public void UseTestEnvironment()
        {
            fileLocation = "todo-items-test.txt";
            items.Clear();
        }

        void LoadItems()
        {
            // Check if file exists and read the content if it exists
            if (File.Exists(fileLocation))
            {
                string[] lines = File.ReadAllLines(fileLocation);
                foreach (string line in lines)
                {
                    string text = line.Substring(1).Split(' ')[1];
                    int number = int.Parse(line.Substring(1).Split(' ')[0]);
                    TodoItem newItem = new TodoItem(text, number);
                    items.Add(newItem);
                }
            }
        }

        void SaveItems()
        {
            List<string> allItems = new List<string>();
            foreach (TodoItem item in items)
            {
                allItems.Add(item.ToString());
            }

            File.WriteAllLines(fileLocation, allItems);
        }

        public void Add(string text)
        {
            int newNumber = 1;
            if (items.Count > 0)
            {
                // Set the new number to the number of the last item + 1
                newNumber = items.ElementAt(items.Count - 1).Number + 1;
            }

            TodoItem newItem = new TodoItem(text, newNumber);
            items.Add(newItem);
            Console.WriteLine(newItem);
            SaveItems();
        }

        public void Do(int number)
        {
            bool found = false;
            foreach (TodoItem item in items)
            {
                if (item.Number == number)
                {
                    Console.WriteLine("Completed " + item);
                    found = true;

                    // Remove from list
                    items.Remove(item);

                    // Save new list
                    SaveItems();
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Could not find a item with the specified number");
            }
        }

        public void Print()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("There is no items in list");
            }
            else
            {
                // Print all items in the todo list
                foreach (TodoItem item in items)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void Help()
        {
            Console.WriteLine(helpOutput);
        }
    }
}
