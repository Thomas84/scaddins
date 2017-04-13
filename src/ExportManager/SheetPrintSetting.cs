
// (C) Copyright 2017 by Andrew Nicholas
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

namespace SCaddins.ExportManager
{
    using System;

    public class SheetPrintSetting
    {
        public Autodesk.Revit.DB.PrintSetting RevitPrintSetting
        {
            get; set;
        }
        
        public SheetPaperSize PaperSize
        {
            get;
            set;
        }
        
        public string PrinterName
        {
            get;
            set;
        }
        
        public bool FitToPage
        {
            get;
            set;
        }
        
        public bool FitToPagePaperSize
        {
            get;
            set;
        }
               
        public SheetPrintSetting(SheetPaperSize paperSize)
        {
            FitToPage = false;
            PaperSize = paperSize;
            PrinterName = string.Empty;
        }
    }
    
}
/* vim: set ts=4 sw=4 nu expandtab: */
