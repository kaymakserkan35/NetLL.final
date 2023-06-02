using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.Entities
{
    public partial class WordCategory
    {
        public int id { get; set; }
        public int wordId { get; set; }
        public int categoryId { get; set; }


        public virtual Word word { get; set; }
        public virtual Category category { get; set; }
    }
}
