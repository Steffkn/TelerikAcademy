using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics;
namespace WorkingWithGenerics
{
    class GenericListTest
    {
        static void Main()
        {

            GenericList<string> StringGenericList = new GenericList<string>(10);

            // 100 words string
            string loremString = "Lorem ipsum dolor sit amet consectetur adipiscing elit Ut vestibulum venenatis volutpat Fusce condimentum orci id nisi varius eget adipiscing dui pellentesque Nunc ullamcorper tempor posuere Vestibulum est diam viverra in placerat vitae elementum a enim Aenean consequat imperdiet fringilla Phasellus ac diam at tortor adipiscing iaculis Nam lobortis tincidunt tortor a ornare turpis convallis eget Proin quis ornare sapien Cras feugiat magna nec lorem laoreet a tincidunt erat bibendum Quisque non risus neque Quisque turpis diam imperdiet a elementum vitae suscipit a lacus Curabitur ac eros in nibh fermentum adipiscing et eu libero lorem ipsum dolor sit amet consectetur";
            string[] strArray = loremString.Split(' ');

            for (int i = 0; i < strArray.Length; i++)
            {
                StringGenericList.AddItem(i, strArray[i]);
                StringGenericList.AddItem("Last " + strArray[i]);
            }

            //StringGenericList.AddItem(205, "IOHOHO <----------");
            //StringGenericList.AddItem(1000, "IOHOHO should be at 1st line error if capacity is less than 1000");
            Console.WriteLine(StringGenericList.ItemAt(100));
            Console.WriteLine(StringGenericList.Item("Last Lorem"));
            StringGenericList.DeleteItem(100);
            Console.WriteLine(StringGenericList.ItemAt(100));
            Console.WriteLine(StringGenericList.Item("Last Lorem"));
            Console.WriteLine(StringGenericList.ItemAt(193));
            StringGenericList.ShowList();
            Console.WriteLine(StringGenericList.Min<string>());
            Console.WriteLine(StringGenericList.Max<string>());


            //  Double Test
            GenericList<double> DoubleGenericList = new GenericList<double>(10);
            for (int i = 1; i <= 100; i++)
            {
                DoubleGenericList.AddItem(i, i * 10 + i / (double)1000);

                DoubleGenericList.AddItem(i + i / (double)1000);
            }

            DoubleGenericList.AddItem(205, 202.202);
            DoubleGenericList.AddItem(1000, 202.202);
            Console.WriteLine(DoubleGenericList.ItemAt(100));
            Console.WriteLine(DoubleGenericList.Item(1000.1));
            DoubleGenericList.DeleteItem(100);
            Console.WriteLine(DoubleGenericList.ItemAt(100));
            Console.WriteLine(DoubleGenericList.Item(1000.1));
            DoubleGenericList.ShowList();
            Console.WriteLine(DoubleGenericList.Min<double>());
            Console.WriteLine(DoubleGenericList.Max<double>());


            //  Integer Test
            GenericList<int> IntGenericList = new GenericList<int>(10);
            for (int i = 1; i <= 100; i++)
            {
                IntGenericList.AddItem(i, i * 10);
                IntGenericList.AddItem(i);
            }
            IntGenericList.AddItem(205, 202);
            IntGenericList.AddItem(1000, 202);
            Console.WriteLine(IntGenericList.ItemAt(100));
            Console.WriteLine(IntGenericList.Item(1000));
            IntGenericList.DeleteItem(100);
            Console.WriteLine(IntGenericList.ItemAt(100));
            Console.WriteLine(IntGenericList.Item(1000));
            IntGenericList.ShowList();

            Console.WriteLine(IntGenericList.Min<int>());
            Console.WriteLine(IntGenericList.Max<int>());

        }
    }
}
