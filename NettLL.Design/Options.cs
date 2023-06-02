using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design
{
   public static class Options
    {


        public static string rootDir = Directory.GetCurrentDirectory();
        public static string pythonFiles = Path.GetFullPath(Path.Combine(rootDir, @"..\..\..\..\pythonFiles"));
        public static string jsonData = Path.Combine(pythonFiles + @"\jsonData.txt");
        public static string SceneExtractor2 = Path.Combine(pythonFiles + @"\SceneExtractor2.py");
        public static string SoundExtractor = Path.Combine(pythonFiles + @"\SoundExtractor.py");

        static string subtitle = "videos";
        public static string pathFiles = Path.Combine(rootDir + @"\files");
        public static string pathSubtitles = Path.Combine(pathFiles + @"\"+subtitle);
        public static string pathVideos = null;
        public static string pathSounds = @"C:\Users\Asus\Desktop\scenes";
        public static string pathForScenes = @"C:\Users\Asus\Desktop\scenes";
        public static string pathDatabase = Path.Combine(pathFiles + @"\databaseDB.db");
        public static string pathWordData = Path.Combine(pathFiles + @"\worddata");
    }
}
