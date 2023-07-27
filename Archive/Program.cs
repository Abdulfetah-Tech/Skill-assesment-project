using System;
using System.Collections.Generic;
namespace ToDoListConsoleApplication
{
	public class Program
	{
		static List<Task> tasks = new List<Task>();
		static void Main(string[] args)
		{
			bool exit = false;
			while (!exit)
			{
				DisplayMenu();
				string choice = GetUserInput("Enter your choice: ");
				switch (choice)
				{
					case "1":
						AddTask();
						break;
					case "2":
						DisplayTask();
						break;
					case "3":
						MarkTaskAsComplete();
						break;
					case "4":
						DisplayAllTasks();
						break;
					case "5":
						DeleteTask();
						break;
					case "6":
						exit = true;
						break;
					default:
						Console.WriteLine("Invalid choice.Pleace try again");
						break;
				}
				Console.WriteLine();

			}
		}
		static void DisplayMenu()
		{
			Console.WriteLine("ToDo List console Application");
			Console.WriteLine("1. Add a task");
			Console.WriteLine("2. Display task information");
			Console.WriteLine("3. Mark a task as complete");
			Console.WriteLine("4. Display a tasks ");
			Console.WriteLine("5. Delate a task");
			Console.WriteLine("6. Exit");

		}
		static void AddTask()
		{
			Console.WriteLine("Add a task ");
			string title = GetUserInput("Enter the task's title: ");
			string description = GetUserInput("Enter the task's description: ");
			DateTime dueDate = GetValidDueDate("Enter the task's due date (YYYY-MM-DD): ");

			Task task = new Task(title, description, dueDate);
			tasks.Add(task);

			Console.WriteLine("Task added successfully.");
		}


		static void DisplayTask()
		{
			Console.WriteLine("Display task information ");
			string title = GetUserInput("Enter the tasks title: ");
			var task = tasks.Find(t => t.Title == title);
			if (task != null)
			{
				Console.WriteLine(task); // Uses the overridden ToString() method of the Task class.
            }
			else
			{
				Console.WriteLine("Task not found.");
			}

		}
		static void MarkTaskAsComplete()
		{
			Console.WriteLine("Mark a task as complete ");
			string title = GetUserInput("Enter your title: ");
			var task = tasks.Find(t => t.Title == title);
			if (task != null)
			{
				task.Completed = true; // Marks the task as completed.
                Console.WriteLine("Task marked as complete.");
			}
			else
			{
				Console.WriteLine("Task not found.");
			}

		}
		static void DisplayAllTasks()
		{
			Console.WriteLine("Display All Tasks");
			if (tasks.Count > 0)
			{
				foreach (Task task in tasks)
				{
					Console.WriteLine(task); // Uses the overridden ToString() method of the Task class.
                    Console.WriteLine();
				}

			}
			else
			{
				Console.WriteLine("No tasks found.");
			}

		}
		static void DeleteTask()
		{
			Console.WriteLine("Delete a Task ");
			string title = GetUserInput("Enter the tasks title: ");
			var task = tasks.Find(t => t.Title == title);
			if (task != null)
			{
				tasks.Remove(task); // Removes the task from the list.
                Console.WriteLine();

			}
			else
			{
				Console.WriteLine(" Task not found.");
			}

		}
		static string GetUserInput(string message)
		{
			Console.WriteLine(message);

            return Console.ReadLine();
			
		}
		static DateTime GetValidDueDate(string message)
		{
			DateTime dueDate;
			while (true)
			{
				string input = GetUserInput(message);
				if (DateTime.TryParse(input, out dueDate)) // Validates the entered due date.
                    break;
				else
					Console.WriteLine("Invalid due Date format. please try again.");
			}
			return dueDate;
		}
	}
	class Task
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }
		public bool Completed { get; set; }

		public Task(string title, string description, DateTime dueDate)
		{
			Title = title;
			Description = description;
			DueDate = dueDate;
			Completed = false; // Initializes the task as incomplete by default.
        }
		public override string ToString()
		{
			// Formats the task information as a string for display.
			return $"Title: {Title}\nDescription: {Description}\nDue Date: {DueDate:yyyy-MM-dd}\nStatus: {(Completed ? "Complete" : "Incomplete")}";
		}

	}
}


