using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConsoleUniver
{
    public static class UniversityIOConsoleManager
    {
        public static void UniversityInit(University university)
        {
            Console.Write("Введите название университета: ");
            university.NameOfUniversity = Console.ReadLine();
            Console.Write("Введите адрес университета: ");
            university.AddressOfUniversity = Console.ReadLine();
            university.Facultets = new List<string>();
            university.Students = new List<Student>();
            Console.Write("Введите названия факультетов через запятую: ");
            string[] facultetsTemp = Console.ReadLine().Split(",");
            foreach (var item in facultetsTemp)
            {
                university.Facultets.Add(item.Trim());
            }
        }

        public static void PrintUniversityInfo(University university)
        {
            Console.WriteLine($"Университет - {university.NameOfUniversity}");
            Console.WriteLine($"Адрес - {university.AddressOfUniversity}");
            Console.WriteLine("Факультеты:");
            foreach (var item in university.Facultets)
            {
                Console.WriteLine(item);
            }
        }

        public static void StudentInit(University university)
        {
            Console.Write("Введите количество студентов к добавлению:");
            int quantityStudents = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < quantityStudents; i++)
            {
                Student student = new Student();
                Console.Write("Фио студента: ");
                student.FIO = Console.ReadLine();
                Console.Write("Дата рождения студента в формате dd.mm.yyyy: ");
                student.Birthday = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Выберите факультет и введите его порядковый номер: ");
                int counter = 1;
                foreach (var item in university.Facultets)
                {
                    Console.WriteLine(counter + ". " + item);
                    counter++;
                }

                student.Facultet = university.Facultets[Convert.ToInt32(Console.ReadLine()) - 1];
                Console.Write("Группа студента: ");
                student.Group = Console.ReadLine();
                university.Students.Add(student);
            }
        }

        private static string ConvertField(string fieldname)
        { 
            string[] name = fieldname.Split('<', '>');
            if (name.Length == 1)
                return name[0];
            else
                return name[1];
        }
    
        public static void PrintStudents(List<Student> Students)
        {
            Console.WriteLine("Список студентов: ");
            Type tstudent = typeof(Student);
            
            FieldInfo[] fields = tstudent.GetFields( 
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public); //| BindingFlags.Static

            foreach (var student in Students)
            {
                foreach (FieldInfo field in fields)
                {
                   Console.WriteLine(ConvertField(field.Name) + " : "+ field.GetValue(student));
                }
                Console.WriteLine("-------------------");
            }
        }

        public static void PrintAndReadTypeRequest(out int key, Type t)
        {
            foreach (var f in Request.RequestIO)
                if (f.Value.types.Contains(t))
                    Console.WriteLine((int) f.Key + " - " + f.Value.Name);

            Console.WriteLine("Выберите поиск ");
            key = 0;
            while (!((Int32.TryParse(Console.ReadLine(), out key)) && (key <= Request.RequestIO.Count)))

                Console.WriteLine("Повторите выбор ( 0 - " + Request.RequestIO.Count + " ) ");
        }

        public static void ReadIntValue(out int value)
        {
            Console.WriteLine("Введите значение для сравнения ");
            value = 0;
            while (!(Int32.TryParse(Console.ReadLine(), out value)))
                Console.WriteLine("Повторите выбор ( 0 - " + Request.RequestIO.Count + " ) ");
        }

        public static void ReadStrValue(out string str)
        {
            Console.WriteLine("Введите строку поиска ");
            str = Console.ReadLine();
        }

        public static void ReadCount(out int count)
        {
            Console.WriteLine("Введите число результатов для вывода ");
            count = 0;
            while (!(Int32.TryParse(Console.ReadLine(), out count)))
                Console.WriteLine("Повторите выбор  ");
        }


        public static void PrintFieldsAndCheck(Type t, out Request request)
        {
            FieldInfo[] fields = t.GetFields( //
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public); //| BindingFlags.Static

            Console.WriteLine("Выберите поле по которому произвести "); //+ request.EnTypeRequest);
            int i = 0;


            foreach (var F in fields)
            {
               //string[] name = F.Name.Split('<', '>');
               //if (name.Length == 1)
               //    Console.WriteLine($"{++i} - {name[0]}");
               //else
               //    Console.WriteLine($"{++i} - {name[1]}");
               Console.WriteLine($"{++i} -{ConvertField(F.Name)}");
            }

            int n = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Задайте тип поиска и его параметры :");

            request = new Request(fields[n - 1]);


            // return request;
        }
    }
}