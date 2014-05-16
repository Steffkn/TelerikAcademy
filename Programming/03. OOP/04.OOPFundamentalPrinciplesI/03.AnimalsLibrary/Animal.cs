
public abstract class Animal : ISound
{
    private string name;
    private byte age;
    private bool isMale;

    public bool IsMale
    {
        get { return isMale; }
        set { isMale = value; }
    }

    public byte Age
    {
        get { return age; }
        set { age = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Animal(string name, byte age, bool isMale)
    {
        this.Name = name;
        this.Age = age;
        this.IsMale = isMale;
    }

    /// <summary>
    /// Method that finds the kind of the animal
    /// </summary>
    /// <returns>Returns the type of the animal (Dog Frog Kitten Tomcat (not Cat in general))</returns>
    public string AnimalKind()
    {
        return string.Format(GetType().Name);
    }

    /// <summary>
    /// Method that finds the avarage age of the array of animals
    /// </summary>
    /// <param name="animals">Array of animals</param>
    /// <returns>Returns the avarage age of the animals</returns>
    public static double Average(Animal[] animals)
    {
        double sum = 0;
        for (int i = 0; i < animals.Length; i++)
        {
            sum = sum + animals[i].Age;
        }
        return sum / animals.Length;
    }

    public abstract void Talk();
}
