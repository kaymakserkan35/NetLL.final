namespace NettLL.Design
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.videoView1 = new LibVLCSharp.WinForms.VideoView();
            this.moiveContainer = new NettLL.Design.RecyclerView();
            this.wordSelectedContainer = new NettLL.Design.RecyclerView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.categoryContainer = new NettLL.Design.RecyclerView();
            this.wordContainer = new NettLL.Design.RecyclerView();
            this.wordForSearchInDB = new System.Windows.Forms.TextBox();
            this.containsALLDB = new System.Windows.Forms.Button();
            this.searchWordsInSelectedMoives = new System.Windows.Forms.Button();
            this.unknownListButton = new System.Windows.Forms.Button();
            this.littleKnownListButton = new System.Windows.Forms.Button();
            this.hardWordsButton = new System.Windows.Forms.Button();
            this.searchWordsInAllMoives = new System.Windows.Forms.Button();
            this.choseMoiveUrl = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.altyazıAnaliziYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kelimeListesiEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startswith = new System.Windows.Forms.Button();
            this.startSecondsBackToPlay = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sceneFolder = new System.Windows.Forms.Button();
            this.soundsFolder = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.playPauseButton = new System.Windows.Forms.Button();
            this.countOfSecond = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView, 3);
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(366, 62);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.MaximumSize = new System.Drawing.Size(800, 900);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView, 4);
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.Size = new System.Drawing.Size(490, 757);
            this.dataGridView.TabIndex = 8;
            // 
            // videoView1
            // 
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.videoView1, 3);
            this.videoView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoView1.Location = new System.Drawing.Point(862, 63);
            this.videoView1.MediaPlayer = null;
            this.videoView1.Name = "videoView1";
            this.tableLayoutPanel1.SetRowSpan(this.videoView1, 4);
            this.videoView1.Size = new System.Drawing.Size(906, 755);
            this.videoView1.TabIndex = 9;
            // 
            // moiveContainer
            // 
            this.moiveContainer.AutoScroll = true;
            this.moiveContainer.BackColor = System.Drawing.Color.DarkGray;
            this.moiveContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moiveContainer.Location = new System.Drawing.Point(23, 456);
            this.moiveContainer.Name = "moiveContainer";
            this.tableLayoutPanel1.SetRowSpan(this.moiveContainer, 2);
            this.moiveContainer.Size = new System.Drawing.Size(166, 362);
            this.moiveContainer.TabIndex = 11;
            // 
            // wordSelectedContainer
            // 
            this.wordSelectedContainer.AutoScroll = true;
            this.wordSelectedContainer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.wordSelectedContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wordSelectedContainer.Location = new System.Drawing.Point(195, 456);
            this.wordSelectedContainer.Name = "wordSelectedContainer";
            this.tableLayoutPanel1.SetRowSpan(this.wordSelectedContainer, 2);
            this.wordSelectedContainer.Size = new System.Drawing.Size(165, 362);
            this.wordSelectedContainer.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 23);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // categoryContainer
            // 
            this.categoryContainer.AutoScroll = true;
            this.categoryContainer.BackColor = System.Drawing.Color.DarkGray;
            this.categoryContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryContainer.Location = new System.Drawing.Point(23, 63);
            this.categoryContainer.Name = "categoryContainer";
            this.tableLayoutPanel1.SetRowSpan(this.categoryContainer, 2);
            this.categoryContainer.Size = new System.Drawing.Size(166, 387);
            this.categoryContainer.TabIndex = 14;
            // 
            // wordContainer
            // 
            this.wordContainer.AutoScroll = true;
            this.wordContainer.BackColor = System.Drawing.Color.DarkGray;
            this.wordContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wordContainer.Location = new System.Drawing.Point(0, 0);
            this.wordContainer.Name = "wordContainer";
            this.wordContainer.Size = new System.Drawing.Size(165, 358);
            this.wordContainer.TabIndex = 10;
            // 
            // wordForSearchInDB
            // 
            this.wordForSearchInDB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordForSearchInDB.Location = new System.Drawing.Point(366, 28);
            this.wordForSearchInDB.Name = "wordForSearchInDB";
            this.wordForSearchInDB.Size = new System.Drawing.Size(144, 23);
            this.wordForSearchInDB.TabIndex = 16;
            this.wordForSearchInDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // containsALLDB
            // 
            this.containsALLDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containsALLDB.Location = new System.Drawing.Point(516, 28);
            this.containsALLDB.Name = "containsALLDB";
            this.containsALLDB.Size = new System.Drawing.Size(156, 29);
            this.containsALLDB.TabIndex = 17;
            this.containsALLDB.Text = "contains";
            this.containsALLDB.UseVisualStyleBackColor = true;
            // 
            // searchWordsInSelectedMoives
            // 
            this.searchWordsInSelectedMoives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchWordsInSelectedMoives.Location = new System.Drawing.Point(23, 824);
            this.searchWordsInSelectedMoives.Name = "searchWordsInSelectedMoives";
            this.searchWordsInSelectedMoives.Size = new System.Drawing.Size(166, 38);
            this.searchWordsInSelectedMoives.TabIndex = 18;
            this.searchWordsInSelectedMoives.Text = "searchWordsInThisMoives";
            this.searchWordsInSelectedMoives.UseVisualStyleBackColor = true;
            // 
            // unknownListButton
            // 
            this.unknownListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.unknownListButton.Location = new System.Drawing.Point(381, 824);
            this.unknownListButton.Name = "unknownListButton";
            this.unknownListButton.Size = new System.Drawing.Size(114, 38);
            this.unknownListButton.TabIndex = 19;
            this.unknownListButton.Text = "unknownList";
            this.unknownListButton.UseVisualStyleBackColor = true;
            // 
            // littleKnownListButton
            // 
            this.littleKnownListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.littleKnownListButton.Location = new System.Drawing.Point(706, 824);
            this.littleKnownListButton.Name = "littleKnownListButton";
            this.littleKnownListButton.Size = new System.Drawing.Size(122, 38);
            this.littleKnownListButton.TabIndex = 20;
            this.littleKnownListButton.Text = "littleKnownList";
            this.littleKnownListButton.UseVisualStyleBackColor = true;
            // 
            // hardWordsButton
            // 
            this.hardWordsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.hardWordsButton.Location = new System.Drawing.Point(529, 824);
            this.hardWordsButton.Name = "hardWordsButton";
            this.hardWordsButton.Size = new System.Drawing.Size(130, 38);
            this.hardWordsButton.TabIndex = 21;
            this.hardWordsButton.Text = "hardWords";
            this.hardWordsButton.UseVisualStyleBackColor = true;
            // 
            // searchWordsInAllMoives
            // 
            this.searchWordsInAllMoives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchWordsInAllMoives.Location = new System.Drawing.Point(195, 824);
            this.searchWordsInAllMoives.Name = "searchWordsInAllMoives";
            this.searchWordsInAllMoives.Size = new System.Drawing.Size(165, 38);
            this.searchWordsInAllMoives.TabIndex = 22;
            this.searchWordsInAllMoives.Text = "searchWordsInAllMoives";
            this.searchWordsInAllMoives.UseVisualStyleBackColor = true;
            // 
            // choseMoiveUrl
            // 
            this.choseMoiveUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.choseMoiveUrl.Location = new System.Drawing.Point(862, 28);
            this.choseMoiveUrl.Name = "choseMoiveUrl";
            this.choseMoiveUrl.Size = new System.Drawing.Size(258, 29);
            this.choseMoiveUrl.TabIndex = 23;
            this.choseMoiveUrl.Text = "choseMoiveUrl";
            this.choseMoiveUrl.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altyazıAnaliziYapToolStripMenuItem,
            this.kelimeListesiEkleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1794, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // altyazıAnaliziYapToolStripMenuItem
            // 
            this.altyazıAnaliziYapToolStripMenuItem.Name = "altyazıAnaliziYapToolStripMenuItem";
            this.altyazıAnaliziYapToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.altyazıAnaliziYapToolStripMenuItem.Text = "altyazı analizi yap";
            // 
            // kelimeListesiEkleToolStripMenuItem
            // 
            this.kelimeListesiEkleToolStripMenuItem.Name = "kelimeListesiEkleToolStripMenuItem";
            this.kelimeListesiEkleToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.kelimeListesiEkleToolStripMenuItem.Text = "kelime listesi ekle";
            // 
            // startswith
            // 
            this.startswith.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startswith.Location = new System.Drawing.Point(678, 28);
            this.startswith.Name = "startswith";
            this.startswith.Size = new System.Drawing.Size(178, 29);
            this.startswith.TabIndex = 25;
            this.startswith.Text = "startsWith";
            this.startswith.UseVisualStyleBackColor = true;
            // 
            // startSecondsBackToPlay
            // 
            this.startSecondsBackToPlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.startSecondsBackToPlay.Location = new System.Drawing.Point(12, 9);
            this.startSecondsBackToPlay.Name = "startSecondsBackToPlay";
            this.startSecondsBackToPlay.Size = new System.Drawing.Size(57, 23);
            this.startSecondsBackToPlay.TabIndex = 26;
            this.startSecondsBackToPlay.Text = "3";
            this.startSecondsBackToPlay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.832273F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.771428F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.571428F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.253904F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.50828F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0771F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.73033F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.25689F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.littleKnownListButton, 5, 6);
            this.tableLayoutPanel1.Controls.Add(this.categoryContainer, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.hardWordsButton, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.startswith, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.videoView1, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.moiveContainer, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.wordSelectedContainer, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.sceneFolder, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.soundsFolder, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.choseMoiveUrl, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.unknownListButton, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.searchWordsInAllMoives, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.searchWordsInSelectedMoives, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.containsALLDB, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 7, 6);
            this.tableLayoutPanel1.Controls.Add(this.wordForSearchInDB, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.890173F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.046243F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.7052F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.72832F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.05202F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.45455F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1794, 887);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(195, 63);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.wordContainer);
            this.tableLayoutPanel1.SetRowSpan(this.splitContainer1, 2);
            this.splitContainer1.Size = new System.Drawing.Size(165, 387);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 29;
            // 
            // sceneFolder
            // 
            this.sceneFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sceneFolder.Location = new System.Drawing.Point(1524, 28);
            this.sceneFolder.Name = "sceneFolder";
            this.sceneFolder.Size = new System.Drawing.Size(244, 29);
            this.sceneFolder.TabIndex = 31;
            this.sceneFolder.Text = "sceneFolder";
            this.sceneFolder.UseVisualStyleBackColor = true;
            this.sceneFolder.Click += new System.EventHandler(this.sceneFolder_Click);
            // 
            // soundsFolder
            // 
            this.soundsFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soundsFolder.Location = new System.Drawing.Point(1126, 28);
            this.soundsFolder.Name = "soundsFolder";
            this.soundsFolder.Size = new System.Drawing.Size(392, 29);
            this.soundsFolder.TabIndex = 30;
            this.soundsFolder.Text = "soundFolder";
            this.soundsFolder.UseVisualStyleBackColor = true;
            this.soundsFolder.Click += new System.EventHandler(this.soundsFolder_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.startSecondsBackToPlay);
            this.panel2.Controls.Add(this.playPauseButton);
            this.panel2.Controls.Add(this.countOfSecond);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1126, 824);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 38);
            this.panel2.TabIndex = 34;
            // 
            // playPauseButton
            // 
            this.playPauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.playPauseButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.playPauseButton.FlatAppearance.BorderSize = 25;
            this.playPauseButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.playPauseButton.Location = new System.Drawing.Point(154, 3);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Size = new System.Drawing.Size(102, 38);
            this.playPauseButton.TabIndex = 33;
            this.playPauseButton.Text = "play-stop";
            this.playPauseButton.UseVisualStyleBackColor = true;
            this.playPauseButton.Click += new System.EventHandler(this.playPauseButton_Click);
            // 
            // countOfSecond
            // 
            this.countOfSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.countOfSecond.AutoSize = true;
            this.countOfSecond.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.countOfSecond.Location = new System.Drawing.Point(327, 4);
            this.countOfSecond.Name = "countOfSecond";
            this.countOfSecond.Size = new System.Drawing.Size(23, 28);
            this.countOfSecond.TabIndex = 35;
            this.countOfSecond.Text = "0";
            this.countOfSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1794, 911);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1700, 900);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
        private Button button20;
        private Button button21;
        private Button button22;
        private Button button23;
        private DataGridView dataGridView;
        private LibVLCSharp.WinForms.VideoView videoView1;
        private RecyclerView moiveContainer;
        private RecyclerView wordSelectedContainer;
        private TextBox textBox1;
        private RecyclerView categoryContainer;
        private RecyclerView wordContainer;
        private TextBox wordForSearchInDB;
        private Button containsALLDB;
        private Button searchWordsInSelectedMoives;
        private Button unknownListButton;
        private Button littleKnownListButton;
        private Button hardWordsButton;
        private Button searchWordsInAllMoives;
        private Button choseMoiveUrl;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem altyazıAnaliziYapToolStripMenuItem;
        private ToolStripMenuItem kelimeListesiEkleToolStripMenuItem;
        private Button startswith;
        private TextBox startSecondsBackToPlay;
        private TableLayoutPanel tableLayoutPanel1;
        private SplitContainer splitContainer1;
        private Button soundsFolder;
        private Button sceneFolder;
        private Button playPauseButton;
        private Panel panel2;
        private Label countOfSecond;
        private System.Windows.Forms.Timer timer1;
    }
}