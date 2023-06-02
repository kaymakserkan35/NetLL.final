using NettLL.Design.DatabaseOperations.DataAccess.DataManager;
using NettLL.Design.DatabaseOperations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.SeedDatabase
{
    internal class BackgroundWorker
    {
        WordExtractor wordExtractor = new WordExtractor();
        DataManager dataManager = new DataManager();
        
        public BackgroundWorker()
        {
            
        }

        public string[] getDirectories() {
  
            string[] folders = System.IO.Directory.GetDirectories(Options.pathSubtitles, "*", System.IO.SearchOption.AllDirectories);
            return folders;
        }

        public string[] getSubtitleFiles()
        {
           
           string path = Options.pathSubtitles;
            return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
          // return  Directory.GetFiles(path);
        }
        public string[] getWordDataFiles() {
            string path = Options.pathWordData;
            return Directory.GetFiles(path);
        }

        public void saveWordsWithCategoriesToDataBase()
        {
            List<WordCategory> wordCategories = new List<WordCategory>();
            string[] dirs = getWordDataFiles();

           
            for (int i = 0; i < dirs.Length; i++)
            {
                    string _url = dirs[i];
                    string fileType = wordExtractor.getFileType(_url);
                    if (fileType != "txt") continue;
                    if (dataManager.anyCategory(m => m.category ==wordExtractor.getFileName(_url))) continue;

                      wordCategories.AddRange(wordExtractor.extractWordsWithCategoriesFromTextFile(_url));
            }
 
            dataManager.createWordsWithCategories(wordCategories);

        }
        public void saveWordsWithMoivesToDatabase()
        {
            string[] dirs = getSubtitleFiles();
                List<string> urlList = new List<string>();
                for (int i = 0; i < dirs.Length; i++)
                {
                    string url = dirs[i];
                     string fileType =   wordExtractor.getFileType(url);
                    if (fileType != "srt") continue;
                    if (dataManager.anyMoive(m => m.moive == wordExtractor.getFileName(url))){
                        continue;
                    }
                
                    urlList.Add(url);
                }

            
            List< Moive > m = wordExtractor.extractwordsFromMoives(urlList);
            dataManager.createmoivesWithWords(m);

        }
        public void saveWordsWithMoivesToDatabase2()
        {
            string[] dirs = getSubtitleFiles();
          
            for (int i = 0; i < dirs.Length; i++)
            {
                string url = dirs[i];
                string fileType = wordExtractor.getFileType(url);
                if (fileType != "srt") continue;
                if (dataManager.anyMoive(m => m.moive == wordExtractor.getFileName(url)))
                {
                    continue;
                }

                Moive mov = wordExtractor.extractwordFromMoives(url);
                dataManager.createMoiveWithWords(mov);
                System.Threading.Thread.Sleep(500);
            }


          

        }

    }
}
