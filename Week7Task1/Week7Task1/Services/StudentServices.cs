using Newtonsoft.Json;
using Week7Task1.Database;
using Week7Task1.Models;

namespace Week7Task1.Services
{
    static class StudentServices
    {
        public static bool AddStudent(Student student)
        {
            
            using (StreamReader sr = new StreamReader(@"C:\Users\gunas\source\repos\Week7Task1\Week7Task1\students.json"))
            {
                string stds = sr.ReadToEnd();
               StudentDatabase.students = JsonConvert.DeserializeObject<List<Student>>(stds);
            }
            StudentDatabase.students.Add(student);

            using (StreamWriter sw = new StreamWriter(@"C:\Users\gunas\source\repos\Week7Task1\Week7Task1\students.json"))
            {
                string stds = JsonConvert.SerializeObject(StudentDatabase.students);
                sw.WriteLine(stds);
            }
            return true;
        }

        public static void RemoveStudent(string code)
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\gunas\source\repos\Week7Task1\Week7Task1\students.json"))
            {
                string stds = sr.ReadToEnd();
                StudentDatabase.students = JsonConvert.DeserializeObject<List<Student>>(stds);
            }
            
            Student removeStudent = StudentDatabase.students.FirstOrDefault(s => s.Code == code);

            if (removeStudent != null)
            {
                StudentDatabase.students.Remove(removeStudent);

                using (StreamWriter sw = new StreamWriter(@"C:\Users\gunas\source\repos\Week7Task1\Week7Task1\students.json"))
                {
                    string stds = JsonConvert.SerializeObject(StudentDatabase.students);
                    sw.WriteLine(stds);
                }

                Console.WriteLine($"{removeStudent.Code} removed!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        public static void EditStudent(string code) 
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\gunas\source\repos\Week7Task1\Week7Task1\students.json"))
            {
                string stds = sr.ReadToEnd();
                StudentDatabase.students = JsonConvert.DeserializeObject<List<Student>>(stds);
            }

            Student editStudent = StudentDatabase.students.FirstOrDefault(s => s.Code == code);

            if (editStudent != null)
            {
                Console.WriteLine("Edit Name: ");
                string namee = Console.ReadLine();
                Console.WriteLine("Edit Surname: ");
                string surnamee = Console.ReadLine();

                editStudent.Name = namee;
                editStudent.Surname = surnamee;
                
                using (StreamWriter sw = new StreamWriter(@"C:\Users\gunas\source\repos\Week7Task1\Week7Task1\students.json"))
                {
                    string stds = JsonConvert.SerializeObject(StudentDatabase.students);
                    sw.WriteLine(stds);
                }

                Console.WriteLine($"{editStudent.Code} edited!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }
    }
}
