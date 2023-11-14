using Newtonsoft.Json;
using System.Drawing;
using Week7Task1.Database;
using Week7Task1.Exceptions;
using Week7Task1.Models;
using Week7Task1.Services;

namespace Week7Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Add Student");
                Console.WriteLine("2 - Remove Student");
                Console.WriteLine("3 - Edit Student");

                int.TryParse(Console.ReadLine(), out int choose);

                switch (choose)
                {
                    case 1:
                        do
                        {
                            Console.Write("Enter name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter surname: ");
                            string surname = Console.ReadLine();

                            try
                            {
                                Console.Write("Enter code: ");
                                string code = Console.ReadLine();

                                var result = StudentDatabase.students.FirstOrDefault(st => st.Code == code);

                                if (result == null)
                                {
                                    StudentServices.AddStudent(new Student { Name = name, Surname = surname, Code = code });
                                    Console.WriteLine("Succeed");
                                }
                                else
                                {
                                    throw new InvalidCodeException("This code is already exist, try again.");
                                }
                            }
                            catch (InvalidCodeException ex)
                            {
                                Console.WriteLine(ex.Message);

                            }
                            Console.WriteLine("Do you want to continue? Y/N");
                        }
                        while (Console.ReadLine() == "Y");
                        break;
                    case 2:
                        Console.WriteLine("Enter the code of the student you want to delete: ");
                        string code1 = Console.ReadLine();
                        StudentServices.RemoveStudent(code1);
                        break;
                    case 3:
                        Console.WriteLine("Enter the code of the student you want to edit: ");
                        string code2 = Console.ReadLine();
                        StudentServices.EditStudent(code2);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again!");
                        break;
                }
            }
        }
    }
}