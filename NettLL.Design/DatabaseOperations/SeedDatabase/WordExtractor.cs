using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using NettLL.Design.DatabaseOperations.DataAccess;
using NettLL.Design.DatabaseOperations.DataAccess.DataManager;
using NettLL.Design.DatabaseOperations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.SeedDatabase
{
    internal class WordExtractor
    {
        ContextDB context = ContextDB.getSingleton();
        List<Word> wordList = new List<Word>();

        public WordExtractor()
        {
        }
        public List<Moive> extractwordsFromMoives(List<string> moiveUrls)
        {
            List<Moive> moives = new List<Moive>();

            foreach (var url in moiveUrls)
            {
                moives.Add(extractwordFromMoives(url));
            }
            Console.WriteLine(wordList.Count+" kelime bulundu!");
            return moives;
        }

        public Moive extractwordFromMoives(string moiveUrl)
        {


            string moiveName = getFileName(moiveUrl);
            string fileType = getFileType(moiveUrl);
            string moiveType = "mp4";

            string[] fileContent = File.ReadAllLines(moiveUrl);
            string[]? times = null;


            Moive? moive = context.Moive.AsTracking().FirstOrDefault(x => x.moive==moiveName);
            if(moive == null)
            {
                moive = new Moive()
                {
                    copyright = 1,
                    moive = moiveName,
                    url = Path.Combine(Options.pathVideos + @"\" + moiveName + "." + moiveType),
                    subtitleUrl = Path.Combine(Options.pathSubtitles + @"\" + moiveName + "." + fileType),
                    moivewords = new List<MoiveWord>()
                };

            }



            int index = 1;
            foreach (var line in fileContent)
            {
                if (line == index.ToString()) { index++; continue; }
                if (line == "") { continue; }
                if (line.Contains("-->"))
                {
                    times = line.Split("-->");
                    continue;
                }
                //Console.WriteLine(line);
                String[]? words = getWordsOfMovieLine(line);
                if (words == null) continue;

                /*
                if (moiveName.Contains("-"))
                {
                    string[] season_epidose = moiveName.Split("-");
                    moive.season = Convert.ToInt16(season_epidose[1]);
                    moive.epidose = Convert.ToInt16(season_epidose[2]);
                }
                */
                foreach (var word in words)
                {
                    MoiveWord moiveWord = new MoiveWord()
                    {
                        moive = moive,
                        line = line,
                        startTime = times[0],
                        endTime = times[1],

                    };

                    Word? w = null;
                    {

                        if (wordList.Count > 0)
                        {
                            w = wordList.FirstOrDefault(wrdL => wrdL.word == word.ToLower());
                        }
                        if (w == null)
                        {
                            w = context.Word.AsTracking().FirstOrDefault(w => w.word == word.ToLower());
                            if (w != null) { wordList.Add(w); }
                        }
                        if (w == null)
                        {
                            w = new Word() { word = word.ToLower() };
                            wordList.Add(w);
                        }

                    }
                    moiveWord.word = w;
                    moive.moivewords.Add(moiveWord);

                }
            }
            return moive;


        }
        string[]? getWordsOfMovieLine(String line)
        {
            line = Regex.Replace(line, "<.*?>", String.Empty);
            string strRegex = @"^.*([a-zA-Z]).*$";
            Regex myRegex = new Regex(strRegex, RegexOptions.Multiline);
            Match myMatch = myRegex.Match(line);
            if (!myMatch.Success) return null;
            {
                //Console.WriteLine(line);
                StringBuilder input = new StringBuilder(line);
                #region MyRegion
                input.Replace("0th", " ");
                input.Replace("1th", " ");
                input.Replace("2th", " ");
                input.Replace("3th", " ");
                input.Replace("4th", " ");
                input.Replace("5th", " ");
                input.Replace("6th", " ");
                input.Replace("7th", " ");
                input.Replace("8th", " ");
                input.Replace("9th", " ");
                input.Replace("“", " ");
                input.Replace("”", " ");
                input.Replace('é', ' ');
                input.Replace('!', ' ');
                input.Replace('!', ' ');
                input.Replace('>', ' ');
                input.Replace('"', ' ');
                input.Replace('<', ' ');
                input.Replace(@"'", " ");
                input.Replace('£', ' ');
                input.Replace('^', ' ');
                input.Replace('#', ' ');
                input.Replace('+', ' ');
                input.Replace('$', ' ');
                input.Replace('%', ' ');
                input.Replace('½', ' ');
                input.Replace('&', ' ');
                input.Replace('/', ' ');
                input.Replace('{', ' ');
                input.Replace('(', ' ');
                input.Replace('[', ' ');
                input.Replace(')', ' ');
                input.Replace(']', ' ');
                input.Replace('=', ' ');
                input.Replace('}', ' ');
                input.Replace('?', ' ');
                input.Replace('\u005c', ' '); // unicode kulllandım
                                              //  string literal:string backslash = @"\";
                                              //da kullanabilirsin.
                input.Replace('*', ' ');
                input.Replace('-', ' ');
                input.Replace('_', ' ');
                input.Replace('|', ' ');
                input.Replace('.', ' ');
                input.Replace(',', ' ');
                input.Replace(';', ' ');
                input.Replace(':', ' ');
                input.Replace('~', ' ');
                input.Replace(':', ' ');
                input.Replace(':', ' ');
                input.Replace(':', ' ');
                #endregion



                //input.Replace("'", " ");    
              
                line = input.ToString();
                line = line.ToLower();
            }
            //multiple spaces in a string with only one space
            //line = Regex.Replace(line, @"\s+", " ");
            string[] arr= line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> list = new List<string>(arr);
            foreach (var wrd in arr)
            {
                int o = 0;
                 bool tf =  int.TryParse(wrd, out o);
                if (tf) { list.Remove(wrd); }
                if (wrd.Length < 5) { list.Remove(wrd); }
            }
            return list.ToArray();
        }
        string[]? getWordsOfTextLine(String line)
        {
            
            string[]? retuningValue = null;
            line = Regex.Replace(line, "<.*?>", String.Empty);
           
            string strRegex = @"^.*([a-zA-Z]).*$";
            Regex myRegex = new Regex(strRegex, RegexOptions.Multiline);
            Match myMatch = myRegex.Match(line);
            if (!myMatch.Success) return null;
            {
                StringBuilder input = new StringBuilder(line);
                #region MyRegion
                
                #endregion

                line = input.ToString();
                line = line.ToLower();
                input.Replace("\t", " ");
                line = input.ToString();
            }
            
            if (line.Contains(".")&&line.Contains("="))
            {
                int from = line.IndexOf('.');
                int lineNumber = 0;
                if (!int.TryParse(line.Substring(0, from - 0), out lineNumber)) return null;
                //if() { }
                int to = line.IndexOf('=');
                if (retuningValue == null) retuningValue = new string[1];
                string word = line.Substring(from + 1, to - from - 1);
                word = word.Trim();
                retuningValue[0]=word;
                return retuningValue;
               ;
            }
            retuningValue= line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return retuningValue;
        }

        public  string getFileName(string url)
        {
            string[] urlSplitted = url.Split('\\');
            var uri = new Uri(url).OriginalString;
            string name = urlSplitted[urlSplitted.Length - 1];

            int from = url.LastIndexOf("\\");
            int to = url.LastIndexOf(".");
            return url.Substring(from + 1,to-from-1);
    
        }
        public string getFileType(string url)
        {
            int from = url.LastIndexOf(".");
            return url.Substring(from+1);

        }
        public List<WordCategory> extractWordsWithCategoriesFromTextFile(string textFile)
        {
           List<WordCategory> wordCategories= new List<WordCategory>();

            string categoryName = getFileName(textFile);
            string fileType = getFileType(textFile);

            string[] fileContent = File.ReadAllLines(textFile);

            Category? category;
            category = context.Category.AsTracking().FirstOrDefault(c => c.category == categoryName);
            if (category == null)
            {
                category = new Category() { category = categoryName };
            }
    
                foreach (var line in fileContent)
                {

                   string[]? wrds = getWordsOfTextLine(line);
                    if (wrds == null) continue;

                    for (int i = 0; i < wrds.Length; i++)
                    {
                        string word = wrds[i];
                    if (word == null || word == " ") continue;
                        Word? w = null;

                        if (wordList.Count > 0 && wordList.Any(wr => wr.word == word))
                        {
                            w = wordList.FirstOrDefault(wrdL => wrdL.word == word);

                        }
                        else
                        {

                            w = context.Word.AsTracking().FirstOrDefault(w => w.word == word);
                            if (w != null) { wordList.Add(w); }
                            else
                            {
                                w = new Word() { word = word };
                                wordList.Add(w);

                            }

                        }


                    if (w == null) continue;
                    wordCategories.Add(new WordCategory() { word=w,category=category});

                    }

                }

            return wordCategories;

        }

      


    }
}
