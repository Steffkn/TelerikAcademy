using System.Collections.Generic;

namespace _03.ObjectPoolPattern
{
    // The Pool class is the most important class in the object pool design pattern. It controls access to the
    // pooled objects, maintaining a list of available objects and a collection of objects that have already been
    // requested from the pool and are still in use. The pool also ensures that objects that have been released
    // are returned to a suitable state, ready for the next time they are requested. 
    public static class Pool
    {
        private static List<PooledObject> available = new List<PooledObject>();
        private static List<PooledObject> inUse = new List<PooledObject>();

        public static PooledObject GetObject()
        {
            lock (available)
            {
                if (available.Count != 0)
                {
                    PooledObject po = available[0];
                    inUse.Add(po);
                    available.RemoveAt(0);
                    return po;
                }
                else
                {
                    PooledObject po = new PooledObject();
                    inUse.Add(po);
                    return po;
                }
            }
        }

        public static void ReleaseObject(PooledObject po)
        {
            CleanUp(po);

            lock (available)
            {
                available.Add(po);
                inUse.Remove(po);
            }
        }

        private static void CleanUp(PooledObject po)
        {
            po.TempData = string.Empty;
        }
    }
}
