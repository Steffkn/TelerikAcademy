using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space3D
{
    interface IPoint3D
    {
       
        // property to return the point's x,y,z.
        int PointX
        {
            get;
        }
         int PointY
        {
            get;
        }
         int PointZ
        {
            get;
        }
    }
}
