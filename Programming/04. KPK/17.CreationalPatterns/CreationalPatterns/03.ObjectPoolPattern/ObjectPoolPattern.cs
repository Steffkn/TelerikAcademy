using System.Threading;
namespace _03.ObjectPoolPattern
{
    public class ObjectPoolPattern
    {
        static void Main()
        {
            var pooledObject = Pool.GetObject();
            pooledObject.TempData = "More dataaa";
            System.Console.WriteLine(pooledObject.ToString());

            // release the object by deactivating it and removes the data in it - Pool.CleanUp is called
            Pool.ReleaseObject(pooledObject);
            Thread.Sleep(3);

            var newPooledObject = Pool.GetObject();
            newPooledObject.TempData = "Simple question";
            System.Console.WriteLine(pooledObject.ToString());

        }
    }
}
