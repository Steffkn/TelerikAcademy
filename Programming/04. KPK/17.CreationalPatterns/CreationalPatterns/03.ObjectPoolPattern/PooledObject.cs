using System;

namespace _03.ObjectPoolPattern
{
    // The PooledObject class is the type that is expensive or slow to instantiate,
    // or that has limited availability, so is to be held in the object pool.
    public class PooledObject
    {
        DateTime createdAt = DateTime.Now;

        public DateTime CreatedAt
        {
            get { return createdAt; }
        }

        public string TempData { get; set; }

        public override string ToString()
        {
            return string.Format("Created at: {0}, data: {1}", CreatedAt, TempData);
        }
    }
}
