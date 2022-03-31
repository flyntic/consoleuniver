using System;

using System.Collections.Generic;

namespace ConsoleUniver
{
    public class University
    {
        public string NameOfUniversity { get; set; }
        public string AddressOfUniversity { get; set; }
        public List<string> Facultets { get; set; }
        public List<Student> Students { get; set; }

        public University()
        {
            UniversityIOConsoleManager.UniversityInit(this);
        }

        public void PrintInfo()
        {
            UniversityIOConsoleManager.PrintUniversityInfo(this);
            UniversityIOConsoleManager.PrintStudents(this.Students);
        }

        public void StudentsInit()
        {
            UniversityIOConsoleManager.StudentInit(this);
        }

        public void RequestStudentField()
        {
            Type studentType = typeof(Student);
            Request check;
            UniversityIOConsoleManager.PrintFieldsAndCheck(studentType,out check);

            List<Student> OutStudents;
            check.RequestExe( this.Students,out OutStudents);

            UniversityIOConsoleManager.PrintStudents(OutStudents);
        }

    }
}