// (C) Copyright 2015 by Andrew Nicholas (andrewnicholas@iinet.net.au)
//
// This file is part of SCaddins.
//
// SCaddins is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// SCaddins is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with SCaddins.  If not, see <http://www.gnu.org/licenses/>.

namespace SCaddins
{
    using System;
    using System.Collections.Specialized;
    using System.Windows.Forms;
    using Autodesk.Revit.UI;
    
    public partial class SCaddinsOptionsForm : Form
    {
        public SCaddinsOptionsForm(RibbonPanel ribbonPanel)
        {           
            this.InitializeComponent();
            this.checkBox1.Checked = SCaddins.Scaddins.Default.UpgradeCheckOnStartUp;
            foreach (var item in SCaddins.Scaddins.Default.ApplicationLayout) {
                this.listBox1.Items.Add(item);     
            }
        }
                                  
        private void ButtonOKClick(object sender, EventArgs e)
        {
            SCaddins.Scaddins.Default.UpgradeCheckOnStartUp = checkBox1.Checked;
            SCaddins.Scaddins.Default.Save();
        }
     
        private void ButtonResetClick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in SCaddins.SCaddinsApp.DefaultApplicationLayout) {
                this.listBox1.Items.Add(item);     
            }
        }
        
        private void ButtonRemoveClick(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index != -1) {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                if (index >= listBox1.Items.Count) {
                    listBox1.SelectedIndex = index - 1;
                } else {
                    listBox1.SelectedIndex = index;
                }
            }
            
        }
        
        private void ButtonUpClick(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index > 0) {
                string current = listBox1.Text;
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Insert(index - 1, current);
                listBox1.SelectedIndex = index - 1;
            }
        }
        
        private void ButtonDownClick(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index != -1 && index < listBox1.Items.Count - 1) {
                string current = listBox1.Text;
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Insert(index + 1, current);
                listBox1.SelectedIndex = index + 1;
            }
          
        }
        
        

    }
}
