using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_UAMS.properties
{
    class DegreeProgram
    {
        public string Title;
        public string Duration;
        public List<Subject> Subjects;
        public int seats;
        public DegreeProgram(string Title,string Duration, int seats)
        {
            this.Title = Title;
            this.Duration = Duration;
            this.seats = seats;
            Subjects = new List<Subject>();
        }
        public int CalculateCreditHour()
        {
            int count = 0;
            for(int x = 0; x < Subjects.Count; x++)
            {
                count = count + Subjects[x].CreditHour;
            }
            return count;
        }
        public bool AddSubject(Subject s)
        {
            int creditHours = CalculateCreditHour();
            if (creditHours + s.creditHours <= 20)
            {
                Subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isSubjectExists(Subject sub)
        {
            foreach(Subject s in Subjects)
            {
                if (s.SubjectCode == sub.SubjectCode)
                {
                    return true;
                }
            }
            return false;
            
        }
    }
}
