﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SCaddins.ExportManager {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    public sealed partial class Settings1 : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings1 defaultInstance = ((Settings1)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings1())));
        
        public static Settings1 Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\SCAPP01\\FollowYouColour")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public string A3PrinterDriver {
            get {
                return ((string)(this["A3PrinterDriver"]));
            }
            set {
                this["A3PrinterDriver"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("R2010")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public string AcadExportVersion {
            get {
                return ((string)(this["AcadExportVersion"]));
            }
            set {
                this["AcadExportVersion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool AdobePDFMode {
            get {
                return ((bool)(this["AdobePDFMode"]));
            }
            set {
                this["AdobePDFMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Adobe PDF")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public string AdobePrinterDriver {
            get {
                return ((string)(this["AdobePrinterDriver"]));
            }
            set {
                this["AdobePrinterDriver"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Temp")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public string ExportDir {
            get {
                return ((string)(this["ExportDir"]));
            }
            set {
                this["ExportDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool ForceDateRevision {
            get {
                return ((bool)(this["ForceDateRevision"]));
            }
            set {
                this["ForceDateRevision"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Program Files\\gs\\gs9.15\\bin")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public string GSBinDirectory {
            get {
                return ((string)(this["GSBinDirectory"]));
            }
            set {
                this["GSBinDirectory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Program Files\\gs\\gs9.15\\lib")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public string GSLibDirectory {
            get {
                return ((string)(this["GSLibDirectory"]));
            }
            set {
                this["GSLibDirectory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool HideTitleBlocks {
            get {
                return ((bool)(this["HideTitleBlocks"]));
            }
            set {
                this["HideTitleBlocks"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\SCAPP01\\DocuWide3035 (PS)")]
        public string LargeFormatPrinterDriver {
            get {
                return ((string)(this["LargeFormatPrinterDriver"]));
            }
            set {
                this["LargeFormatPrinterDriver"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("North Point")]
        public string NorthPointVisibilityParameter {
            get {
                return ((string)(this["NorthPointVisibilityParameter"]));
            }
            set {
                this["NorthPointVisibilityParameter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>A0 (841x1189mm)</string>
  <string>A1 (594x841mm)</string>
  <string>A2 (420x594mm)</string>
  <string>A3 (297x420mm)</string>
  <string>ISO B1 (707x1000mm)</string>
  <string>ISO B2 (500x707mm)</string>
  <string>ISO B3 (353x500mm)</string>
  <string>ISO B4 (250x353mm)</string>
  <string>B1 (728x1030mm)</string>
  <string>B2 (515x728mm)</string>
  <string>B3 (364x515mm)</string>
  <string>B4 ( 257x364mm)</string>
  <string>ANSI A (8.5x11in)</string>
  <string>ANSI B (11x17in)</string>
  <string>ANSI C (17x22in)</string>
  <string>ANSI D (22x34in)</string>
  <string>ANSI E (34x44)</string>
  <string>Arch A (9x12in)</string>
  <string>Arch B (12x18in)</string>
  <string>Arch C (18x24in)</string>
  <string>Arch D (24x36in)</string>
  <string>Arch E (36x48in)</string>
  <string>Arch E1 (30x42in)</string>
  <string>Arch E2 (26x38in)</string>
  <string>Arch E3 (27x39in)</string>
  <string>Arch30 B (10.5x15in)</string>
  <string>Arch30 C (15x21in)</string>
  <string>Arch30 D (21x30in)</string>
  <string>Arch30 E (30x42in)</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection PaperSizes {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["PaperSizes"]));
            }
            set {
                this["PaperSizes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\SCAPP01\\DocuWide3035 (PS)")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public string PSPrinterDriver {
            get {
                return ((string)(this["PSPrinterDriver"]));
            }
            set {
                this["PSPrinterDriver"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Scalebar Scale")]
        public string ScalebarScaleParameter {
            get {
                return ((string)(this["ScalebarScaleParameter"]));
            }
            set {
                this["ScalebarScaleParameter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ShowExportLog {
            get {
                return ((bool)(this["ShowExportLog"]));
            }
            set {
                this["ShowExportLog"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public bool TagPDFExports {
            get {
                return ((bool)(this["TagPDFExports"]));
            }
            set {
                this["TagPDFExports"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("notepad.exe")]
        [global::System.Configuration.SettingsManageabilityAttribute(global::System.Configuration.SettingsManageability.Roaming)]
        public string TextEditor {
            get {
                return ((string)(this["TextEditor"]));
            }
            set {
                this["TextEditor"] = value;
            }
        }
    }
}
