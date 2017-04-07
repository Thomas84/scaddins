// (C) Copyright 2012-2017 by Andrew Nicholas
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
    using System.Globalization;
    using Autodesk.Revit.DB;
    using SCaddins.Common;

    public class ExportSheet
    {
        #region Variables
        private DateTime sheetRevisionDateTime;
        private Document doc;
        private ElementId id;
        private SegmentedSheetName segmentedFileName;
        private ViewSheet sheet;
        private SheetPrintSetting printSetting;
        private bool forceDate;
        private bool verified;
        private int northPointVisible;
        private double height;
        private double width;
        private string fullExportName;
        private string projectNumber;
        private string scale;
        private string scaleBarScale;
        private string sheetDescription;
        private string sheetNumber;
        private string sheetRevision;
        private string sheetRevisionDate;
        private string sheetRevisionDescription;

        public ExportSheet(
                ViewSheet sheet,
                Document doc,
                SegmentedSheetName fileNameTemplate,
                ExportManager scx)
        {
            this.Init(sheet, doc, fileNameTemplate, scx);
        }

        public SheetPaperSize PageSize
        {
            get { return this.pageSize; }
        }
        
        public string ProjectNumber
        {
            get { return this.projectNumber; }
        }

        public SegmentedSheetName SegmentedFileName {
            get {
                return this.segmentedFileName;
            }     
        }

        public string SheetDescription
        {
            get { 
                return this.sheetDescription;
            }
            
            set { 
                this.sheetDescription = value;
                this.SetExportName();
            }
        }

        public string SheetNumber
        {
            get {
                return this.sheetNumber;
            }
            
            set { 
                this.sheetNumber = value;
                this.SetExportName();
            }
        }

        public string SheetRevision
        {
            get {
                return this.sheetRevision ?? "-";
            }
        }

        public string SheetRevisionDescription
        {
            get {
                return this.sheetRevisionDescription ?? "-";
            }
        }

        public string SheetRevisionDate
        {
            get {
                return this.sheetRevisionDate ?? "-";
            }
        }

        public DateTime SheetRevisionDateTime
        {
            get { return this.sheetRevisionDateTime; }
        }

        public string Scale
        {
            get {
                string result = this.scale.Trim();
                int i = 0;
                if (result.Contains(":")) {
                    i = result.IndexOf(':');
                }
                bool flag = false;
                if (string.IsNullOrEmpty(result.Trim())) {
                    result = "0";
                }
                if (!string.IsNullOrEmpty(this.scaleBarScale)) {
                    flag |= i > 0 && !result.Substring(i + 2).Equals(this.scaleBarScale.Trim());
                }
                if (!string.IsNullOrEmpty(this.scaleBarScale.Trim()) && flag) {
                    result += " [**" + this.scaleBarScale + "]";
                }
                return result;
            }
        }
        
        public bool ValidScaleBar
        {
            get { return this.RevitScaleWithoutFormatting() == this.scaleBarScale.Trim(); }
        }
        
        public string ExportDir
        {
            get; set;
        }

        public ViewSheet Sheet
        {
            get { return this.sheet; }
        }
        
        public string NorthPointVisible
        {
            get { 
                if (northPointVisible == 1)
                    return "Yes";
                if (northPointVisible == 0)
                    return "No";
                return "-";
            }
        }

        public string FullExportName
        {
            get { return this.fullExportName; }
        }

        public ElementId Id
        {
            get { return this.id; }
        }

        public double Width
        {
            get { return this.width * 304.8; }
        }

        public double Height
        {
            get { return this.height * 304.8; }
        }

        public SheetPrintSetting SheetPrintSetting
        {
            get { return this.printSetting; }
        }

        public bool Verified
        {
            get { return this.verified; }
        }

        public bool ForceDate
        {
            get {
                return this.forceDate;
            }
            
            set {
                this.forceDate = value;
                this.SetExportName();
            }
        }
        #endregion
        
        public static int GetNorthPointVisiblity(Element titleBlock)
        {
          try {
                    var p = titleBlock.GetParameters(Settings1.Default.NorthPointVisibilityParameter);
                    if (p == null || p.Count < 1) {
                        return 2;
                    }
                    int d = p[0].AsInteger();
                    return d;
            } catch (FormatException) {
                    return 2;
            }    
        }
        
        public static string GetScaleBarScale(Element titleBlock)
        {
          try {
                    var p = titleBlock.GetParameters(Settings1.Default.ScalebarScaleParameter);
                    if (p == null || p.Count < 1) {
                        return string.Empty;
                    }
                    double d = p[0].AsDouble();
                    return d.ToString(CultureInfo.InvariantCulture);
            } catch (FormatException) {
                    return string.Empty;
            }    
        }

        public string FullExportPath(string extension)
        {
            return this.ExportDir + "\\" + this.fullExportName + extension;
        }

        public void UpdateSheetInfo()
        {
            var titleBlock = ExportManager.TitleBlockInstanceFromSheetNumber(
                this.sheetNumber, this.doc);
            if (titleBlock != null) {
                this.scale = titleBlock.get_Parameter(
                    BuiltInParameter.SHEET_SCALE).AsString();
                this.scaleBarScale = ExportSheet.GetScaleBarScale(titleBlock);
                this.northPointVisible = ExportSheet.GetNorthPointVisiblity(titleBlock);
                this.width = titleBlock.get_Parameter(
                        BuiltInParameter.SHEET_WIDTH).AsDouble();
                this.height = titleBlock.get_Parameter(
                        BuiltInParameter.SHEET_HEIGHT).AsDouble();
            }
            var pageSize = new SCaddins.ExportManager.SheetPaperSize(this.width, this.height);
            this.printSetting = PrintSettingsManager.GetRevitPrintSetting(this.doc, );
            this.verified = true;
        }
        
        public string RevitScaleWithoutFormatting()
        {
                string result = this.scale.Trim();
                int i = 0;
                if (result.Contains(":")) {
                    i = result.IndexOf(':');
                } else {
                    return "0";
                }
                return string.IsNullOrEmpty(result.Trim()) ? "0" : result.Substring(i + 2).Trim();
        }
        
        public void SetSegmentedSheetName(SegmentedSheetName segmentedFileName)
        {
            this.segmentedFileName = segmentedFileName;
            this.SetExportName();
        }

        public void UpdateNumber()
        {
            this.sheetNumber = this.sheet.get_Parameter(
                    BuiltInParameter.SHEET_NUMBER).AsString(); 
            this.SetExportName();  
        }
        
        public void UpdateName()
        {
            this.sheetDescription = this.sheet.get_Parameter(
                    BuiltInParameter.SHEET_NAME).AsString();
            this.SetExportName();  
        }
        
        public void UpdateScaleBarScale()
        {
            var titleBlock = ExportManager.TitleBlockInstanceFromSheetNumber(
                this.sheetNumber, this.doc);
            this.SetScaleBarScale(titleBlock);       
        }
        
        public void ToggleNorthPoint()
        {
            var titleBlock = ExportManager.TitleBlockInstanceFromSheetNumber(
                this.sheetNumber, this.doc);
            
                string northPointVisibility = SCaddins.ExportManager.Settings1.Default.NorthPointVisibilityParameter;
            
                var tb = titleBlock.GetParameters(northPointVisibility);
                if (tb == null) {
                    return;
                }
                Parameter p = tb[0];
                int b = p.AsInteger();
                if (b == 2) return;
                b = b == 1 ? 0 : 1;
                p.Set(b);
                this.northPointVisible = b;         
             
        }

        public void UpdateRevision(bool refreshExportName)
        {
            this.sheetRevision = this.sheet.get_Parameter(
                    BuiltInParameter.SHEET_CURRENT_REVISION).AsString();
            this.sheetRevisionDescription = this.sheet.get_Parameter(
                    BuiltInParameter.SHEET_CURRENT_REVISION_DESCRIPTION).AsString();
            this.sheetRevisionDate = this.sheet.get_Parameter(
                    BuiltInParameter.SHEET_CURRENT_REVISION_DATE).AsString();
            this.sheetRevisionDateTime = SCaddins.Common.MiscUtilities.ToDateTime(this.sheetRevisionDate);
            if (refreshExportName) {
                this.SetExportName();
            }
        }
        
        public void SetScaleBarScale(Element titleBlock)
        {
                string titleScale = SCaddins.ExportManager.Settings1.Default.ScalebarScaleParameter;
                var tb = titleBlock.GetParameters(titleScale);
                if (tb == null) {
                    return;
                }
                Parameter p = tb[0];
                p.SetValueString(this.RevitScaleWithoutFormatting());
                this.scaleBarScale = this.RevitScaleWithoutFormatting();          
        }
        
        public override string ToString()
        {
            return string.Format(
                "Sheet information: " + Environment.NewLine +
                "    SheetRevisionDateTime={0}," + Environment.NewLine +
                "    Doc={1}," + Environment.NewLine +
                "    Id={2}," + Environment.NewLine +
                "    PrintSetting={3}," + Environment.NewLine +
                "    SegmentedFileName={4}," + Environment.NewLine +
                "    Sheet={5}," + Environment.NewLine +
                "    ForceDate={6}," + Environment.NewLine +
                "    Verified={7}," + Environment.NewLine +
                "    Height={8}," + Environment.NewLine +
                "    Width={9}," + Environment.NewLine +
                "    FullExportName={10}," + Environment.NewLine +
                "    PageSize={11}," + Environment.NewLine +
                "    ProjectNumber={12}," + Environment.NewLine +
                "    Scale={13}," + Environment.NewLine +
                "    ScaleBarScale={14}," + Environment.NewLine +
                "    SheetDescription={15}," + Environment.NewLine +
                "    SheetNumber={16}," + Environment.NewLine +
                "    SheetRevision={17}," + Environment.NewLine +
                "    SheetRevisionDate={18}," + Environment.NewLine +
                "    SheetRevisionDescription={19}," + Environment.NewLine +
                "    ExportDir={20}",
                this.sheetRevisionDateTime,
                this.doc.PathName,
                this.id,
                this.printSetting,
                this.segmentedFileName,
                this.sheet,
                this.forceDate,
                this.verified,
                this.height,
                this.width,
                this.fullExportName,
                this.printSetting.PaperSize.ToString(),
                this.projectNumber,
                this.scale,
                this.scaleBarScale,
                this.sheetDescription,
                this.sheetNumber,
                this.sheetRevision,
                this.sheetRevisionDate,
                this.sheetRevisionDescription,
                this.ExportDir);
        }
               
        private void Init(
                ViewSheet viewSheet,
                Document document,
                SegmentedSheetName sheetName,
                ExportManager scx)
        {
            this.doc = document;
            this.sheet = viewSheet;
            this.segmentedFileName = sheetName;
            this.verified = false;
            this.ExportDir = scx.ExportDir;
            this.sheetNumber = viewSheet.get_Parameter(BuiltInParameter.SHEET_NUMBER).AsString();
            this.sheetDescription = viewSheet.get_Parameter(BuiltInParameter.SHEET_NAME).AsString();
            this.projectNumber = document.ProjectInformation.Number;
            this.width = 841;
            this.height = 594;
            this.scale = string.Empty;
            this.scaleBarScale = string.Empty;
            this.northPointVisible = 2;
            var paperSize = new SheetPaperSize(this.width, this.height);
            this.printSetting = new SheetPrintSetting(paperSize);
            this.id = viewSheet.Id;
            this.UpdateRevision(false);
            this.SetExportName();
        }
        
        private string PopulateSegmentedFileName()
        {
            return PostExportHookCommand.FormatConfigurationString(this, this.segmentedFileName.NameFormat, string.Empty);
        }

        private void SetExportName()
        {
            if (this.forceDate) {
                this.sheetRevision = MiscUtilities.GetDateString;
            } else {
                this.sheetRevision = this.sheet.get_Parameter(
                    BuiltInParameter.SHEET_CURRENT_REVISION).AsString();
            }

            if (this.sheetRevision.Length < 1) {
                this.sheetRevision = MiscUtilities.GetDateString;
            }

            this.fullExportName = this.PopulateSegmentedFileName();
        }
    }
}

/* vim: set ts=4 sw=4 nu expandtab: */
