﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8806
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Com.Suncor.Olt.Common.Localization {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class LocaleSpecificFormatPatternResources_fr {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LocaleSpecificFormatPatternResources_fr() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Com.Suncor.Olt.Common.Localization.LocaleSpecificFormatPatternResources_fr", typeof(LocaleSpecificFormatPatternResources_fr).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $.
        /// </summary>
        public static string CurrencySymbol {
            get {
                return ResourceManager.GetString("CurrencySymbol", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $#.##0_);($#.##0).
        /// </summary>
        public static string ExcelCurrencyFormat {
            get {
                return ResourceManager.GetString("ExcelCurrencyFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #,??.
        /// </summary>
        public static string ExcelDecimalFormat {
            get {
                return ResourceManager.GetString("ExcelDecimalFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ddd yyyy-MM-dd.
        /// </summary>
        public static string LongDatePattern {
            get {
                return ResourceManager.GetString("LongDatePattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to HH:mm:ss.
        /// </summary>
        public static string LongTimePattern {
            get {
                return ResourceManager.GetString("LongTimePattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to yyyy-MM-dd.
        /// </summary>
        public static string ShortDatePattern {
            get {
                return ResourceManager.GetString("ShortDatePattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to yyyy-MM-dd HH:mm.
        /// </summary>
        public static string ShortDateShortTimePattern {
            get {
                return ResourceManager.GetString("ShortDateShortTimePattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to HH:mm.
        /// </summary>
        public static string ShortTimePattern {
            get {
                return ResourceManager.GetString("ShortTimePattern", resourceCulture);
            }
        }
    }
}
