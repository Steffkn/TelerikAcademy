
using System;
using System.Collections.Generic;

public class School : ICollectionSchool<Class>
{
    private ICollectionSchool<Class> classes = new ICollectionSchool<Class>();
    private string name;

    internal ICollectionSchool<Class> Classes
    {
        get { return classes; }
        set { classes = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public School(string name)
    {
        this.Name = name;
    }
}

