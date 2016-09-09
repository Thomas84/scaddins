﻿// (C) Copyright 2014 by Andrew Nicholas (andrewnicholas@iinet.net.au)
//
// This file is part of SCexport.
//
// SCexport is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// SCexport is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with SCexport.  If not, see <http://www.gnu.org/licenses/>.

namespace SCaddins.ExportManager
{
    public partial class RenameSheetForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameSheetForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.TestRunButton = new System.Windows.Forms.Button();
            this.RenameButton = new System.Windows.Forms.Button();
            this.CancelRenameButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNameReplace = new System.Windows.Forms.TextBox();
            this.textBoxNamePattern = new System.Windows.Forms.TextBox();
            this.Match = new System.Windows.Forms.Label();
            this.textBoxNumberReplace = new System.Windows.Forms.TextBox();
            this.textBoxNumberPattern = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(607, 325);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Existing Number";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Existing Name";
            this.columnHeader2.Width = 168;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "New Number";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "New Name";
            this.columnHeader4.Width = 125;
            // 
            // TestRunButton
            // 
            this.TestRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TestRunButton.Location = new System.Drawing.Point(12, 468);
            this.TestRunButton.Name = "TestRunButton";
            this.TestRunButton.Size = new System.Drawing.Size(75, 23);
            this.TestRunButton.TabIndex = 3;
            this.TestRunButton.Text = "Test Run";
            this.TestRunButton.UseVisualStyleBackColor = true;
            this.TestRunButton.Click += new System.EventHandler(this.TestRunButtonClick);
            // 
            // RenameButton
            // 
            this.RenameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RenameButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.RenameButton.Location = new System.Drawing.Point(544, 468);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(75, 23);
            this.RenameButton.TabIndex = 4;
            this.RenameButton.Text = "Rename";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButtonClick);
            // 
            // CancelButton
            // 
            this.CancelRenameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelRenameButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelRenameButton.Location = new System.Drawing.Point(463, 468);
            this.CancelRenameButton.Name = "CancelButton";
            this.CancelRenameButton.Size = new System.Drawing.Size(75, 23);
            this.CancelRenameButton.TabIndex = 5;
            this.CancelRenameButton.Text = "Cancel";
            this.CancelRenameButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxNameReplace);
            this.groupBox1.Controls.Add(this.textBoxNamePattern);
            this.groupBox1.Controls.Add(this.Match);
            this.groupBox1.Controls.Add(this.textBoxNumberReplace);
            this.groupBox1.Controls.Add(this.textBoxNumberPattern);
            this.groupBox1.Location = new System.Drawing.Point(12, 343);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 119);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regex Options";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(262, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Replacement";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(93, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 19;
            this.label1.Text = "Pattern";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(0, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 18;
            this.label3.Text = "Sheet Name";
            // 
            // textBoxNameReplace
            // 
            this.textBoxNameReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxNameReplace.Location = new System.Drawing.Point(262, 74);
            this.textBoxNameReplace.Name = "textBoxNameReplace";
            this.textBoxNameReplace.Size = new System.Drawing.Size(166, 20);
            this.textBoxNameReplace.TabIndex = 17;
            // 
            // textBoxNamePattern
            // 
            this.textBoxNamePattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxNamePattern.Location = new System.Drawing.Point(93, 74);
            this.textBoxNamePattern.Name = "textBoxNamePattern";
            this.textBoxNamePattern.Size = new System.Drawing.Size(156, 20);
            this.textBoxNamePattern.TabIndex = 16;
            // 
            // Match
            // 
            this.Match.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Match.Location = new System.Drawing.Point(0, 51);
            this.Match.Name = "Match";
            this.Match.Size = new System.Drawing.Size(87, 14);
            this.Match.TabIndex = 14;
            this.Match.Text = "Sheet Number";
            // 
            // textBoxNumberReplace
            // 
            this.textBoxNumberReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxNumberReplace.Location = new System.Drawing.Point(262, 48);
            this.textBoxNumberReplace.Name = "textBoxNumberReplace";
            this.textBoxNumberReplace.Size = new System.Drawing.Size(166, 20);
            this.textBoxNumberReplace.TabIndex = 13;
            // 
            // textBoxNumberPattern
            // 
            this.textBoxNumberPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxNumberPattern.Location = new System.Drawing.Point(93, 48);
            this.textBoxNumberPattern.Name = "textBoxNumberPattern";
            this.textBoxNumberPattern.Size = new System.Drawing.Size(156, 20);
            this.textBoxNumberPattern.TabIndex = 12;
            // 
            // RenameSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 503);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CancelRenameButton);
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.TestRunButton);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RenameSheetForm";
            this.Text = "Rename sheets (using regex)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNameReplace;
        private System.Windows.Forms.TextBox textBoxNamePattern;
        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Match;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button CancelRenameButton;
        private System.Windows.Forms.Button RenameButton;
        private System.Windows.Forms.Button TestRunButton;
        private System.Windows.Forms.TextBox textBoxNumberReplace;
        private System.Windows.Forms.TextBox textBoxNumberPattern;
        private System.Windows.Forms.ListView listView1;
    }
}
