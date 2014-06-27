using System;

public class Size
{
    private double width = 0, height = 0;

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public Size(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public static Size GetRotatedSize(Size size, double angleToRotate)
    {
        double cosOfTheAngle = Math.Abs(Math.Cos(angleToRotate));
        double sinOfTheAngle = Math.Abs(Math.Sin(angleToRotate));
        double width = 0;
        double height = 0;

        width = cosOfTheAngle * size.Width + sinOfTheAngle * size.Height;
        height = sinOfTheAngle * size.Width + cosOfTheAngle * size.Height;

        Size newSize = new Size(width, height);
        return newSize;
    }
}