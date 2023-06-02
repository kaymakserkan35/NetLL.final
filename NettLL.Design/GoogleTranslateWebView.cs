using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NettLL.Design
{
    public partial class GoogleTranslateWebView : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
       
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
     
        static GoogleTranslateWebView instance;
        WebBrowser web;
        public bool isShowing  = false;

        public static GoogleTranslateWebView getSingleton()
        {
            if (instance == null) instance = new GoogleTranslateWebView();
            return instance;
        }
        public GoogleTranslateWebView()
        {
            InitializeComponent();
            this.button1.Text = "HİDE";
            web = new WebBrowser();
            this.splitContainer1.Panel2.Controls.Add(web);
            //this.Controls.Add(web);
            web.Dock = DockStyle.Fill;
            web.BringToFront();
            this.CancelButton= new Button();
         

        }

        public void navigate (string word)
        {
            string _url = $"https://translate.google.com/?hl=tr&sl=en&tl=tr&text={word}&op=translate";
            web.Navigate(_url) ;
            web.BringToFront();
            this.Show();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
