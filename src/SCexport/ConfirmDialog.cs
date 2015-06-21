﻿// (C) Copyright 2013-2014 by Andrew Nicholas
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

namespace SCaddins.SCexport
{
    using System;
    using System.Windows.Forms;
    
    /// <summary>
    /// Description of ConfirmationDialog.
    /// </summary>
    public partial class ConfirmationDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationDialog"/> class.
        /// </summary>
        /// <param name="s">The full path of the file to evaluate.</param>
        public ConfirmationDialog(string displayMessage)
        {
            this.InitializeComponent();
            this.textBox1.Text = displayMessage;
            this.checkBox1.Checked = Export.ConfirmOverwrite;
        }

        private void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
            Export.ConfirmOverwrite = this.checkBox1.Checked;
        }

        private void Button2Click(object sender, EventArgs e)
        {
            Export.ConfirmOverwrite = true;
        }
    }
}

/* vim: set ts=4 sw=4 nu expandtab: */
