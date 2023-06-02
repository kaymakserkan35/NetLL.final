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
    public partial class ViewItem : UserControl
    {
        ItemData data;
       public bool showItem = false;
        //public Button button;
        //public CheckBox checkBox;
        public ViewItem()
        {
            InitializeComponent();
            this.button1.Text = null;
            // this.button = button1;
            // this.checkBox = checkBox1;
        }

        private void ViewItem_Load(object sender, EventArgs e)
        {

            this.button1.Dock = DockStyle.Fill;
            //this.button1.Text = "button";
            this.checkBox1.Left = 10;
            //this.checkBox.Top = this.checkBox.Bottom;
           
            this.checkBox1.Text = null;
            this.checkBox1.Checked = false;
            this.checkBox1.Dock = DockStyle.Left;
            this.checkBox1.BackColor = Color.Transparent;
          
           
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.button1.Click += (s, e) => {
                this.checkBox1.Checked = (this.checkBox1.Checked) ? false : true;
            };
            this.button1.BringToFront();
        }
        public void setData(ItemData dt) { 
            showItem=false;
            this.button1.Text=dt.name;
            this.data= dt;
        }
        public ItemData getData() { return data; }
    }
}
