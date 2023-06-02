using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.Entities
{
    public partial class  Category
    {

        public Category()
        {
            wordcategories = new HashSet<WordCategory>();
        }

        public int id { get; set; }
        public string category { get; set; }

        public virtual ICollection<WordCategory> wordcategories { get; set; }
    }
}
