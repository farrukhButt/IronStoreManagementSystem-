using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronStore
{
    enum ServerDBStatusCode
    {
        Added_From_Home=1,
        Added_From_Shop=2,
        Updated_From_Home=3,
        Updated_From_Shop = 4,
        Deleted_From_Home = 5,
        Deleted_From_Shop = 6,

        Updated_On_Both_Sides=8
    }
}
