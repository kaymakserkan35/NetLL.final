using NettLL.Design.DatabaseOperations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.DataAccess
{
    public interface IWordOperations
    {
        public void createWord(Word word);
        public Word readWord(int id);
        public Word readWord(Expression<Func<Word, bool>> filter);
        public List<Word> readAllWords();
        public List<Word> readAllWords(Expression<Func<Word, bool>> filter = null);
        public void updateWord(Word word);
        public void deleteWordMoive(int id);
    }
}

