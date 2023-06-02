using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design
{
    public class RecyclerView:FlowLayoutPanel
    {
        public delegate void myDelegate (ViewItem item);
        public event myDelegate itemClick;
        public event myDelegate itemUnChecked,itemChecked;
        List<ViewItem> items = new List<ViewItem>();
      
        protected override void OnCreateControl()
        {
          

            base.OnCreateControl();
            this.AutoSize = false;
            this.AutoScroll = true;
            this.FlowDirection = FlowDirection.LeftToRight;
            this.HorizontalScroll.Enabled = true;
            this.VerticalScroll.Enabled = true;
            this.VScroll = false;
            this.HScroll = true;
            this.WrapContents = true;
        }

        public void addViewItems(List<ItemData> strings)
        {
           // setAllItemsOffToDisplay();
            //words = strings;
            if (items.Count < strings.Count)
            {
                int dif = (strings.Count - items.Count);
                for (int x = 0; x < dif; x++)
                {
                    ViewItem myViewItem = new ViewItem();
                    //myViewItem.setData(strings[x]);
                    myViewItem.checkBox1.Checked = false;
                    myViewItem.Width=     (int) ((double) this.Width*0.89);
                    myViewItem.Anchor = AnchorStyles.Left;
                    setEvents(myViewItem);
                    items.Add(myViewItem);
                }
            }
            refreshVİews(strings);
            
            //var _items = items.Where(it => it.showItem).ToArray();
            //this.Controls.AddRange(_items);
        }
        public void addViewItems(List<ItemData> strings,bool isSelected=false)
        {
           
            if (items.Count < strings.Count)
            {
                int dif = (strings.Count - items.Count);
                for (int x = 0; x < dif + 1; x++)
                {
                    ViewItem myViewItem = new ViewItem();
                    //myViewItem.setData(strings[x]);
                    myViewItem.checkBox1.Checked = isSelected;
                    myViewItem.Width = (int)((double)this.Width * 0.89);
                    myViewItem.Anchor = AnchorStyles.Left;
                    setEvents(myViewItem);
                    items.Add(myViewItem);
                }
            }
            refreshVİews(strings);
          
        }


        private void sortDatas()
        {
            List<ItemData> dataList = items.Select(i=>i.getData()).ToList();
            dataList.Sort((it1, it2) =>
            {
                return it1.name.CompareTo(it2.name);
            });
            for (int i = 0; i < items.Count; i++)
            {
                items[i].setData(dataList[i]);
                items[i].button1.Text = dataList[i].name;
            }
        }

        private void sortItems()
        {
            items.Sort((it1, it2) =>
            {
                return it1.getData().name.CompareTo(it2.getData().name);
            });
        }
        public void addViewItem(ViewItem item) {

            items.Add(item);
            this.Controls.Add(item);
            sortDatas();
           
           
        }
        public void removeViewItem(ViewItem item)
        {
            var _item = this.items.FirstOrDefault(i => i.getData() == item.getData());
            _item.checkBox1.Checked = false;
            this.items.Remove(_item);
            this.Controls.Remove(_item);
           
           //_item.getData().previousData.nextData = _item.getData().nextData;
            //_item.getData().nextData.previousData= _item. getData().previousData;
        }
        public void removeViewItem(string itemText)
        {
            var _item = this.items.FirstOrDefault(i => i.button1.Text == itemText);
            // _item.checkBox1.Checked = false;
            this.items.Remove(_item);
            this.Controls.Remove(_item);
           

           // _item.getData().previousData.nextData = _item.getData().nextData;
           // _item.getData().nextData.previousData = _item.getData().previousData;
        }


        public void unCheckItem(ViewItem item)
        {

            //var _item = this.items.FirstOrDefault(i => i.getData().name == item.getData().name);
            item.checkBox1.Checked = false;
            //words.Remove(item.getText());
       
        }
        //public void clearWords() { this.words.Clear(); }
        public List<ItemData> getSelectedItems()
        {
            List<ItemData> selecteItems = items.Where(i=>i.checkBox1.Checked).Select(i=>i.getData()).ToList();
            return selecteItems;
        }

        public List<string> getWordWithSearch(string text)
        {
            return items.Where(i => i.button1.Text.Contains(text)).Select(i => i.button1.Text).ToList();
        }
        public void search(string text)
        {
            if (text == "")
            {
               // this.addViewItems(items);
            }
            this.Controls.Clear();
            this.Controls.AddRange(items.Where(it=>it.getData().name.ToLower().Contains(text.ToLower())).ToArray());
        }

        private void setEvents(ViewItem myViewItem)
        {
            myViewItem.checkBox1.CheckedChanged += (s, e) => {
                if (itemClick != null) itemClick.Invoke(myViewItem);
                if (myViewItem.checkBox1.Checked)
                {
                    if (itemChecked != null) itemChecked.Invoke(myViewItem);
                }
                else
                {
                    if (itemUnChecked != null) itemUnChecked.Invoke(myViewItem);
                }

            };
        }
        private void setAllItemsOffToDisplay()
        {
            
            foreach (var item in items)
            {
                item.showItem = false;
            }
            this.Controls.Clear();
        }
        public void unCheckAllItemsButThis(ViewItem? myViewItem)
        {
            if (myViewItem == null)
            {

                for (int i = 0; i < items.Count; i++)
                {
                    unCheckItem(items[i]);
                }
            }

            else
            {
                foreach (var item in items)
                {
                    if (!item.Equals(myViewItem)) unCheckItem(item);

                }
            }
           
        }



        private void refreshVİews(List<ItemData> strings)
        {
          
            this.Controls.Clear();
            for (int i = 0; i < strings.Count; i++)
            {
                items[i].setData(strings[i]);

                if (i !=0 && i!=strings.Count-1) {
                   // items[i].getData().nextData = strings[i + 1];
                   // items[i].getData().previousData= strings[i - 1];
                }
               

                
                items[i].button1.Text = items[i].getData().name;
                items[i].showItem = true;

            }

            // items[0].getData().previousData = strings[strings.Count - 1];
            // items[strings.Count - 1].getData().nextData = strings[0];

            sortItems();
            var _itemsForDisplay = items.Where(i => i.showItem).ToList();
            this.Controls.AddRange(_itemsForDisplay.ToArray());
            /*
               var _itemsForDisplay = items.Where(i => i.showItem).ToList();

            if (_itemsForDisplay.Count <= strings.Count)
            {
                _itemsForDisplay = items.GetRange(_itemsForDisplay.Count, strings.Count - _itemsForDisplay.Count);
                _itemsForDisplay.ForEach(i => { i.showItem = true; });
                this.Controls.AddRange(_itemsForDisplay.ToArray());
               
               
            }
           else if (_itemsForDisplay.Count > strings.Count)
            {
                
                this.Controls.Clear();
                this.Controls.AddRange(items.GetRange(strings.Count, _itemsForDisplay.Count - strings.Count).ToArray());
                
                /* tek tek cıkarması nı daha uzun bir sürede yapıyor */
            /*
            for (int i = strings.Count; i <_itemsForDisplay.Count; i++)
            {
                this.Controls.Remove(items[i]);
            }  
             */

        }
             
             
          

        
    }
}
