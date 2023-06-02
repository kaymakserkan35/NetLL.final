using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.Entities.Extantions
{
    static class CategoriesExtensionMethods
    {


        public static Categories[] getAll(this Categories categories)
        {
            Array array = Enum.GetValues(typeof(Categories));
           return array.Cast<Categories>().ToArray();
        }

    }
    
}
