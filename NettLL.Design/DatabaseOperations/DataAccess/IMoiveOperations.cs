using NettLL.Design.DatabaseOperations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.DataAccess
{
    internal interface IMoiveOperations
    {

        public bool createMoive(Moive moive);
        public Moive readMoive(int id);
        public List<Moive> readAllMoives(string word, bool includeMoiveWords);
        public List<Moive> readAllMoives(List<string> words, bool includeMoiveWords = false);
        public List<Moive> readAllMoives();
        public List<Moive> readAllMoives(Expression<Func<Moive, bool>> filter = null);
        public List<Moive> readAllMoivesLive(Expression<Func<Moive, bool>> filter = null, Action<List< Moive>> action=null);
        public void updateMoive(Moive word);
        public void deleteWordMoive(int id);

    }
}
