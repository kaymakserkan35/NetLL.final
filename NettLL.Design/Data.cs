using NettLL.Design.DatabaseOperations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NettLL.Design
{
    internal class Data
    {
       
        public int moiveWordId { get; set; }
        public string moive { get; set; }
        public string word { get; set; }
        public string  sound { get; set; }
        public string moiveUrl { get; set; }
        public string soundUrl { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string subtitleUrl { get; set; }
        public string line { get; set; }    
        public string? userCategory { get; set; }


        static public void createRows(DataGridView dataGridView,List<Data> datas)
        {
            /*
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
            dataGridViewTextBoxCell.Value = "hola";
            */
            foreach (var data in datas)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();


                dataGridViewRow.Tag = data.moiveWordId;
                

                DataGridViewTextBoxCell wordCell = new DataGridViewTextBoxCell();
                wordCell.Value = data.word;
                DataGridViewButtonCell moiveCell = new DataGridViewButtonCell();
                moiveCell.Value = data.moive;
                DataGridViewButtonCell soundCell = new DataGridViewButtonCell();
                soundCell.Value = data.sound;

                DataGridViewComboBoxCell comboBoxCell= new DataGridViewComboBoxCell();
                comboBoxCell.Items.AddRange(
                Categories.empty.ToString(),
                Categories.unKnowWords.ToString(),
                Categories.littleKnownWords.ToString(),
                Categories.hardWords.ToString()
                );

                /*
                DataGridViewTextBoxCell miveUrl = new DataGridViewTextBoxCell();
                miveUrl.Value = data.moiveUrl;
                */

                dataGridViewRow.Cells.Add(wordCell);
                dataGridViewRow.Cells.Add(moiveCell);
                dataGridViewRow.Cells.Add(soundCell);           
                dataGridViewRow.Cells.Add(comboBoxCell);
                //
                //dataGridViewRow.Cells.Add(miveUrl);

                if (data.userCategory != null) { 
                    comboBoxCell.Value = data.userCategory;
                   // dataGridViewRow.Cells[4].Value = data.userCategory;
                }
                dataGridView.Rows.Add(dataGridViewRow);

               
            }
            

        }

        static public void createColumns(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();
            /*
            DataGridViewTextBoxCell moiveCell = new DataGridViewTextBoxCell();
            DataGridViewColumn column = new DataGridViewColumn(moiveCell);
            dataGridView.Columns.Add(column);
            */

            DataGridViewTextBoxCell wordCell = new DataGridViewTextBoxCell(); 
            DataGridViewColumn wordColumn = new DataGridViewColumn(wordCell);
            // internal set set edilemiyor. dişarridan...
            //wordColumn.State = DataGridViewElementStates.ReadOnly;
            wordColumn.Visible = true; wordColumn.Name= "Word";
            wordColumn.HeaderText = "word";
            wordColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns.Add(wordColumn);


            DataGridViewButtonCell moiveCell = new DataGridViewButtonCell();
            DataGridViewColumn moiveColumn = new DataGridViewColumn(moiveCell);
            moiveColumn.Visible = true;
            moiveColumn.HeaderText = "moive"; 
            moiveColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //moiveColumn.Width = 50;

            dataGridView.Columns.Add(moiveColumn);


            DataGridViewButtonCell soundCell = new DataGridViewButtonCell();
            DataGridViewColumn soundColumn = new DataGridViewColumn(soundCell);
            soundColumn.Visible = false;
            soundColumn.HeaderText = "sound";
            soundColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns.Add(soundColumn);




            DataGridViewComboBoxCell userCategoryCell = new DataGridViewComboBoxCell();
            
            userCategoryCell.Items.AddRange(Categories.empty.ToString(),
                Categories.unKnowWords.ToString(),
                Categories.littleKnownWords.ToString(), 
                Categories.hardWords.ToString());
            DataGridViewColumn userCategoryColumn = new DataGridViewColumn(userCategoryCell);
            userCategoryColumn.Name = "userCategory";
            userCategoryColumn.Visible = true;
            userCategoryColumn.HeaderText = "Category";
            userCategoryColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            dataGridView.Columns.Add(userCategoryColumn);


            DataGridViewButtonCell addMyListButtonCell = new DataGridViewButtonCell();
            DataGridViewColumn addMyListButtonColumn = new DataGridViewColumn(addMyListButtonCell);
            addMyListButtonCell.Value = "+";
            addMyListButtonColumn.Visible = true;
            
            addMyListButtonColumn.HeaderText = "Add";
            addMyListButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns.Add(addMyListButtonColumn);
            addMyListButtonColumn.Width= 50;


            DataGridViewButtonCell extractSceneCell = new DataGridViewButtonCell();
            DataGridViewColumn extractSceneColumn = new DataGridViewColumn(extractSceneCell);
            extractSceneCell.Value = "+";
            extractSceneColumn.Visible = true;

            extractSceneColumn.HeaderText = "ExtractScene";
            //extractSceneColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns.Add(extractSceneColumn);
            extractSceneColumn.Width = 50;


            DataGridViewButtonCell extractSoundCell = new DataGridViewButtonCell();
            DataGridViewColumn extractSoundColumn = new DataGridViewColumn(extractSoundCell);
            extractSoundCell.Value = "+";
            extractSoundColumn.Visible = true;

            extractSoundColumn.HeaderText = "ExtractSound";
            //extractSoundColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns.Add(extractSoundColumn);
            extractSoundColumn.Width = 50;

            /*
            DataGridViewTextBoxCell moiveUrl = new DataGridViewTextBoxCell();
            DataGridViewColumn moiveUrlColumn = new DataGridViewColumn(moiveUrl);
            // internal set set edilemiyor. dişarridan...
            //wordColumn.State = DataGridViewElementStates.ReadOnly;
            moiveUrlColumn.Visible = true; moiveUrlColumn.Name = "moiveUrl";
            moiveUrlColumn.HeaderText = "moiveUrl";
            moiveUrlColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns.Add(moiveUrlColumn);
            */

        }

    }

    
}
