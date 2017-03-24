/// <summary>
/// The 'ConcreteBuilder1' class
/// </summary>
public class ConcreteBuilder1 : Builder
{
    /// <summary>
    /// The product of the construction
    /// </summary>
    private Product product = new Product();

    /// <summary>
    /// Method to build part A
    /// </summary>
    public override void BuildPartA()
    {
        this.product.Add("PartA");
    }

    /// <summary>
    /// Method to build part B
    /// </summary>
    public override void BuildPartB()
    {
        this.product.Add("PartB");
    }

    /// <summary>
    /// Method that returns the result object
    /// </summary>
    /// <returns>The newly constructed object</returns>
    public override Product GetResult()
    {
        return this.product;
    }
}