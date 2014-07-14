/// <summary>
/// The 'ConcreteBuilder2' class
/// </summary>
public class ConcreteBuilder2 : Builder
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
        this.product.Add("PartX");
    }

    /// <summary>
    /// Method to build part B
    /// </summary>
    public override void BuildPartB()
    {
        this.product.Add("PartY");
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