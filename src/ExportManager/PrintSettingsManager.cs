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
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;

    public static class PrintSettingsManager
    {  
        public static bool CreatePrintSetting(Document doc, SheetPrintSetting sheetPrintSetting) {
            Autodesk.Revit.DB.PrintManager pm = doc.PrintManager;
            bool success = false;

            foreach (Autodesk.Revit.DB.PaperSize autodeskPaperSize in pm.PaperSizes) {
                if (string.Equals(autodeskPaperSize.Name, sheetPrintSetting.PaperSize.Name, StringComparison.InvariantCultureIgnoreCase)) {
                    var t = new Transaction(doc, "Apply print settings");
                    t.Start();
                    var ips = pm.PrintSetup.CurrentPrintSetting;
                    try {
                        ips.PrintParameters.PaperSize = autodeskPaperSize;
                        ips.PrintParameters.HideCropBoundaries = true;
                        if (sheetPrintSetting.PaperSize.IsPortrait) {
                            ips.PrintParameters.PageOrientation = PageOrientationType.Portrait;
                        } else {
                            ips.PrintParameters.PageOrientation = PageOrientationType.Landscape;
                        }
                        ips.PrintParameters.HideScopeBoxes = true;
                        ips.PrintParameters.HideReforWorkPlanes = true;
                        ips.PrintParameters.HideUnreferencedViewTags = true;
                        
                        if (sheetPrintSetting.FitToPage) {
                            ips.PrintParameters.ZoomType = ZoomType.FitToPage;
                            ips.PrintParameters.PaperPlacement = PaperPlacementType.Margins;
                            ips.PrintParameters.MarginType = MarginType.UserDefined;
                            ips.PrintParameters.UserDefinedMarginX = 0;
                            ips.PrintParameters.UserDefinedMarginY = 0;
                        } else {
                            ips.PrintParameters.ZoomType = ZoomType.Zoom;
                            ips.PrintParameters.Zoom = 100;
                            ips.PrintParameters.PaperPlacement = PaperPlacementType.Margins;
                            ips.PrintParameters.MarginType = MarginType.UserDefined;
                            ips.PrintParameters.UserDefinedMarginX = 0;
                            ips.PrintParameters.UserDefinedMarginY = 0;
                        }

                        pm.PrintSetup.SaveAs("SCX-" + autodeskPaperSize.Name);
                        t.Commit();
                        success = true;
                    } catch (InvalidOperationException ex) {
                        System.Diagnostics.Debug.Print(ex.Message);
                        TaskDialog.Show(
                            "SCexport",
                            "Unable to create print setting: " + "SCX-" + autodeskPaperSize.Name);
                        t.RollBack();
                    }
                }
            }
            return success;
        }

        public static bool AssignPrintMangerSettings(
                Document doc,
                PrintManager pm,
                SheetPrintSetting printSetting,
                ExportLog log)
        {
            PrintSetting ps = LoadRevitPrintSetting(doc,
                                                    printSetting.Size,
                                                    pm,
                                                    printSetting.PrinterName,
                                                    log);
            
            if (ps == null) {
                return false;
            }
            
            var t = new Transaction(doc, "Apply print settings");
            t.Start();
            try {
                if (ps.IsValidObject) {
                    pm.PrintSetup.CurrentPrintSetting = ps;
                } else {
                    log.AddWarning(null, "Print Setup is readonly!");
                }
                pm.PrintRange = PrintRange.Current;
                pm.PrintSetup.CurrentPrintSetting.PrintParameters.MarginType = MarginType.NoMargin;
                pm.PrintSetup.InSession.PrintParameters.MarginType = MarginType.NoMargin;
                pm.PrintToFile = false;
                pm.Apply();
                t.Commit();
                return true;
            } catch (Exception ex) {
                System.Diagnostics.Debug.Print(ex.Message);
                log.AddError(null, ex.ToString());
                t.RollBack();
                return false;
            }
        }

        public static bool AssignPrintToFilePrintManagerSettings(
                Document doc,
                ExportSheet vs,
                PrintManager pm,
                string ext,
                string printerName)
        {
            if (vs. == null) {
                vs.UpdateSheetInfo();
                return false;
            }

            if (!PrintSettingsManager.SetPrinterByName(doc, printerName, pm)) {
                return false;
            }

            var t = new Transaction(doc, "Print Pdf");
            t.Start();
            try {
                pm.PrintSetup.CurrentPrintSetting = vs.SheetPrintSetting.RevitPrintSetting;
                pm.PrintRange = PrintRange.Current;
                pm.PrintToFile = true;
                pm.PrintToFileName = vs.FullExportPath(ext);
                pm.Apply();
                t.Commit();
                return true;
            } catch (InvalidOperationException ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                t.RollBack();
                return false;
            }
        }

        public static Autodesk.Revit.DB.PrintSetting GetRevitPrintSetting(Document doc, string revitPrintSettingName)
        {
            foreach (ElementId id in doc.GetPrintSettingIds()) {
                var ps2 = doc.GetElement(id) as Autodesk.Revit.DB.PrintSetting;
                if (ps2.Name.ToString().Equals(revitPrintSettingName)) {
                    return ps2;
                }
            }

            if (!CreatePrintSetting(doc, revitPrintSettingName)) {
                return null;
            }

            foreach (ElementId id in doc.GetPrintSettingIds()) {
                var ps2 = doc.GetElement(id) as PrintSetting;
                if (ps2 != null && ps2.Name.ToString().Equals(revitPrintSettingName)) {
                    return ps2;
                }
            }

            var msg = revitPrintSettingName + " could not be created!";
            TaskDialog.Show("Creating Papersize", msg);
            return null;
        }

        public static bool SetPrinterByName(
                Document doc, string name, PrintManager pm)
        {
            if (string.IsNullOrEmpty(name)) {
                return false;
            }
            var t = new Transaction(doc, "Set printer");
            t.Start();
            try {
                pm.SelectNewPrintDriver(name);
                t.Commit();
                return true;
            } catch (InvalidOperationException e) {
                var msg = "Print driver " + name + " not found.  Exiting now. Message: " + e.Message;
                TaskDialog.Show("SCexport", msg);
                t.RollBack();
                return false;
            }
        }

        private static PrintSetting LoadRevitPrintSetting(
                Document doc,
                PrintManager pm,
                SheetPrintSetting sheetPrintSetting,
                ExportLog log)
        {       
            log.AddMessage("Attempting to Load Revit Print Settings:" + size);
            PrintSetting ps = PrintSettingsManager.GetRevitPrintSetting(doc, sheetPrintSetting.RevitPrintSetting.Name);

            if (ps == null) {
                log.AddError(null, "Retrieving Revit Print Settings FAILED");
                return null;
            }
            
            log.AddMessage("Using printer : " + sheetPrintSetting.PrinterName);
            if (!PrintSettingsManager.SetPrinterByName(doc, sheetPrintSetting.PrinterName, pm)) {
                log.AddError(null, "Cannot set printer: " + sheetPrintSetting.PrinterName);
                return null;
            } 
            return ps;
        }
    }
}

/* vim: set ts=4 sw=4 nu expandtab: */
