using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Devices;
using NettLL.Design.DatabaseOperations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.DataAccess.DataManager
{
    internal class DataManager : IMoiveOperations, IWordOperations,ICategoryOperations
    {
        ContextDB context;
        public DataManager()
        {
            context=ContextDB.getSingleton();
        }


        #region CleaerDatabase
        public void clearAllDataabase()
        {
            
            context.WordCategory.ExecuteDelete();
            context.MoiveWord.ExecuteDelete();
            context.Moive.ExecuteDelete();
            context.Word.ExecuteDelete();
            context.Category.ExecuteDelete();
        }
        public void clearWordCategories()
        {
            context.Word.ExecuteDelete();
            context.WordCategory.ExecuteDelete();
            context.Category.ExecuteDelete();
        }
        #endregion
        #region Cruds

        public void createMoiveWord(MoiveWord moiveWord)
        {
            context.MoiveWord.Add(moiveWord);
            context.SaveChanges();
        }

       
        public bool createMoive(Moive moive)
        {
            throw new NotImplementedException();
        }

        public bool anyMoive(Func<Moive,bool> filter)
        {
            return context.Moive.Any(filter);
        }
        public bool anyCategory(Func<Category, bool> filter)
        {
            return context.Category.Any(filter);
        }

        public Moive readMoive(int id)
        {
            throw new NotImplementedException();
        }

        public List<Moive> readAllMoives()
        {
            return context.Moive.AsNoTracking().ToList();
        }

        public List<Moive> readAllMoives(Expression<Func<Moive, bool>> filter = null)
        {
            return context.Moive.AsNoTracking().Where(filter).ToList();
        }


        public List<Moive> readAllMoives(string word, bool includeMoiveWords)
        {
            //Word wordObj = context.Word.FirstOrDefault(w => w.word == word);

            List<Moive> moives;
            if (includeMoiveWords)
            {
                moives = context.
                Moive.AsNoTracking().
                Where(m => m.moivewords.Any(mw => mw.word.word == word)).
                Include(m => m.moivewords.Where(mw => mw.word.word == word)).
                ToList();

            }
            else
            {
                moives = context.
                               Moive.AsNoTracking().
                               Where(m => m.moivewords.Any(mw => mw.word.word == word)).
                               ToList();
            }
            return moives;

        }
        

        public List<Moive> readAllMoivesLive(Expression<Func<Moive, bool>> filter = null, Action<List<Moive>> action = null)
        {
            List<Moive> moives = context.Moive.AsNoTracking().Where(filter).AsTracking().ToList();
            if (action != null)
            {
                action.Invoke(moives);
            }
            return moives;
        }

        public void updateMoive(Moive word)
        {
            throw new NotImplementedException();
        }

        public void deleteWordMoive(int id)
        {
            throw new NotImplementedException();
        }

        public void createWord(Word word)
        {
            context.Word.Add(word);
            context.SaveChanges();
        }


        public List<Word> readAllWords(Expression<Func<Word, bool>> filter = null)
        {
            return context.Word.AsNoTracking().Where(filter).ToList();
        }

        public void updateWord(Word word)
        {
            throw new NotImplementedException();
        }

        public Word readWord(int id)
        {
            throw new NotImplementedException();
        }

        public List<Word> readAllWords()
        {

            return context.Word.ToList();
        }

        public bool createCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Category readCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> readAllCategories()
        {
            return context.Category.AsNoTracking().ToList();
        }

        public List<Category> readAllCategories(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void updateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void deleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<Moive> readAllMoives(List<string> words, bool includeMoiveWords = false)
        {
            List<Moive> moives;
            if (!includeMoiveWords)
            {
                moives = context.Moive.AsNoTracking().
                Where(m => m.moivewords.Any(mw => words.Any(w => w == mw.word.word))).
                ToList();

            }
            else
            {
                moives = context.Moive.AsNoTracking().
                Where(m => m.moivewords.Any(mw => words.Any(w => w == mw.word.word))).
                Include(m => m.moivewords.Where(mw => words.Any(w => w == mw.word.word))).
                ThenInclude(m => m.word).
                ToList();

            }
            return moives;


        }

        public List<Moive> readAllMoives(List<string> moiveList, List<string> wordList, bool includeMoiveWords = false)
        {
            List<Moive> moives;
            if (!includeMoiveWords)
            {
                moives = context.Moive.AsNoTracking().
                Where(m => m.moivewords.Any(mw => moiveList.Any(m => m == mw.moive.moive))).
                Where(m => m.moivewords.Any(mw => wordList.Any(w => w == mw.word.word))).
                ToList();

            }
            else
            {
                moives = context.Moive.AsNoTracking().
                Where(m => m.moivewords.Any(mw => moiveList.Any(m => m == mw.moive.moive))).
                Where(m => m.moivewords.Any(mw => wordList.Any(w => w == mw.word.word))).
                Include(m => m.moivewords.Where(mw => wordList.Any(w => w == mw.word.word))).
                ThenInclude(mw=>mw.word).
                ToList();

            }
            return moives;

        }

        public Word? readWord(Expression<Func<Word, bool>> filter)
        {
            return context.Word.AsNoTracking().FirstOrDefault(filter);
        }
        #endregion

        public MoiveWord readMoiveWord(Expression<Func<MoiveWord,bool>> filter=null,bool track=false) {
            MoiveWord? mw;
            if (track)
            {
                mw = context.MoiveWord.AsTracking().FirstOrDefault(filter);
            }
            else
            {
                mw = context.MoiveWord.AsNoTracking().FirstOrDefault(filter);
            }
            return mw;
         
        }

        public MoiveWord readMoiveWord(int id, bool track = false)
        {
            MoiveWord? mw;
            if (track)
            {
                mw = context.MoiveWord.Find(id);
            }
            else
            {
                mw = context.MoiveWord.Find(id);
            }
            return mw;

        }
        public void createOrUpdateMoiveWordOfUserMoiveWord(int moiveWordId,string? userCategory)
        {
            MoiveWord? mw = context.MoiveWord.Find(moiveWordId);
            if (userCategory == null)
            {
                mw.usermoiveword = null;
            }
            else
            {
                UserMoiveWord? umw = context.UserMoiveWord.FirstOrDefault(x => x.category == userCategory);
                if (umw == null)
                {
                    umw = new UserMoiveWord() { category = userCategory };
                    mw.usermoiveword = umw;
                    context.UserMoiveWord.Add(umw);
                }
                mw.usermoiveword = umw;
            }
          
            context.SaveChanges();
          
            
        }

        public void createUserMoiveWord(UserMoiveWord userMoiveWord) {

            context.UserMoiveWord.Add(userMoiveWord);
            context.SaveChanges();
        }
        public UserMoiveWord readUserMoiveWordWithMoiveWords(Expression<Func<UserMoiveWord, bool>> filter = null) {
            UserMoiveWord? r = null;
            if (filter!=null)
            {
                r=  context.UserMoiveWord.Where(filter)
                    .Include(x=>x.moiveWords).
                    ThenInclude(x=>x.word).
                    Include(x=>x.moiveWords).
                    ThenInclude(x=>x.moive).FirstOrDefault(filter);
             
            }
            else
            {
                r = context.UserMoiveWord.Include(x => x.moiveWords).
                    ThenInclude(x => x.word).
                    Include(x => x.moiveWords).
                    ThenInclude(x => x.moive).FirstOrDefault();
               
            }

            return r;

        }
       
        
        public UserMoiveWord? readUserMoiveWord( string categry  ) {

            return context.UserMoiveWord.FirstOrDefault(x => x.category == categry);
        }
        
        public void removeMoiveWordOfUserMoşveWord(UserMoiveWord userMoiveWord)
        {
            context.SaveChanges();
        }


        public string? readWordOfUserMoiveWord( MoiveWord moiveWord )
        {
            string? r = null;
            UserMoiveWord? umw = context.MoiveWord.AsNoTracking().FirstOrDefault(mw=>mw.id==moiveWord.id).usermoiveword;
            if (umw != null) r = umw.category;
            return r;
           // return context.MoiveWord.FirstOrDefault(mw => mw == moiveWord).usermoiveword.category;
        }

        public List<Word> searchWordInAllDatabase(string wordPiece)
        {
            return   context.Word.AsNoTracking().Where(w => w.word.Contains(wordPiece)).Include(w => w.moivewords).ThenInclude(m=>m.moive).ToList();
        }

        public List<MoiveWord> searchWordInAllDatabase2(string wordPiece)
        {
            List<Word> wrds = context.Word.FromSqlRaw($"SELECT * FROM word WHERE word LIKE '%{wordPiece.Trim()}%'").ToList();
            return readAllMoivesByIds(wrds.Select(w => w.id).ToList(), true);

        }
        public void updateMoivesUrlAndSubtitlesUrl(string url)
        {
            url=  url.Replace("\\", "/");
            context.Moive.AsTracking().ToList().ForEach(m=> {

                m.url = url+"/"+m.moive+".mp4";
                m.subtitleUrl= url+"/"+ m.moive + ".srt";
            });
            context.SaveChanges();
            
        }

        #region saveMoviesToDatabase

        public void createMoiveWithWords(Moive moive)
        {


            bool isMoiveAlreadyExist = context.Moive.Any( (m) => m.moive == moive.moive );
            if (isMoiveAlreadyExist)
            {
                return;
            }

            
            {
                List<MoiveWord> mwList = new List<MoiveWord>();
                foreach (var mw in moive.moivewords)
                {
                    mwList.Add(mw);
                }
                context.MoiveWord.AddRange(mwList);
                context.SaveChanges();
            }
         
            
         

        }
        public void createmoivesWithWords(List<Moive> moives)
        {
            List<MoiveWord> mwList = new List<MoiveWord>();

            foreach (var moive in moives)
            {
                bool isMoiveAlreadyExist = context.Moive.Any((m) => m.moive == moive.moive);
                if (isMoiveAlreadyExist) continue;

                foreach (var mw in moive.moivewords)
                {
                    mwList.Add(mw);
                }

            }

            {
               
                context.MoiveWord.AddRange(mwList);
                context.SaveChanges();
            }

        }
        public void createWordsWithCategories(List<WordCategory> wordCategories)
        {
            wordCategories.ForEach(wc => {

                if (wc.word==null)
                {
                    Console.Write("");
                }
            });
            context.WordCategory.AddRange(wordCategories);
            context.SaveChanges();
        }
        #endregion
        public List<MoiveWord> readMoiveWordContainsThis(string word)
        {
            return context.MoiveWord.AsNoTracking().Where(mw => mw.word.word.Contains(word)).
                 Include(mw => mw.word).
                 Include(mw => mw.moive).
                 Include(mw => mw.usermoiveword).ToList();
        }
        public List<MoiveWord>  readMoiveWordStarsWİth(string word)
        {
           return context.MoiveWord.AsNoTracking().Where(mw=>mw.word.word.StartsWith(word)).
                Include(mw => mw.word).
                Include(mw => mw.moive).
                Include(mw=>mw.usermoiveword).ToList();
        }


        #region FastQueryById

        public List<MoiveWord> readAllMoivesByIds(List<int> words)
        {
           
          return  context.MoiveWord.AsNoTracking().Where(mw=>words.Any(id=>id==mw.id)).Include(mw=>mw.word).Include(mw=>mw.moive).ToList();

        }

        public List<MoiveWord> readAllMoiveByIds(List<int> moiveList, List<int> words, bool includeUserCategory = false)
        {
            if (includeUserCategory)
            {
                return
                context.MoiveWord.AsNoTracking().
                Where(mw => words.Any(id => id == mw.word.id)).
                Where(mw => moiveList.Any(id => id == mw.moive.id)).
                Include(mw => mw.word).
                Include(mw => mw.moive).
                Include(mw=>mw.usermoiveword).ToList();
            }
            else
            {
                return
               context.MoiveWord.AsNoTracking().
               Where(mw => words.Any(id => id == mw.word.id)).
               Where(mw => moiveList.Any(id => id == mw.moive.id)).
               Include(mw => mw.word).
               Include(mw => mw.moive).
               ToList();
            }
            

        }
        public List<MoiveWord> readAllMoivesByIds(List<int> selectedWords,bool includeUserCategory=false)
        {
            if (!includeUserCategory)
            {
                return context.MoiveWord.AsNoTracking().Where(mw => selectedWords.Any(id => id == mw.wordId)).
                                   Include(mw => mw.word).
                                    Include(mw => mw.moive)
                                    .ToList();
            }
            else
            {
                return context.MoiveWord.AsNoTracking().Where(mw => selectedWords.Any(id => id == mw.wordId)).
                    Include(mw => mw.word).
                    Include(mw => mw.moive).
                    Include(x => x.usermoiveword).
                    ToList();

            }
            
        }
        
        
        #endregion
    }
}
