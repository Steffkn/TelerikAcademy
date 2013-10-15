using System;

[AttributeUsage(AttributeTargets.Struct |
AttributeTargets.Class |
AttributeTargets.Interface |
AttributeTargets.Enum |
AttributeTargets.Method)]

public sealed class VersionAttribute : Attribute
{
    private int majorVersion;
    private int minorVersion;

    public string Version
    {
        get { return string.Format("{0},{1}", majorVersion, minorVersion); }
    }

    public VersionAttribute(int Major , int Minor)
    {
        this.majorVersion = Major;
        this.minorVersion = Minor;
    }
}