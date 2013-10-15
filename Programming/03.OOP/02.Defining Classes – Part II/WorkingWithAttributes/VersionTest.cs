using System;
using System.Reflection;

[Version(1,0)]
class VersionsTest
{
    [Version(1,1)]
    private enum Options
    {
        Debug = 0,
        Release = 1,
        Beer = 2
    }

    [Version(3,8)]
    private static int BePositive()
    {
        return 1;
    }

    [Version(3,9)]
    private static void Voidling()
    {
    }

    [Version(3,93)]
    private static bool SoTrue()
    {
        return true;
    }

    [Version(11,0)]
    static void Main()
    {
       
        Type type = typeof(VersionsTest);

        object[] customAttributes = type.GetCustomAttributes(false);

        if( customAttributes.Length > 0 )
        {
            Console.WriteLine("This class version {0}", ( customAttributes[0] as VersionAttribute ).Version);
        }

        MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);

        foreach( MethodInfo method in methods )
        {
            object[] methodAttributes = method.GetCustomAttributes(false);

            if( methodAttributes.Length > 0 && methodAttributes[0] is VersionAttribute )
            {
                Console.WriteLine("Method \"{0}\" is version {1}",
                    method.Name,
                    ( methodAttributes[0] as VersionAttribute ).Version);
            }
        }

        Type enumType = type.GetNestedType("Settings", BindingFlags.NonPublic);

        object[] enumCustomAttributes = enumType.GetCustomAttributes(false);

        if( enumCustomAttributes.Length > 0 && enumCustomAttributes[0] is VersionAttribute )
        {
            Console.WriteLine("Nested type \"{0}\" has version {1}",
                enumType.Name,
                ( enumCustomAttributes[0] as VersionAttribute ).Version);
        }
    }
}