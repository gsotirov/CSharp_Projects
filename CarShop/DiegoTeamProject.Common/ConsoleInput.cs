using System;
using System.ComponentModel;
using System.Linq;

namespace DiegoTeamProject.Common
{
    public static class ConsoleInput
    {
        public static TEnum GetEnum<TEnum>(string text)
            where TEnum : struct
        {
            string userInputString = string.Empty;
            TEnum resultInputType = default(TEnum);
            bool enumParseResult = false;

            while (!enumParseResult)
            {
                Console.Clear();
                Console.WriteLine(text);
                Console.WriteLine();
                foreach (var item in Enum.GetNames(typeof(TEnum)))
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
                Console.Write("Please input one of values: ");
                userInputString = System.Console.ReadLine();
                enumParseResult = Enum.TryParse(userInputString, true, out resultInputType);
            }

            Console.Clear();
            return resultInputType;
        }

        public static T GetData<T>(string text)
        {
            string userInputString = string.Empty;
            T resultInputType = default(T);
            bool enumParseResult = false;

            while (!enumParseResult)
            {
                Console.Clear();
                Console.Write(text);
                userInputString = System.Console.ReadLine();

                enumParseResult = TryParse<T>(userInputString, out resultInputType);
            }

            Console.Clear();
            return resultInputType;
        }

        public static DateTime GetDateTime(string text)
        {
            string userInputString = string.Empty;
            DateTime resultInputType = default(DateTime);
            bool enumParseResult = false;

            while (!enumParseResult)
            {
                Console.Clear();
                Console.Write(text);
                userInputString = System.Console.ReadLine();
                enumParseResult = DateTime.TryParse(userInputString, out resultInputType);
            }

            Console.Clear();
            return resultInputType;
        }

        private static bool TryParse<T>(string s, out T value)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                value = (T)converter.ConvertFromString(s);
                return true;
            }
            catch
            {
                value = default(T);
                return false;
            }
        }
    }
}