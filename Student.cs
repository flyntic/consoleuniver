using System;

namespace ConsoleUniver


{
    public class Student
    {
        public static int id = 0;
        public string FIO { get; set; }
        public int StudentId { get; set; }
        public DateTime Birthday { get; set; }
        public string Facultet { get; set; }
        public string Group { get; set; }

        private int age
        {
            get { return Age;}  }

        public int Age 
      {
           get
           {
              
            // if ((DateTime.Now.Month >= Birthday.Month) && (DateTime.Now.Day >= Birthday.Day))
            //     age = DateTime.Now.Year - Birthday.Year;
            // else
            //     age = DateTime.Now.Year - Birthday.Year - 1;
               return 10;
           }
           set
           {
              
            //  if ((DateTime.Now.Month >= Birthday.Month) && (DateTime.Now.Day >= Birthday.Day))
            //      age = DateTime.Now.Year - Birthday.Year;
            //  else
            //      age = DateTime.Now.Year - Birthday.Year - 1;
             // Age = age;
             //age = value;
           }
       }

        public Student()
        {
            id++;
            this.StudentId = id;

        }
    }
}