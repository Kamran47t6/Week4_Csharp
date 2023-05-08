using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_UAMS.properties
{
    class Student
    {
        public string Name;
        public int Age;
        public float FscMarks;
        public float EcatMarks;
        public double merit;
        public List<DegreeProgram> Preferences;
        public List<Subject> RegSubject;
        public DegreeProgram RegDegree;
        public Student(string Name,int Age,float FscMarks,float EcatMarks, double merit, List<DegreeProgram> Preferences)
        {
            this.Name = Name;
            this.Age = Age;
            this.FscMarks = FscMarks;
            this.EcatMarks = EcatMarks;
            this.merit = merit;
            this.Preferences = Preferences;
            RegSubject = new List<Subject>();
        }
        public void calculateMerit()
        {
            this.merit = (((FscMarks / 100) * 0.45) + ((EcatMarks / 400) * 0.55f)) * 100;
        }
        public bool regStudentSubject(Student s)
        {
            int Stch = getCreditHours();
            if(RegDegree!=null && RegDegree.isSubjectExists(s) && Stch + s.creditHours<=9)
            {
                RegSubject.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int getCreditHours()
        {
            int count = 0;
            foreach(Subject sub in RegSubject)
            {
                count = count + sub.CreditHour;
            }
            return count;
        }
        public float calculateFee()
        {
            float fee = 0;
            if (RegDegree != null)
            {
                foreach(Subject sub in RegSubject)
                {
                    fee = fee + sub.SubjectFee;
                }
            }
            return fee;
        }
        static Student StudentPresent(string name)
        {
            foreach(Student s in studentList)
            {
               if(name==s.Name && s.RegDegree != null)
                {
                    return s;
                }
            }
            return null;
        }
        static void CalculateFeeForAll()
        {
            foreach(Student s in studentlist)
            {
                if (s.RegDegree != null)
                {
                    
                        Console.WriteLine(s.Name + " has" + s.calculateFee() + "fees");
                    
                }
            }
        }
        static void registerSubjects(Student s)
        {
            Console.WriteLine("Enter how many subjects you want to register ");
            int count = int.Parse(Console.ReadLine());
            for(int x = 0; x < count; x++)
            {
                Console.WriteLine("Enter the Subject Code :");
                string code = Console.ReadLine();
                bool flag = false;
                foreach(Subject sub in s.RegDegree.Subjects)
                {
                    if(code==sub.SubjectCode && !(s.RegSubject.Contains(sub)))
                    {
                        s.regStudentSubject(sub);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter valid course ");
                    x--;
                }
            }
        }
        static List<Student> sortStudentByMerit()
        {
            List<Student> sortedStudentList = new List<Student>();
            foreach(Student s in studentList)
            {
                s.calculateMerit();
            }
            sortedStudentList = sortedStudentList.OrderByDescending(o => o.merit).ToList();
            return sortedStudentList;
        }
        static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach(Student s in sortedStudentList)
            {
                foreach(DegreeProgram d in s.Preferences)
                {
                    if(d.seats>0 && s.RegDegree == null)
                    {
                        s.RegDegree = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }
        static void printStudents()
        {
            foreach(Student s in studentList)
            {
                if (s.RegDegree != null)
                {
                    Console.WriteLine(s.Name + "did not get Admission");
                }
            }
        }
        static void clearScreen()
        {
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
            Console.Clear();
        }
        static void viewStudentInDegree(string degName)
        {
            Console.WriteLine("Name \t FSC \t Ecat \t Age");
            foreach(Student s in studentList)
            {
                if (s.RegDegree != null)
                {
                    Console.WriteLine(s.Name + "\t" + s.FscMarks + "\t" s.EcatMarks + "\t" + s.Age);

                }
            }
        }
        static void addIntoDegreeList(DegreeProgram d)
        {
            programList.Add(d);
        }
        static DegreeProgram takeInputForDegree()
        {
            string degreeName;
            float degreeDuration;
            int seats;
            Console.Write("ENter Degree Name :");
            degreeName = Console.ReadLine();
            Console.WriteLine("Enter Degree Duration :");
            degreeDuration = float.Parse(Console.ReadLine());
            DegreeProgram degprog = new DegreeProgram(degreeName, degreeDuration, seats);
            for(int x = 0; x < count; x++)
            {
                degprog.AddSubject(takeInputForDegree());

            }
            return degprog;
        }
        static int Menu()
        {
            int option;
            Console.WriteLine("1 : Add Student ");
            Console.WriteLine("2 : Add Degree Program");
            Console.WriteLine("3. Generate Merit List ");
            Console.WriteLine("4 : View Registered Students ");
            Console.WriteLine("5 : View students of a specific program ");
            Console.WriteLine("6. Register subjects :");
            Console.WriteLine("7 : Calulate fees for all Registered Students");
            Console.WriteLine("8 : Exit");
            Console.Write("Enter option :");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        
    }
}
