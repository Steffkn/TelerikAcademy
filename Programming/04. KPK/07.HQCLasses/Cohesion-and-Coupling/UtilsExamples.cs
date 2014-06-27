namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileManager.GetFileExtension("example"));
            Console.WriteLine(FileManager.GetFileExtension("example.pdf"));
            Console.WriteLine(FileManager.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileManager.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileManager.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileManager.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", GeometryMath.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", GeometryMath.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Prismatoid.Width = 3;
            Prismatoid.Height = 4;
            Prismatoid.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", Prismatoid.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Prismatoid.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", Prismatoid.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", Prismatoid.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", Prismatoid.CalcDiagonalYZ());
        }
    }
}
