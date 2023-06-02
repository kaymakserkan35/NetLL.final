using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.Entities
{
    public partial class WordSound
    {
        public int id { get; set; }
        public int soundId { get; set; }
        public int wordId { get; set; }

        public virtual Sound sound { get; set; }
        public virtual Word word { get; set; }
    }
}
