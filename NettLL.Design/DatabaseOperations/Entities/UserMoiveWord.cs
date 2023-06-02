using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.Entities
{
    public partial class UserMoiveWord
    {
        public int id { get; set; }
        public string category { get; set; }
        public UserMoiveWord()
        {
            moiveWords = new HashSet<MoiveWord>();
        }
        public  virtual ICollection<MoiveWord> moiveWords { get; set; }
    }
}
