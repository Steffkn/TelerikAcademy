using System;

namespace _02.NamingIdentifiers
{
    class Class123
    {
        const int MAX_COUNT = 6;

        public class InnerClass
        {
            public void ConvertBooleanToString(bool variable)
            {
                string stringVariable = variable.ToString();
                Console.WriteLine(stringVariable);
            }
        }
        public static void Run()
        {
            Class123.InnerClass variable = new Class123.InnerClass();
            variable.ConvertBooleanToString(true);
        }
    }

}
