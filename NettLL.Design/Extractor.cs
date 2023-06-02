using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NettLL.Design
{
    internal class Extractor
    {
        private string lastMoiveSceneName;
        internal class Model
        {
           public string moiveName { get; set; }
            public string moiveType { get; set; }
            public string sceneName { get; set; }
            public string sceneUrl { get; set; }
            public string movUrl { get; set; }
            public string subtitleUrl { get; set; }
            public string startTime { get; set; }
            public string endTime { get; set; }
        }

        public string? getSubtitleUrl(string moive)
        {
            var moiveTypes = new List<string> { ".mp4", ".mkv", ".mov", ".MP4", ".ts", ".avi", ".m4v" };
            string[] moveFiles = Directory.GetFiles(Options.pathVideos, "*.*", SearchOption.AllDirectories)
                 .Where(f => moiveTypes.IndexOf(Path.GetExtension(f)) >= 0).ToArray();
            string? moiveUrl = null;
            string? subtitleUrl = null;
            foreach (string file in moveFiles)
            {
               
                string fileName = getFileName(file);
                if (fileName == moive)
                {
                    moiveUrl = file;
                    subtitleUrl = getRootDirOfFİle(file) + ".srt";
                    break;
                }
            }
            if (subtitleUrl != null) return subtitleUrl;
            else
            {
                MessageBox.Show("subtitle bulunamadı");
                return null;
            }

        }

        public string? getMoiveUrl(string moive)
        {
            var moiveTypes = new List<string> { ".mp4", ".mkv", ".mov", ".MP4", ".ts", ".avi", ".m4v" };
            string[] moveFiles = Directory.GetFiles(Options.pathVideos, "*.*", SearchOption.AllDirectories)
                 .Where(f => moiveTypes.IndexOf(Path.GetExtension(f)) >= 0).ToArray();
            string? moiveUrl = null;

            foreach (string file in moveFiles)
            {
                string fileName = getFileName(file);
                if (fileName == moive)
                {
                    moiveUrl = file;
                    break;
                }
            }
            if (moiveUrl != null) return moiveUrl;
            else
            {
                MessageBox.Show("flim bulunamadı");
                return null;
            }

        }
        public string getRootDirOfFİle(string url)
        {
            int to = url.LastIndexOf(".");
            return url.Substring(0, to);

        }
        public string getFileName(string url)
        {
            string[] urlSplitted = url.Split('\\');
            var uri = new Uri(url).OriginalString;
            string name = urlSplitted[urlSplitted.Length - 1];

            int from = url.LastIndexOf("\\");
            int to = url.LastIndexOf(".");
            return url.Substring(from + 1, to - from - 1);

        }
        public string getFileType(string url)
        {
            int from = url.LastIndexOf(".");
            return url.Substring(from + 1);

        }

        private string getStartedTimeInseconds(string starttime, int timesAgoOrAfter,bool isAgo)
        {
            string[] arr = starttime.Split(":");
            //string[] arrEnd = starttime.Split(":");
            int startHour = Convert.ToInt16(arr[0]);
            int startMinute = Convert.ToInt16(arr[1]);
            int startSeconds = Convert.ToInt16(arr[2].Split(",")[0]);
            int start = startHour * 3600 + startMinute * 60 + startSeconds;


            if (!isAgo) start = start + timesAgoOrAfter;
            else start = start - timesAgoOrAfter;

            

            TimeSpan _time = TimeSpan.FromSeconds(start);
            return _time.ToString();

        }

     
        private int getTimeDİff(string time1 , string time2)
        {
            string[] arr = time1.Split(":");
            //string[] arrEnd = starttime.Split(":");
            int startHour = Convert.ToInt16(arr[0]);
            int startMinute = Convert.ToInt16(arr[1]);
            int startSeconds = Convert.ToInt16(arr[2].Split(",")[0]);
            int start = startHour * 3600 + startMinute * 60 + startSeconds;


            string[] arr2 = time2.Split(":");
            //string[] arrEnd = starttime.Split(":");
            int endHour = Convert.ToInt16(arr2[0]);
            int endMinute = Convert.ToInt16(arr2[1]);
            int endSeconds = Convert.ToInt16(arr2[2].Split(",")[0]);
            int end = startHour * 3600 + endMinute * 60 + endSeconds;

            return end - start;
        }

        public bool extractScene2(Data data, int time1, int time2)
        {

            var subtitleUrl = "";
            string? _sub = getSubtitleUrl(data.moive);
            if(_sub!=null) subtitleUrl= _sub;
            var movUrl = getMoiveUrl(data.moive);
            if (movUrl == null) return false;
            string startTime = getStartedTimeInseconds(data.startTime, time1, true);
            string endTime = getStartedTimeInseconds(startTime, time2, false);
            
            string moiveName = data.moive;
            string moiveType = getFileType(data.moiveUrl);

            string sceneName = data.word + "_" + regulateSceneName(moiveName) + "_" + startTime.Replace(":", "_").Split(",")[0];
            if (this.lastMoiveSceneName == sceneName)
            {
                MessageBox.Show("already extracted or now extracting...");
                return false;
            }
            lastMoiveSceneName = sceneName;
            string sceneUrl = Options.pathForScenes;
            //var _movUrl = new Uri(movUrl);
            //var _subtitleUrl = new Uri(subtitleUrl);

            /*-------------------------------------------------*/
    
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = @"python.exe";
            //string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            //string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PythonSampleSystemDiagnostic.py");

            /**************************************************************************************/
            Model model = new Model()
            {
                moiveName=moiveName,
                movUrl= movUrl,
                moiveType =moiveType,
                sceneName=sceneName,
                sceneUrl= sceneUrl,
                subtitleUrl= subtitleUrl,
                startTime=startTime, endTime=endTime,
            };
            string modelSerilized = JsonSerializer.Serialize(model);
            string jsonDataPath = Options.jsonData;
            if (File.Exists(jsonDataPath)) File.Delete(jsonDataPath);
            using (FileStream fs = File.Create(jsonDataPath))
            {
                Byte[] title = new UTF8Encoding(true).GetBytes(modelSerilized);
                fs.Write(title, 0, title.Length);
                
            }
            jsonDataPath = new Uri(jsonDataPath).AbsolutePath;
            string extractorPath = Options.SceneExtractor2;
            
            //extractorPath = new Uri(extractorPath).AbsolutePath;
            start.Arguments = string.Format("{0} {1} ", extractorPath, String.Format(jsonDataPath));

            start.UseShellExecute = false;// Do not use OS shell
            start.CreateNoWindow = true; // We don't need new window
            start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
            start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)
            //C:\myFiles\softwareEngineering\projects\NetLL\NetLL.Form\NetLL.plain\NettLL.Design - final - 36.json.success\pythonFiles
            start.LoadUserProfile = true;
            using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {

                    string result = reader.ReadToEnd();// get print() ' ed strings....
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    if (stderr == "") { MessageBox.Show(stderr); return true; }
                    else { MessageBox.Show(stderr);
                           return false; 
                    }

                }
            }

        }
        public bool extractSound(Data data,int time1,int time2)
        {

            var movUrl = getMoiveUrl(data.moive);
            if (movUrl == null) return false;
            string startTime = getStartedTimeInseconds(data.startTime, time1, true);
            string endTime = getStartedTimeInseconds(startTime, time2, false);
            string moiveName = data.moive;
            string moiveType = getFileType(data.moiveUrl);
            string sceneName = data.word + "_" +  regulateSceneName( data.moive )+ "_" + startTime.Replace(":", "_").Split(",")[0];
            string sceneUrl = Options.pathSounds;
            var urii = new Uri(movUrl);


            Model model = new Model()
            {
                moiveName = moiveName,
                movUrl = movUrl,
                moiveType = moiveType,
                sceneName = sceneName,
                sceneUrl = sceneUrl,
                subtitleUrl = sceneUrl,
                startTime = startTime,
                endTime = endTime,
            };
            string modelSerilized = JsonSerializer.Serialize(model);

            /*-------------------------------------------------*/
           
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = @"python.exe";
            string extractorPath = Options.SoundExtractor;
            string jsonFilePath = Options.jsonData;
            if (File.Exists(jsonFilePath)) File.Delete(jsonFilePath);
            using (FileStream fs = File.Create(jsonFilePath))
            {
                Byte[] title = new UTF8Encoding(true).GetBytes(modelSerilized);
                fs.Write(title, 0, title.Length);

            }

            jsonFilePath = new Uri(jsonFilePath).AbsolutePath;
            start.Arguments = string.Format("{0} {1}", extractorPath, String.Format(jsonFilePath));

            start.UseShellExecute = false;// Do not use OS shell
            start.CreateNoWindow = true; // We don't need new window
            start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
            start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)
            start.LoadUserProfile = true;
            using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {

                    /**/
                    string result = reader.ReadToEnd();
                    /**/
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    if (stderr == "") { MessageBox.Show(result+"/n"+stderr+"/n"); return true; }
                    else {
                        MessageBox.Show(result + "/n" + stderr + "/n");
                        Console.WriteLine(stderr); return false; }

                }
            }


        }
        private string regulateSceneName(string sceneName)
        {
            StringBuilder input = new StringBuilder(sceneName);
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
            
            sceneName = input.ToString();
            sceneName = sceneName.Trim().ToLower();
            if (sceneName.Length>8)
            {
                sceneName = sceneName.Substring(0, 8);
            }
            return sceneName;
        }
        public bool extractSceneWithHand(Data data, int time1, int time2)
        {

            var subtitleUrl = "";
            string? _sub = getSubtitleUrl(data.moive);
            if (_sub != null) subtitleUrl = _sub;
            var movUrl = getMoiveUrl(data.moive);
            if (movUrl == null) return false;
            string startTime = getStartedTimeInseconds(data.startTime, time1, true);
            string endTime = getStartedTimeInseconds(startTime, time2, false);
            string moiveName = data.moive;
            string moiveType = getFileType(data.moiveUrl);

            string sceneName = data.word + "_" + regulateSceneName(moiveName) + "_" + startTime.Replace(":", "_").Split(",")[0];
            if (this.lastMoiveSceneName == sceneName)
            {
                MessageBox.Show("already extracted or now extracting...");
                return false;
            }
            lastMoiveSceneName = sceneName;
            string sceneUrl = Options.pathForScenes;
            Model model = new Model()
            {
                moiveName = moiveName,
                movUrl = movUrl,
                moiveType = moiveType,
                sceneName = sceneName,
                sceneUrl = sceneUrl,
                subtitleUrl = subtitleUrl,
                startTime = startTime,
                endTime = endTime,
            };
            string modelSerilized = JsonSerializer.Serialize(model);

            string path = Options.jsonData;
            if (File.Exists(path)) File.Delete(path);
            using (FileStream fs = File.Create(path))
            {
                Byte[] title = new UTF8Encoding(true).GetBytes(modelSerilized);
                fs.Write(title, 0, title.Length);

            }
            MessageBox.Show("python scriptini çalıştır.");
            return true;

        }

    }
}
