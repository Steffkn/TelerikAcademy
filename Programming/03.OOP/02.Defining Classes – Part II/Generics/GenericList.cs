using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class GenericList<T>
            where T : IComparable<T>
    {
        int CAPACITY;
        int itemsNumber;
        T[] GenericArrayOfT;

        public GenericList(int capacity)
        {
            this.CAPACITY = capacity;
            this.itemsNumber = 0;
            this.GenericArrayOfT = new T[capacity];
        }

        /// <summary>
        /// Method that adds a item
        /// </summary>
        /// <param name="item"><T> item</param>
        public void AddItem(T item)
        {

            if( itemsNumber >= CAPACITY )
            {
                this.GenericArrayOfT = DoubleListCapacity(this.GenericArrayOfT);
            }
            GenericArrayOfT[itemsNumber] = (T)item;

            itemsNumber++;

        }

        /// <summary>
        /// Add item at given position.
        /// </summary>
        /// <param name="index">Position</param>
        /// <param name="item"><T> item</param>
        public void AddItem(int index, T item)
        {
            if( index >= CAPACITY )
            {
                Console.WriteLine("Index out of bounts! Must be less than {0}!", CAPACITY);
                return;
            }
            if( itemsNumber >= CAPACITY - 1 ) // if there is atleast 1 free slot
            {
                this.GenericArrayOfT = DoubleListCapacity(this.GenericArrayOfT);
            }

            if( index <= itemsNumber )
            {
                for( int i = itemsNumber; i >= index; i-- )
                {
                    this.GenericArrayOfT[i + 1] = this.GenericArrayOfT[i];
                }
                this.GenericArrayOfT[index] = (T)item;
                ;
            }
            else
            {
                this.GenericArrayOfT[index] = (T)item;
                ;
                this.itemsNumber = index;
            }

            itemsNumber++;
        }

        /// <summary>
        /// Method that returns a item at a position 'index'.
        /// </summary>
        /// <param name="index">Given position</param>
        /// <returns>Returns a item of type <T></Ts></returns>
        public T ItemAt(int index)
        {
            if( index > itemsNumber )
            {
                Console.WriteLine("Invalid imput! ItemAt({0});", index);
                return default(T);
            }
            return this.GenericArrayOfT[index];
        }

        /// <summary>
        /// Method that returns the position of an item
        /// </summary>
        /// <param name="value">Item of type T</param>
        /// <returns></returns>
        public string Item(T value)
        {
            for( int i = 0; i < this.itemsNumber; i++ )
            {
                if( this.GenericArrayOfT[i] != null && this.GenericArrayOfT[i].ToString().Equals(value.ToString()) )
                {
                    return string.Format("{0} found at position {1}", value, i);
                }
            }
            return string.Format("{0} not found!", value);
        }

        /// <summary>
        /// Delete a item at given position.
        /// </summary>
        /// <param name="index">Given position</param>
        public void DeleteItem(int index)
        {
            for( int i = index; i < this.itemsNumber; i++ )
            {
                this.GenericArrayOfT[i] = this.GenericArrayOfT[i + 1];
            }
            this.GenericArrayOfT[this.itemsNumber] = default(T);
            this.itemsNumber--;
        }

        /// <summary>
        /// Delete the list
        /// </summary>
        public void ClearList()
        {
            for( int i = 0; i <= this.itemsNumber; i++ )
            {
                this.GenericArrayOfT[i] = default(T);
            }

            this.itemsNumber = 0;
        }

        /// <summary>
        /// Show the content of the list
        /// </summary>
        public void ShowList()
        {
            if( this.itemsNumber == 0 )
            {
                Console.WriteLine("The list is empty!");
            }
            else
            {
                for( int i = 0; i < this.itemsNumber; i++ )
                {
                    Console.WriteLine(this.GenericArrayOfT[i]);
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Double the capacity of the list
        /// </summary>
        /// <param name="ArrayOfT"></param>
        /// <returns></returns>
        T[] DoubleListCapacity(T[] ArrayOfT)
        {
            CAPACITY *= 2;
            T[] newArrayOfT = new T[CAPACITY];
            for( int i = 0; i < this.itemsNumber; i++ )
            {
                newArrayOfT[i] = ArrayOfT[i];
            }
            return newArrayOfT;
        }

        /// <summary>
        /// Finds the min value of the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public string Min<T>()
            where T : IComparable<T>
        {
            int minElementIndex = 0;
            for( int i = 0; i <= this.itemsNumber; i++ )
            {
                if( this.GenericArrayOfT[i] != null && (this.GenericArrayOfT[minElementIndex].CompareTo(this.GenericArrayOfT[i]) > 0) )
                {
                    minElementIndex = i;
                }
            }
            return string.Format("The element with min value is {0}!", this.GenericArrayOfT[minElementIndex]);
        }

        /// <summary>
        /// Finds the max value of the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public string Max<T>()
            where T : IComparable<T>
        {
            int maxElementIndex = 0;
            for( int i = 0; i <= this.itemsNumber; i++ )
            {
                if( this.GenericArrayOfT[i] != null && ( this.GenericArrayOfT[maxElementIndex].CompareTo(this.GenericArrayOfT[i]) < 0) )
                {

                    maxElementIndex = i;
                }
            }
            return string.Format("The element with max value is {0}!",this.GenericArrayOfT[maxElementIndex]);
        }
    }
}
