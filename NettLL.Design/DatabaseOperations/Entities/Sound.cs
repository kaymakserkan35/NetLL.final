using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.Entities
{
    public partial class Sound
    {

        public Sound()
        {
            wordsounds = new HashSet<WordSound>();
        }
        public int id { get; set; }

        public string sound { get; set; }

        public virtual ICollection<WordSound> wordsounds { get; set; }
    }
}
