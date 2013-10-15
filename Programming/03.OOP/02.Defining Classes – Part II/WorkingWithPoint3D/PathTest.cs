using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space3D;

namespace WorkingWithPoint3D
{
    class PathTest
    {
        static void Main()
        {
            Point3D a = new Point3D(0, 0, 0);
            Point3D b = new Point3D(1, 1, 1);
            Point3D zero = Point3D.Point0;

            Path beerPath = new Path();
            /*beerPath.AddPoint(Point3D.Point0);
            beerPath.AddPoint(a);
            beerPath.AddPoint(b);
            beerPath.AddPoint(new Point3D(5, 18, 10));
            beerPath.AddPoint(b);
            beerPath.AddPoint(zero);

            beerPath.ShowPath();

            beerPath.DeletePoint(b);    // will delete the 1st 'b' point

            beerPath.ShowPath();*/

            // generate some points
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        beerPath.AddPoint(new Point3D(i, j, k));
                        
                    }
                }
            }
            beerPath.ShowPath();

            // there is no file validation..
            string file = "BeerTime.path";

            PathStorage.SavePath(file , beerPath);
            Path myNewBeerPath = PathStorage.LoadPath(file);
            myNewBeerPath.ShowPath();
        }
    }
}
