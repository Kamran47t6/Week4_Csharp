using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_UAMS.properties
{
    class Subject
    {
       public string SubjectCode;
       public int CreditHour;
       public string SubjectType;
       public int SubjectFee;
        public Subject(string SubjectCode ,int CreditHour, string SubjectType, int SubjectFee)
        {
            this.SubjectCode = SubjectCode;
            this.CreditHour = CreditHour;
            this.SubjectType = SubjectType;
            this.SubjectFee = SubjectFee;
        }
    }
}
