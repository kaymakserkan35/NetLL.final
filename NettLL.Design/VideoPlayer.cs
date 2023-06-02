using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NettLL.Design
{
    internal class VideoPlayer
    {
      
        private System.Windows.Forms.OpenFileDialog openFileDialog;

        Dictionary<string, Media> mediaDic = new Dictionary<string, Media>();
        public string? pathForSearch = null;
        MediaPlayer mediaPlayer;
        LibVLCSharp.WinForms.VideoView videoView1;
        LibVLCSharp.Shared.LibVLC libVLC;
        public VideoPlayer(LibVLCSharp.WinForms.VideoView videoView1)
        {
            this.videoView1 = videoView1;
            //string loc = typeof(LibVLC).Assembly.Location;
            //Console.WriteLine(loc);
            libVLC = new LibVLCSharp.Shared.LibVLC();
            videoView1.MediaPlayer = new LibVLCSharp.Shared.MediaPlayer(libVLC);
            mediaPlayer = videoView1.MediaPlayer;

        }
        public string getRootDirOfFİle(string url)
        {
            //string[] urlSplitted = url.Split('\\');
            //var uri = new Uri(url).OriginalString;
            //string name = urlSplitted[urlSplitted.Length - 1];

            //int from = url.LastIndexOf("\\");
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
        public bool PlayMain(Data data,int strt,int end)
        {

            if (Play(data,strt,end)) return true ;
            if (pathForSearch == null) return false;
            
            var moiveTypes = new List<string> { ".mp4", ".mkv" ,".mov", ".MP4",".ts",".avi" ,".m4v"};
            string[] moveFiles = Directory.GetFiles(this.pathForSearch, "*.*", SearchOption.AllDirectories)
                 .Where(f => moiveTypes.IndexOf(Path.GetExtension(f)) >= 0).ToArray();
          

            string subtitleUrl = null;
            string moiveUrl = null;

            foreach ( string file in moveFiles) {

                string fileName = getFileName(file);
                if (fileName == data.moive) {
                    subtitleUrl = getRootDirOfFİle(file) + ".srt";
                    moiveUrl = file; 
                    break; 
                }


                }
           
            if(moiveUrl!= null)
            {
                data.moiveUrl=moiveUrl;
                if (subtitleUrl != null) { data.subtitleUrl = subtitleUrl; }

                if(  Play2(data, strt, end) ) return true ;
                else return false ;

            }
            else
            {
                MessageBox.Show("flim bulunamadı");
                return false;
            }




        }
        private bool Play2(Data data, int strt, int endd)
        {


            Media media = null;
            string url = data.moiveUrl;
            string absUri = url.Replace("\\", "/");
            /*
            if (mediaDic.Any(m=>m.Key== (data.moive + data.startTime)))
            {
                media = mediaDic.FirstOrDefault(m=>m.Key==url).Value;
            }
            */
            if (media == null)
            {
                media = new Media(libVLC, absUri, FromType.FromPath);
                media.AddOption(new MediaConfiguration()
                {

                    EnableHardwareDecoding = true,
                    FileCaching = 30000,
                    NetworkCaching = 25000

                });
                if (!mediaDic.Any(k => k.Key == data.moive + data.startTime))
                {
                    mediaDic.Add(data.moive + data.startTime, media);
                }

            }


            string[] arr = data.startTime.Split(":");
            string[] arrEnd = data.endTime.Split(":");
            int startHour = Convert.ToInt16(arr[0]);
            int startMinute = Convert.ToInt16(arr[1]);
            int startSeconds = Convert.ToInt16(arr[2].Split(",")[0]);
            int start = startHour * 3600 + startMinute * 60 + startSeconds;


            int end;

            start = start - strt;
            end = start + endd;

            media.AddOption($"start-time={start}");
            //media.AddOption($"stop-time={end}");
            //media.AddOption("--sub-file=" + data.subtitleUrl);

            string subtitleUrl = data.subtitleUrl.Replace("\\", "/");
            bool result = media.AddSlave(MediaSlaveType.Subtitle, 4, new Uri(subtitleUrl));
            if (result) Console.WriteLine("subtitle attached");


            mediaPlayer.Media = media;
            bool tf = mediaPlayer.Play();
            return tf;

        }
        private bool Play(Data data,int startThisTimesAgo,int continiueForThisSeconds) {


            Media media = null;
            string url = data.moiveUrl;
            string absUri = url.Replace("\\", "/");
            /*
            if (mediaDic.Any(m=>m.Key== (data.moive + data.startTime)))
            {
                media = mediaDic.FirstOrDefault(m=>m.Key==url).Value;
            }
            */
            if (media == null)
            {
                media = new Media(libVLC, absUri, FromType.FromPath);
                media.AddOption(new MediaConfiguration()
                {

                    EnableHardwareDecoding = true,
                    FileCaching = 30000,
                    NetworkCaching = 25000

                });
                if (!mediaDic.Any(k => k.Key == data.moive + data.startTime))
                {
                    mediaDic.Add(data.moive + data.startTime, media);
                }

            }


            string[] arr = data.startTime.Split(":");
            string[] arrEnd = data.endTime.Split(":");
            int startHour = Convert.ToInt16(arr[0]);
            int startMinute = Convert.ToInt16(arr[1]);
            int startSeconds = Convert.ToInt16(arr[2].Split(",")[0]);
            int start = startHour * 3600 + startMinute * 60 + startSeconds;

            int end;
            start = start - startThisTimesAgo;
            end = start + continiueForThisSeconds;

            media.AddOption($"start-time={start}");
            //media.AddOption($"stop-time={end}");
           // media.AddOption("--sub-file=" + data.subtitleUrl);

            string subtitleUrl = data.subtitleUrl.Replace("\\", "/");
            bool result = media.AddSlave(MediaSlaveType.Subtitle, 4, new Uri(subtitleUrl));
            if (result) Console.WriteLine("subtitle attached");


            mediaPlayer.Media = media;
             mediaPlayer.Play();
            bool tf = mediaPlayer.IsPlaying;
            return tf;
            
        }

        public bool tooglePlayingAndReturnCurrentState()
        {
           // bool tf = false;
            if (mediaPlayer.IsPlaying)
            {
                mediaPlayer.Pause();
                return false;
            }
            else
            {
                mediaPlayer.Play();
                return true;
            }
        } 
    }
          
           
           
        
    
}
