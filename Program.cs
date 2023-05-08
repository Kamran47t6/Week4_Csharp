using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4_UAMS.properties;
namespace Week4_UAMS
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            do
            {
                option = Menu();
                Console.Clear();
                if (option == 1)
                {
                    if (ProgramList.Count > 0)
                    {
                        Student s = takeInputForStudent();
                        addIntoStudentList(s);
                    }
                }
                else if (option == 2)
                {
                    DegreeProgram d = takeInputForDegree();
                    addIntoDegreeList();
                }
                else if (option == 3)
                {
                    List<Student> sortedStudentList = new List<Student>();
                    sortedStudentList = sortedStudentsByMerit();
                    giveAdmission();
                }
                else if (option == 4)
                {
                    viewRegisterStudents();
                }
                else if (option == 5)
                {
                    string degName;
                    Console.Write("Enter Degree Name :");
                    degName = Console.ReadLine();
                    viewStudentInDegree(degName);
                }

            } while (option != 8);
            Console.ReadKey();
        }
    }
}
