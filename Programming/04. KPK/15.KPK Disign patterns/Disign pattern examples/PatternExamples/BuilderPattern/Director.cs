/// <summary>
/// The 'Director' class
/// </summary>
public class Director
{
    /// <summary>
    /// Builder uses a complex series of steps
    /// </summary>
    /// <param name="builder">The builder that will make the object</param>
    public void Construct(Builder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}