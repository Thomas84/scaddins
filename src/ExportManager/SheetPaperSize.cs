
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
    using System.Text.RegularExpressions;

    public class SheetPaperSize
    {
        #region Properties
        
        /// <summary>
        /// Valid Ghostscript printer names and sizes
        /// @see https://ghostscript.com/doc/7.07/Use.htm#Known_paper_sizes
        /// @see https://en.wikipedia.org/wiki/Paper_size
        /// </summary>
        public static string[] AvailableGhostScriptPageSizes
        {
            get {
                return new string[]  {
                    @"a0 ( 841 x 1189 mm )",
                    @"a1 ( 594 x 841 mm )",
                    @"a2 ( 420 x 594 mm )",
                    @"a3 ( 297 x 420 mm )",
                    @"a4 ( 210 x 297 mm )",
                    @"a4 small( 210 x 297 mm )",
                    @"a5 ( 148 x 210 mm )",
                    @"a6 ( 105 x 148 mm )",
                    @"a7 ( 74 x 105 mm )",
                    @"a8 ( 52 x 74mm )",
                    @"a9 ( 37 x 52mm )",
                    @"a10 ( 26 x 37mm )",
                    @"isob0 ( 1000x 1414 mm )",
                    @"isob1 ( 707 x 1000 mm )",
                    @"isob2 ( 500 x 707 mm )",
                    @"isob3 ( 353 x 500 mm )",
                    @"isob4 ( 250 x 353 mm )",
                    @"isob5 ( 176 x 250 mm )",
                    @"isob6 ( 125 x 176 mm )",
                    @"c0 ( 917 x 1297 mm )",
                    @"c1 ( 648 x 917 mm )",
                    @"c2 ( 458 x 648 mm )",
                    @"c3 ( 324 x 458 mm )",
                    @"c4 ( 229 x 324 mm )",
                    @"c5 ( 162 x 229 mm )",
                    @"c6 ( 114 x 162 mm )",
                    @"jisb0 ( 1030x 1456 mm )",
                    @"jisb1 ( 728 x 1030 mm )",
                    @"jisb2 ( 515 x 728 mm )",
                    @"jisb3 ( 364 x 515 mm )",
                    @"jisb4 ( 257 x 364 mm )",
                    @"jisb5 ( 182 x 257 mm )",
                    @"jisb6 ( 128 x 182 mm )",
                    @"11x17 ( 279 x 432 mm )",
                    @"ledger ( 432 x 279 mm )",
                    @"legal ( 216 x 356 mm )",
                    @"letter ( 216 x 279 mm )",
                    @"letter small( 216 x 279 mm )",
                    @"archE ( 914 x 1219 mm )",
                    @"archD ( 610 x 914 mm )",
                    @"archC ( 457 x 610 mm )",
                    @"archB ( 305 x 457 mm )",
                    @"archA ( 229 x 305 mm )"
                };
            }
        }
        
        public double WidthPX
        {
            get {
                return Width / 72;
            }
        }
        
        public double HeightPX
        {
            get {
                return Height / 72;
            }
        }
        
        public double Width
        {
            get; set;
        }
        
        public double Height
        {
            get; set;
        }
        
        public bool IsPortrait
        {
            get {
                return Height > Width;
            }
        }
        
        public string Name
        {
            get; set;
        }
        
        public string NameWithOrientation
        {
            get {
                return IsPortrait ? Name + @"-Portrait" : Name + @"-Landcape";
            }
        }
        
        public string GhostScriptName
        {
            get; set;
        }
        
        #endregion
                              
        public SheetPaperSize (string formatedPaperSizeString)
        {
            const string pattern = @"(^.*)\((.*)x(.*)([a-z][a-z])\)";
            var match = Regex.Match(formatedPaperSizeString, pattern);
            
            if (match.Success) {
                Name = match.Groups[1].Value;
                var width = match.Groups[2].Value;
                var height = match.Groups[3].Value;
                var units = match.Groups[4].Value;
                System.Diagnostics.Debug.WriteLine("Size {0:G}: Width {1:G}: Height {2:G}: Units {3:G}", Name, width, height, units);
                double w = 0;
                double h = 0;
                if (double.TryParse(width, out w) && double.TryParse(height, out h)) {
                    Width = w;
                    Height = h;
                    if (units == "in") { 
                        Width = Width * 25.4;
                        Height = Height * 25.4;
                        GhostScriptName = GetGhostScriptPageName(Name);
                    }
                } else {
                    Width = -1;
                    Height = -1;
                    GhostScriptName = string.Empty;
                }
            }
        }
        
        /// <summary>
        /// Find the name of the printer by width and height.
        /// This is not very reliable for printers with unusual naming conventions
        /// but should work for standard sizes.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public SheetPaperSize (double width, double height)
        {
            Width = width;
            Height = height;
            Name = SheetPaperSize.GetNameByDimensions(Width, Height);
            GhostScriptName = SheetPaperSize.GetGhostScriptPageName(Name);
        }
        
        /// <summary>
        /// Attempt to get a valid Ghostscript page name
        /// for this paper size.
        /// </summary>
        /// <returns>GhostScript page name, or string.empty if not found</returns>
        public static string GetGhostScriptPageName(string name)
        {             
            string test = name.Replace(@" ","").ToLower();           
            foreach (string s in SheetPaperSize.AvailableGhostScriptPageSizes) {
                if (s.Contains(test)) {
                    return test;
                }
            }
            return string.Empty;
        }
        
        private static string GetNameByDimensions(double width, double height)
        {
            //FIXME
            return "A1";
        }
        
    }
}
/* vim: set ts=4 sw=4 nu expandtab: */
