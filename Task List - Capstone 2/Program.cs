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

            do
            {
                int choice = Menu();
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;

                    default:
                        break;
                }


                Console.ReadLine();
                ender = true;
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
            int x = IsGoodDigit(Console.ReadLine());
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
            }            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Please try again: ");
                x = IsDigit(Console.ReadLine());
            }
            x = int.Parse(input);
            return x;
        }
        public static bool IsChoice(int x)
        {
            if (x > 0 && x < 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int IsGoodDigit(string input)
        {
            int x = IsDigit(input);
            if (IsChoice(x))
            {
                return x;
            }
            else
            {
                Console.Write("I didn't understand that. \nPlease try again:");
                x = IsGoodDigit(Console.ReadLine());
                return x;
            }
        }
        public static void DisplayTasks()
        {
            //get tasks
            //display tasks in order
        }
    }
}
