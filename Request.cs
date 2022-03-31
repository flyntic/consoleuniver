using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Schema;

namespace ConsoleUniver
{
    public class Request
    {
        public enum enTypeRequest
        {
            requestNodef = 0,
            requestFindMax,
            requestFindMin,
            requestFindEqu,
            requestFindMore,
            requestFindLess,
            requestFindEquStr,
            requestSortMin,
            requestSortMax
        }

        public struct defRequest
        {
            public string Name;
            public List<Type> types;
        }

        public static Dictionary<enTypeRequest, defRequest> RequestIO = new Dictionary<enTypeRequest, defRequest>()
        {
            {
                enTypeRequest.requestNodef,
                new defRequest()
                    {Name = "Отменить поиск", types = new List<Type>() {typeof(int), typeof(string), typeof(DateTime)}}
            },
            {
                enTypeRequest.requestFindMax,
                new defRequest()
                    {Name = "Поиск максимальных значений", types = new List<Type>() {typeof(int), typeof(DateTime)}}
            },
            {
                enTypeRequest.requestFindMin,
                new defRequest()
                    {Name = "Поиск минимальных значений", types = new List<Type>() {typeof(int), typeof(DateTime)}}
            },
            {
                enTypeRequest.requestFindEqu,
                new defRequest()
                    {Name = "Поиск значений равных", types = new List<Type>() {typeof(int), typeof(DateTime)}}
            },
            {
                enTypeRequest.requestFindMore,
                new defRequest()
                    {Name = "Поиск значений больших чем", types = new List<Type>() {typeof(int), typeof(DateTime)}}
            },
            {
                enTypeRequest.requestFindLess,
                new defRequest()
                    {Name = "Поиск значений меньших", types = new List<Type>() {typeof(int), typeof(DateTime)}}
            },
            {
                enTypeRequest.requestFindEquStr,
                new defRequest()
                    {Name = "Поиск совпадающих по строке", types = new List<Type>() {typeof(string), typeof(DateTime)}}
            },
            {
                enTypeRequest.requestSortMin,
                new defRequest()
                {
                    Name = "Соритировка по возрастанию",
                    types = new List<Type>() {typeof(int), typeof(string), typeof(DateTime)}
                }
            },
            {
                enTypeRequest.requestSortMax,
                new defRequest()
                {
                    Name = "Сортировка по убыванию",
                    types = new List<Type>() {typeof(int), typeof(string), typeof(DateTime)}
                }
            },
        };

        public enTypeRequest EnTypeRequest { get; set; }
        public int Value { get; set; }

        public int Count { get; set; }
        public string StrValue { get; set; }

        // public DateTime DateTimeValue { get; set; }


        public FieldInfo Field { get; set; }

        public Request(FieldInfo field)
        {
            int key;

            Type ftype = field.FieldType;
            UniversityIOConsoleManager.PrintAndReadTypeRequest(out key, ftype);

            EnTypeRequest = (enTypeRequest) key;
            int value = 0;
            int count = 0;
            string strvalue = null;
            switch (EnTypeRequest)
            {
                case enTypeRequest.requestFindMax:
                    //UniversityIOConsoleManager.ReadCount(out count);
                    break;
                case enTypeRequest.requestFindMin:
                    //UniversityIOConsoleManager.ReadCount(out count);
                    break;
                case enTypeRequest.requestFindEqu:
                    UniversityIOConsoleManager.ReadIntValue(out value);
                    break;
                case enTypeRequest.requestFindMore:
                    UniversityIOConsoleManager.ReadIntValue(out value);
                    UniversityIOConsoleManager.ReadCount(out count);
                    break;
                case enTypeRequest.requestFindLess:
                    UniversityIOConsoleManager.ReadIntValue(out value);
                    UniversityIOConsoleManager.ReadCount(out count);
                    break;
                case enTypeRequest.requestFindEquStr:
                    UniversityIOConsoleManager.ReadStrValue(out strvalue);
                    break;
            }

            Value = value;
            Count = count;
            StrValue = strvalue;
            Field = field;
        }


        public void RequestExe(List<Student> Elements,
            out List<Student> OutElements) //List<Type> Elements, out List<Type> OutElements)
        {
            OutElements = new List<Student>();
            if (Elements.Count == 0) return;

            // FieldInfo field = Elements[0].GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)[Field];

            //Type m;
            switch (EnTypeRequest)
            {
                case enTypeRequest.requestFindMax:

                    Student studentMaxValue = Elements[0];
                    int maxValue = Convert.ToInt32(Field.GetValue(studentMaxValue));
                    foreach (var element in Elements)
                        if (Convert.ToInt32(Field.GetValue(element)) >= maxValue)
                        {
                            maxValue = Convert.ToInt32(Field.GetValue(element));
                            studentMaxValue = element;
                        }

                    OutElements.Add(studentMaxValue);
                    break;

                case enTypeRequest.requestFindMin: break;
                case enTypeRequest.requestFindEqu:
                    foreach (var m in Elements)
                        if (Field.GetValue(m).Equals(Value))
                        {
                            OutElements.Add(m);
                        }

                    break;

                case enTypeRequest.requestFindMore: break;
                case enTypeRequest.requestFindLess: break;
                case enTypeRequest.requestFindEquStr:
                    foreach (var m in Elements)
                        if (Field.GetValue(m).ToString().Contains(StrValue))

                        {
                            OutElements.Add(m);
                        }

                    break;
            }
        }
    }
}