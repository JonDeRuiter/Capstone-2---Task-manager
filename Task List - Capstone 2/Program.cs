using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_List___Capstone_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //build a task class with members: Team Member Name, Brief Task descritpion, Due Date, Whether or not it's been completed

            //Make a list to easy add and delete task objects 
            List<Task> taskList = new List<Task>();

            bool ender = true;

            DateTime dueDate = DateTime.Parse("1 / 12 / 2019");

            Task firstTask = new Task("Jimmy John", "Make a Sandwich", dueDate);
            Task secondTask = new Task("Little Caesars", "Yell: PIZZA PIZZA!", dueDate);
            taskList.Add(firstTask);
            taskList.Add(secondTask);

            //Make the date display w/out the time

            do
            {
                int choice = Menu();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n LIST TASKS");
                        foreach (Task t in taskList)
                        {
                            Console.WriteLine($"Task {taskList.IndexOf(t) + 1}");
                            Console.WriteLine("Done?      Due Date     Team Member     Description");
                            Console.WriteLine($"{t.DoneNotDone}     {t.DueDate}     {t.MemberName}     {t.BriefDescription}");
                            Console.WriteLine();
                        }                        
                        break;
                    case 2:
                        //Add Tasks
                        taskList.Add(NewTask());
                        break;
                    case 3:
                        //Delete Tasks
                        int toDelete = DeleteTask(taskList.Count);
                        
                        if (toDelete >= 0)
                        {
                            taskList.RemoveAt(toDelete);
                        }
                        else
                        {
                            Console.WriteLine("Returning to main menu.");
                        }
                        break;
                    case 4:
                        //Mark Task Complete
                        Console.WriteLine($"WHich task # would you like to complete? 1-{taskList.Count}");
                        int x = IsGoodDigit(Console.ReadLine(), taskList.Count);
                        x--;
                        Console.WriteLine($"Task {x}");
                        Console.WriteLine("Done?      Due Date     Team Member     Description");
                        Console.WriteLine($"{taskList[x].DoneNotDone}     {taskList[x].DueDate}     {taskList[x].MemberName}     {taskList[x].BriefDescription}");
                        Console.WriteLine();

                        Console.WriteLine($"Are you sure you want to compelete this task? Y/N: ");                        
                        if (Assurances())
                        {
                            taskList[x].DoneNotDone = true; ;
                        }                       
                        else
                        {
                            Console.WriteLine("Returning to main menu.");
                        }                        
                        break;
                    case 5:
                        //Exits the program
                        Console.Write("Are you sure you want to exit? Y/N: ");
                        
                        if (Assurances())
                        {
                            ender = true;
                        }
                        else
                        {
                            ender = false;
                        }
                        break;
                    default:
                        break;
                        
                }
                Console.WriteLine();
            } while (ender);
        }
        public static int Menu()
        {
            Console.WriteLine("Welcome to the Grand Circus Task Manager.");
            Console.WriteLine("     1. List Tasks");
            Console.WriteLine("     2. Add Task");
            Console.WriteLine("     3. Delete Task");
            Console.WriteLine("     4. Mark Task Complete");
            Console.WriteLine("     5. Quite");
            Console.Write("What would you like to do?: ");
            int x = IsGoodDigit(Console.ReadLine(), 5);
            return x;

        }
        public static string NotEmpty(string input)
        {
            input = input.Trim();
            try
            {
                if (input == null || input == "")
                {
                    throw new Exception("Input is empty, Please enter a number");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Please enter a number 1-5: ");
                input = NotEmpty(Console.ReadLine());
            }
            return input;
        }
        public static int IsDigit(string input)
        {
            input = NotEmpty(input);
            char[] charArray = input.ToCharArray();
            int x;
            try
            {
                for (int i = 0; i < charArray.Length; i++)
                {
                    if (!(char.IsDigit(charArray[i])))
                    {
                        throw new Exception("Input must be a digit.");
                    }
                    
                }
                x = int.Parse(input);
                return x;
            }            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Please try again: ");
                x = IsDigit(Console.ReadLine());
                return x;
            }
            
            
        }
        public static bool IsChoice(int x, int range)
        {
            if (x > 0 && x < (range + 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int IsGoodDigit(string input, int range)
        {
            int x = IsDigit(input);
            if (IsChoice(x, range))
            {
                return x;
            }
            else
            {
                Console.Write("I didn't understand that. \nPlease try again: ");
                x = IsGoodDigit(Console.ReadLine(), range);
                return x;
            }
        }
        public static Task NewTask()
        {
            string name, description;
            DateTime dueDate;

            Console.WriteLine("For a new task: ");
            Console.Write("Please enter the name of the Team Member who will be responsible for this task: ");
            name = Console.ReadLine();

            Console.Write("Please enter a description of the task: ");
            description = Console.ReadLine();

            Console.Write("Please enter a date that the task must be finished by: ");
            while (!(DateTime.TryParse(Console.ReadLine(), out dueDate)))
            {
                Console.Write("Please enter a valid date: ");
            }
            Task task = new Task(name, description, dueDate);
            return task;
        }
        public static int DeleteTask(int range)
        {
            Console.Write($"Which task would you like to delete? \n 1-{range}: ");
            int x = IsGoodDigit(Console.ReadLine(), range);
            Console.Write($"Are you sure you want to delete task # {x}? \nY/N: ");
            string confirm = Console.ReadLine();
            confirm = confirm.ToLower();
            if (Assurances())
            {
                Console.WriteLine($"Deleting task # {x}...");                
            }
            else
            {
                x = -1;
            }
            x--;
            return x;
        }
        public static bool Assurances()
        {
            bool booly;
            try
            {
                string confirm = Console.ReadLine();
                confirm = confirm.ToLower();
                if (confirm == "y")
                {
                    booly = true;
                }
                else if (confirm == "n")
                {
                    booly = false;
                }
                else
                {
                    throw new Exception("I didn't understand that. Inpt must be either 'Y' or 'N'.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Please try again: ");
                booly = Assurances();
            }
            return booly;
        }

    }
}
