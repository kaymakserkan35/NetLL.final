using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.Devices;
using NettLL.Design.DatabaseOperations.DataAccess.DataManager;
using NettLL.Design.DatabaseOperations.Entities;
using NettLL.Design.DatabaseOperations.Entities.Extantions;
using NettLL.Design.DatabaseOperations.SeedDatabase;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq.Expressions;
using System.Windows.Forms;
using Xamarin.Forms.Internals;
using static System.Windows.Forms.CheckedListBox;

namespace NettLL.Design
{
    public partial class FormMain : Form
    {
        bool asc_for_words = true;
        bool asc_for_moives = true;
        int _sayac { get; set; } = 0;
        int sayac { get { return _sayac; }
            set { 
                _sayac = value;
                this.countOfSecond.Text=value.ToString();
            }
        }
        Extractor extractor = new Extractor();
        VideoPlayer videoPlayer;
        DataManager dataManager= new DataManager();
        List<Data> datas = new List<Data>();
        Action<string> getUserMoiveWordsAction;
        Action< bool > getMoiveWordsAction;

        public FormMain()
        {
           
            InitializeComponent();
            designigCodes();
            dataGridView.AllowUserToOrderColumns = true;
            this.categoryContainer.Controls.Clear();
            this.moiveContainer.Controls.Clear();
            this.wordContainer.Controls.Clear();
            this.wordSelectedContainer.Controls.Clear();
            videoPlayer=new VideoPlayer(videoView1);
           
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            designigCodes();
            
            List<ItemData> dataCategoryList = new List<ItemData>();
            dataManager.readAllCategories().ForEach(c => {
                dataCategoryList.Add(new ItemData() { id=c.id, name=c.category });
            });
            this.categoryContainer.addViewItems(dataCategoryList);
            List<ItemData> moiveList = new List<ItemData>();
            dataManager.readAllMoives().ForEach(mv => {
                moiveList.Add(new ItemData() { id=mv.id,name=mv.moive });

            });
            this.moiveContainer.addViewItems(moiveList); 
          
            this.categoryContainer.itemChecked += (item) =>
            {
                List<ItemData> list = new List<ItemData>();
                dataManager.readAllWords(w => w.wordcategories.Any(wc => wc.category.id == item.getData().id)).ForEach(x => {
                    list.Add(new ItemData() { id =x.id,name=x.word});
                });
                categoryContainer.unCheckAllItemsButThis(item);
                wordContainer.addViewItems(list);
                wordSelectedContainer.unCheckAllItemsButThis(null);
            };
            this.moiveContainer.itemClick += (item) => {   };
            this.wordContainer.itemChecked += (item) => { 
                wordSelectedContainer.addViewItem(item);
            };
            this.wordContainer.itemUnChecked += (item) => {
                wordSelectedContainer.removeViewItem(item);
                wordContainer.addViewItem(item);
            };

            this.wordSelectedContainer.itemUnChecked += (item) => { wordContainer.unCheckItem(item); wordSelectedContainer.removeViewItem(item); };
           
            

            this.textBox1.TextChanged += (sender, e) => {

                wordContainer.search(textBox1.Text);
            
            };

            getMoiveWordsAction += (searcInAllMoives) => {
                datas = new List<Data>();
                List<ItemData> selectedWords = wordSelectedContainer.getSelectedItems();
                List<MoiveWord> moives = new List<MoiveWord>();
                if (!searcInAllMoives) {
                    List<ItemData> selectedMoives = moiveContainer.getSelectedItems();
                    moives = dataManager.readAllMoiveByIds(selectedMoives.Select(x=>x.id).ToList(), selectedWords.Select(x=>x.id).ToList(), true); }
                else
                {
                    moives = dataManager.readAllMoivesByIds(selectedWords.Select(x=>x.id).ToList(),true);
                }
                Console.Write("");
                    moives.ForEach(mw =>
                    {
                        Data data = new Data()
                        {
                            
                            moiveWordId = mw.id,
                            moive = mw.moive.moive,
                            moiveUrl = mw.moive.url,
                            soundUrl = "",
                            sound = mw.moive.moive,
                            word = mw.word.word,
                            startTime = mw.startTime,
                            endTime = mw.endTime,
                            subtitleUrl = mw.moive.subtitleUrl,
                            line = mw.line
                        };


                        if (mw.usermoiveword != null) data.userCategory = mw.usermoiveword.category;
                       datas.Add(data);
                    });

                Data.createColumns(dataGridView);
                Data.createRows(dataGridView, datas);
                Console.WriteLine(datas.Count+" kadar flim frame i getirildi!");
            };

            getUserMoiveWordsAction += (catergry) => {
                datas = new List<Data>();
                UserMoiveWord userMoiveWord = dataManager.readUserMoiveWordWithMoiveWords(x => x.category == catergry);
                if (userMoiveWord == null)
                {
                    MessageBox.Show("didnt find any!"); return;
                }
                userMoiveWord.moiveWords.ForEach(mw => {
                    datas.Add(new Data()
                    {
                        moiveWordId=mw.id,
                        userCategory= userMoiveWord.category,
                        moive = mw.moive.moive,
                        moiveUrl = mw.moive.url,
                        soundUrl = "",
                        sound = mw.moive.moive,
                        word = mw.word.word,
                        startTime = mw.startTime,
                        endTime = mw.endTime,
                        subtitleUrl = mw.moive.subtitleUrl,
                        line = mw.line

                    }); ;

                });
                Data.createColumns(dataGridView);
                Data.createRows(dataGridView, datas);
            };
          

        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            dataGridView.CellContentClick += (sender, e) => {
                Data data = null;
                var col = dataGridView.Columns[e.ColumnIndex];
                if (e.RowIndex >= 0)
                {
                    var row = dataGridView.Rows[e.RowIndex];
                    data = datas.FirstOrDefault(d => d.moiveWordId == int.Parse(row.Tag.ToString()));
                }
                if ( (e.RowIndex < 0 || e.RowIndex > datas.Count - 1))
                {
                    if (col.HeaderText == "word")
                    {
                        if (this.asc_for_words) { 
                            dataGridView.Sort(col, ListSortDirection.Descending); asc_for_words = false;
                          
                        }
                        else { 

                            dataGridView.Sort(col, ListSortDirection.Ascending); asc_for_words = true;
                         
                        }
                    }
                    else if (col.HeaderText == "moive")
                    {
                        if (this.asc_for_moives) { 
                            dataGridView.Sort(col, ListSortDirection.Descending); asc_for_moives = false;
                           
                        }
                        else { 
                            dataGridView.Sort(col, ListSortDirection.Ascending); asc_for_moives = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                   
                }
                else if (col.HeaderText == "word")
                {
                    //MessageBox.Show(data.word);
                    GoogleTranslateWebView.getSingleton().navigate(data.word);
                }
                else if (col.HeaderText == "moive")
                {
                    if (Options.pathVideos == null) { MessageBox.Show("lüfen flimlerinizin bulunduğu klosörü seçiniz"); }
                    int starTİme;
                    bool tf =int.TryParse(startSecondsBackToPlay.Text,out starTİme); if (!tf) { MessageBox.Show("lütfen nümeric..."); return; }
                    this.sayac = 0;
                    countOfSecond.Text=sayac.ToString();
                    if (videoPlayer.PlayMain(data, starTİme, int.Parse(countOfSecond.Text))) {
                        timer1.Start();
                        playPauseButton.Text = "Pause";
                    } else { MessageBox.Show("Oynatma başarısız"); }
                    Console.WriteLine(data.word + ":" + data.line);
                }
                else if (col.HeaderText == "sound")
                {
                }
                else if (col.HeaderText == "Add")
                {
                    var  _clmn = dataGridView.Columns[e.ColumnIndex];
                    var _addButonCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    var comboboxCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1];
                    if (comboboxCell.Value == null)
                    { MessageBox.Show("category seçiniz", "!CATEGORY!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    string? categr = comboboxCell.Value.ToString();
                    /*--------------------------------------------------------------*/
                    if (categr == Categories.empty.ToString())
                    {
                        dataManager.createOrUpdateMoiveWordOfUserMoiveWord(data.moiveWordId, null);
                    }
                    /*------------------------------------------------------------------*/
                    else
                    {
                        dataManager.createOrUpdateMoiveWordOfUserMoiveWord(data.moiveWordId, categr);
                    }
                 
                   
                    
                }
 
                else if (col.HeaderText== "ExtractScene")
                {
                    if (Options.pathForScenes == null || Options.pathVideos == null)
                    {
                        MessageBox.Show("lütfen klasör seçimlerini yapınız");
                        return;
                    }
                    Thread thread = new Thread(() =>
                    {
                        int starTİme;
                        bool tf = int.TryParse(startSecondsBackToPlay.Text, out starTİme); if (!tf) { MessageBox.Show("lütfen nümeric..."); return; }
                        extractor.extractSceneWithHand(data, starTİme, int.Parse(countOfSecond.Text));
                    });
                  thread.Start();
                  
                }
                else if (col.HeaderText == "ExtractSound")
                {
                    if (Options.pathSounds == null || Options.pathVideos == null)
                    {
                        MessageBox.Show("lütfen klasör seçimlerini yapınız");
                        return;
                    }
                    int starTİme;
                    bool tf = int.TryParse(startSecondsBackToPlay.Text, out starTİme); if (!tf) { MessageBox.Show("lütfen nümeric..."); return; }
                   

                    extractor.extractSound(data, starTİme, int.Parse(countOfSecond.Text));
                }


            };


            unknownListButton.Click += (sender, e) => { getUserMoiveWordsAction.Invoke(Categories.unKnowWords.ToString()); };
            littleKnownListButton.Click += (sender, e) => { getUserMoiveWordsAction.Invoke(Categories.littleKnownWords.ToString()); };
            hardWordsButton.Click += (sender, e) => { getUserMoiveWordsAction.Invoke(Categories.hardWords.ToString()); };

            this.searchWordsInSelectedMoives.Click += (s, e) => { getMoiveWordsAction.Invoke(false); };
            this.searchWordsInAllMoives.Click += (s, e) => { getMoiveWordsAction(true); };


            this.containsALLDB.Click += (s, e) => {
                if (wordForSearchInDB.Text.Trim().Length < 3) { MessageBox.Show("en az üç karakter giriniz!"); return; }
                string w = wordForSearchInDB.Text;
                datas.Clear();
                List<MoiveWord> words = dataManager.searchWordInAllDatabase2(w);
              
                    foreach (var mw in words)
                    {
                        Data data = new Data()
                        {
                            moiveWordId = mw.id,
                            moive = mw.moive.moive,
                            moiveUrl = mw.moive.url,
                            soundUrl = "",
                            sound = mw.moive.moive,
                            word = mw.word.word,
                            startTime = mw.startTime,
                            endTime = mw.endTime,
                            subtitleUrl = mw.moive.subtitleUrl,
                            line = mw.line

                        };
                        //if (mw.usermoiveword != null) data.userCategory = mw.usermoiveword.category;
                        datas.Add(data);
                    }
                   
                

                Data.createColumns(dataGridView); Data.createRows(dataGridView, datas);
            };

            this.startswith.Click += (s, e) => {
                if (wordForSearchInDB.Text.Trim().Length < 3) { MessageBox.Show("en az üç karakter giriniz!"); return; }
               string w = wordForSearchInDB.Text;     
                datas.Clear();
                List<MoiveWord> words = dataManager.readMoiveWordStarsWİth(w);
                foreach (var mw in words)
                {
                    Data data = new Data()
                    {
                        moiveWordId = mw.id,
                        moive = mw.moive.moive,
                        moiveUrl = mw.moive.url,
                        soundUrl = "",
                        sound = mw.moive.moive,
                        word = mw.word.word,
                        startTime = mw.startTime,
                        endTime = mw.endTime,
                        subtitleUrl = mw.moive.subtitleUrl,
                        line = mw.line

                    };
                    if(mw.usermoiveword!=null) data.userCategory=mw.usermoiveword.category;
                    datas.Add(data);
                }

                Data.createColumns(dataGridView); Data.createRows(dataGridView, datas);
            };

            choseMoiveUrl.Click += (s, e) => { 
           
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                folderBrowser.Description = "flim listenizin bulunduğu klosörü seçiniz";
                folderBrowser.ShowDialog();
                if (folderBrowser.SelectedPath == "") return;
                string selectedPath = folderBrowser.SelectedPath;
                videoPlayer.pathForSearch = selectedPath;
                Options.pathVideos = selectedPath;
                //selectedPath.Replace("\\", "/");
                //dataManager.updateMoivesUrlAndSubtitlesUrl(selectedPath);

            };


            altyazıAnaliziYapToolStripMenuItem.Click += (s, e) => {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                folderBrowser.Description = "flim listenizin bulunduğu klosörü seçiniz";
                folderBrowser.ShowDialog();
                if (folderBrowser.SelectedPath == "") return;
                string selectedPath = folderBrowser.SelectedPath;
                Options.pathSubtitles = selectedPath;
                DatabaseOperations.SeedDatabase.BackgroundWorker backgroundWorker = new DatabaseOperations.SeedDatabase.BackgroundWorker();
                backgroundWorker.saveWordsWithMoivesToDatabase();

                List<ItemData> moiveList = new List<ItemData>();
                dataManager.readAllMoives().ForEach(mv => {
                    moiveList.Add(new ItemData() { id = mv.id, name = mv.moive });

                });
                this.moiveContainer.addViewItems(moiveList);

            };
            kelimeListesiEkleToolStripMenuItem.Click += (s, e) => {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                folderBrowser.Description = "kelime listenizin bulunduğu klosörü seçiniz";
                folderBrowser.ShowDialog();
                if (folderBrowser.SelectedPath == "") return;
                string selectedPath = folderBrowser.SelectedPath;
                Options.pathWordData= selectedPath;
                DatabaseOperations.SeedDatabase.BackgroundWorker backgroundWorker = new DatabaseOperations.SeedDatabase.BackgroundWorker();
                backgroundWorker.saveWordsWithCategoriesToDataBase();
                List<ItemData> dataCategoryList = new List<ItemData>();
                dataManager.readAllCategories().ForEach(c => {
                    dataCategoryList.Add(new ItemData() { id = c.id, name = c.category });
                });
                this.categoryContainer.addViewItems(dataCategoryList);
            };

        }


        private void designigCodes() {

            this.dataGridView.AutoSize = true;
        
        }

        private void sceneFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "kelime listenizin bulunduğu klosörü seçiniz";
            folderBrowser.ShowDialog();
            if (folderBrowser.SelectedPath == "") return;
            string selectedPath = folderBrowser.SelectedPath;
            Options.pathForScenes = selectedPath;
        }

        private void soundsFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "kelime listenizin bulunduğu klosörü seçiniz";
            folderBrowser.ShowDialog();
            if (folderBrowser.SelectedPath == "") return;
            string selectedPath = folderBrowser.SelectedPath;
            Options.pathSounds = selectedPath;
        }

        private void playPauseButton_Click(object sender, EventArgs e)
        {
           bool tf = this.videoPlayer.tooglePlayingAndReturnCurrentState();
            if (tf)
            {
                playPauseButton.Text = "Pause";
                this.timer1.Start();
            }
            else
            {
                playPauseButton.Text = "Play";
                this.timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.sayac = this.sayac + 1;
        }
    }
}