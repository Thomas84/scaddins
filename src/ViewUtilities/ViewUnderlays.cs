﻿// (C) Copyright 2015 by Andrew Nicholas
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

namespace SCaddins.ViewUtilities
{
    using System.Collections.Generic;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    
    public static class ViewUnderlays
    {
        public static void RemoveUnderlays(
            ICollection<SCaddins.ExportManager.ExportSheet> sheets, Document doc)
        {
            var t = new Transaction(doc, "Remove Underlays");
            t.Start();
            foreach (SCaddins.ExportManager.ExportSheet sheet in sheets) {
                foreach (ElementId id in sheet.Sheet.GetAllPlacedViews()) {
                    var v = (View)doc.GetElement(id);
                    RemoveUnderlay(v);
                } 
            }
            t.Commit();            
        }
        
        public static void RemoveUnderlays(UIDocument uidoc)
        {
            var selection = uidoc.Selection;
            if (selection.GetElementIds().Count < 1) {
                return;
            }
            var t = new Transaction(uidoc.Document);
            t.Start("Remove Underlays");
            foreach (ElementId id in selection.GetElementIds()) {
                RemoveUnderlay(uidoc.Document.GetElement(id));
            }
            t.Commit();
        }
        
        private static void RemoveUnderlay(Element element)
        {
            if (element.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Views) {
                var param = element.get_Parameter(BuiltInParameter.VIEW_UNDERLAY_BOTTOM_ID);
                if (param != null) {
                    param.Set(ElementId.InvalidElementId);
                }
            }   
        }     
    }
}