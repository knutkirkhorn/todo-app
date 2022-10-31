using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToDoApp
{
    public class TodoApp
    {
        private string _fileLocation = "todo-items.txt";
        private readonly List<TodoItem> _items = new List<TodoItem>();

        private readonly string _helpOutput = @"Options
    Add [item]      Add a item to the todo application
    Do #[number]    Complete a given item
    Print           Print all todo items
    Help            Show all possible options
    Exit            Exit the command line application";

        public TodoApp()
        {
            LoadItems();
        }

        public void UseTestEnvironment()
        {
            _fileLocation = "todo-items-test.txt";
            _items.Clear();
        }

        private void LoadItems()
        {
            // Check if file exists and read the content if it exists
            if (File.Exists(_fileLocation))
            {
                var lines = File.ReadAllLines(_fileLocation);
                foreach (var line in lines)
                {
                    var text = line.Substring(1).Split(' ')[1];
                    var number = int.Parse(line.Substring(1).Split(' ')[0]);
                    var newItem = new TodoItem(text, number);
                    _items.Add(newItem);
                }
            }
        }

        private void SaveItems()
        {
            var allItems = _items.Select(item => item.ToString()).ToList();
            File.WriteAllLines(_fileLocation, allItems);
        }

        public void Add(string text)
        {
            var newNumber = 1;
            if (_items.Count > 0)
            {
                // Set the new number to the number of the last item + 1
                newNumber = _items.ElementAt(_items.Count - 1).Number + 1;
            }

            var newItem = new TodoItem(text, newNumber);
            _items.Add(newItem);
            Console.WriteLine(newItem);
            SaveItems();
        }

        public void Do(int number)
        {
            var found = false;
            foreach (var item in _items.Where(item => item.Number == number))
            {
                Console.WriteLine("Completed " + item);
                found = true;

                // Remove from list
                _items.Remove(item);

                // Save new list
                SaveItems();
                break;
            }

            if (!found) Console.WriteLine("Could not find a item with the specified number");
        }

        public void Print()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("There is no items in list");
                return;
            }

            // Print all items in the todo list
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }

        public void Help()
        {
            Console.WriteLine(_helpOutput);
        }
    }
}