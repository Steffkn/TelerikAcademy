using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space3D
{
    /// <summary>
    /// Class Path that holds a sequence of points in the 3D space. 
    /// </summary>
    public class Path
    {
        List<IPoint3D> path = new List<IPoint3D>();

        /// <summary>
        /// Add a point to the path.
        /// </summary>
        /// <param name="point">The point to be added.</param>
        public void AddPoint(Point3D point)
        {
            this.path.Add(point);
        }
        /// <summary>
        /// Delete a point to the path.
        /// </summary>
        /// <param name="point">The point to be deleted.</param>
        public void DeletePoint(Point3D point)
        {
            this.path.Remove(point);
        }

        /// <summary>
        /// Method that will return all points from the path.
        /// </summary>
        public void ShowPath()
        {
            Console.WriteLine("Current path:");
            foreach (var point in this.path)
            {
                Console.WriteLine(point.ToString());
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Method that finds a point in a path by index of the point and prints it on the console
        /// </summary>
        /// <param name="index">Index of the point</param>
        /// <returns>Returns a point as a string representation and null if its not found.</returns>
        public string PathToString(int index)
        {
            int i = 0;
            foreach (var point in this.path)
            {
                if (i == index)
                {
                    return string.Format("{0},{1},{2}", point.PointX.ToString(), point.PointY.ToString(), point.PointZ.ToString());
                }
                i++;
            }
            return null;
        }

    }
}
