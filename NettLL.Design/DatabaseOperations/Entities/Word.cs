using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.Entities
{
    public partial class Word
    {

        public Word()
        {
            moivewords = new HashSet<MoiveWord>();
            wordcategories = new HashSet<WordCategory>();
            wordsounds = new HashSet<WordSound>();

        }


        public int id { get; set; }
        public string word { get; set; }

        public virtual ICollection<MoiveWord> moivewords { get; set; }
        public virtual ICollection<WordCategory> wordcategories { get; set; }
        public virtual ICollection<WordSound> wordsounds { get; set; }


    }
}
