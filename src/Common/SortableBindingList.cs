﻿////=================================================================
//// SortedBindingList.cs
////=================================================================
//// PowerSDR is a C# implementation of a Software Defined Radio.
//// Copyright (C) 2004-2011  FlexRadio Systems
////
//// This program is free software; you can redistribute it and/or
//// modify it under the terms of the GNU General Public License
//// as published by the Free Software Foundation; either version 2
//// of the License, or (at your option) any later version.
////
//// This program is distributed in the hope that it will be useful,
//// but WITHOUT ANY WARRANTY; without even the implied warranty of
//// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//// GNU General Public License for more details.
////
//// You should have received a copy of the GNU General Public License
//// along with this program; if not, write to the Free Software
//// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
////
//// You may contact us via email at: gpl@flexradio.com.
//// Paper mail may be sent to:
////    FlexRadio Systems
////    4616 W. Howard Lane  Suite 1-150
////    Austin, TX 78728
////    USA
////=================================================================
//// ref: (http://www.tech.windowsapplication1.com/content/sortable-binding-list-custom-data-objects)
////=================================================================

namespace SCaddins.Common
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Sortable binding list.
    /// </summary>
    public class SortableBindingListCollection<T> : System.ComponentModel.BindingList<T>
    {
        #region fields
        private bool sorted;
        private System.ComponentModel.ListSortDirection sortDirectionm;
        private System.ComponentModel.PropertyDescriptor sortPropertym;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SCexport.SortableBindingList`1"/> class.
        /// </summary>
        public SortableBindingListCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SCexport.SortableBindingList`1"/> class.
        /// </summary>
        /// <param name="list">List.</param>
        public SortableBindingListCollection(List<T> list) : base(list)
        {
        }

        /// <summary>
        /// Gets the sort direction core.
        /// </summary>
        /// <value>The sort direction core.</value>
        protected override System.ComponentModel.ListSortDirection SortDirectionCore
        {
            get {
                return this.sortDirectionm; }
        }

        /// <summary>
        /// Gets the sort property core.
        /// </summary>
        /// <value>The sort property core.</value>
        protected override System.ComponentModel.PropertyDescriptor SortPropertyCore
        {
            get { return this.sortPropertym; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is sorted core.
        /// </summary>
        /// <value><c>true</c> if this instance is sorted core; otherwise, <c>false</c>.</value>
        protected override bool IsSortedCore
        { 
            get { return this.sorted; }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="SCexport.SortableBindingList`1"/> supports sorting core.
        /// </summary>
        /// <value><c>true</c> if supports sorting core; otherwise, <c>false</c>.</value>
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        /// <Docs>To be added.</Docs>
        /// <summary>
        /// Removes the sort core.
        /// </summary>
        protected override void RemoveSortCore() { 
            this.sorted = false;
        }

        /// <Docs>To be added.</Docs>
        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="prop">Property.</param>
        /// <param name="direction">Direction.</param>
        protected override void ApplySortCore(System.ComponentModel.PropertyDescriptor prop, System.ComponentModel.ListSortDirection direction)
        {
            if (prop.PropertyType.GetInterface("IComparable") == null) {
                return;
            }
            
            var list = this.Items as System.Collections.Generic.List<T>;
            if (list == null) {
                this.sorted = false;
            } else {
                var comparer = new PropertyComparer(prop.Name, direction);
                list.Sort(comparer);
                this.sorted = true;
                this.sortDirectionm = direction;
                this.sortPropertym = prop;
            }
            
            this.OnListChanged(new System.ComponentModel.ListChangedEventArgs(System.ComponentModel.ListChangedType.Reset, -1));
        }

        public class PropertyComparer : System.Collections.Generic.IComparer<T>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PropertyComparer"/> class.
            /// </summary>
            /// <param name="propName">Property name.</param>
            /// <param name="direction"> The sort direction.</param>
            public PropertyComparer(string propName, System.ComponentModel.ListSortDirection direction)
            {
                this.PropInfo = typeof(T).GetProperty(propName);
                this.Direction = direction;
            }
            
            private System.Reflection.PropertyInfo PropInfo
            {
                get;
                set;
            }
            
            private System.ComponentModel.ListSortDirection Direction
            {
                get;
                set;
            }

            /// <summary>
            /// Compare the specified x and y.
            /// </summary>
            /// <param name="x">The x coordinate.</param>
            /// <param name="y">The y coordinate.</param>
            /// <returns>Documentation to be done.</returns>
            public int Compare(T x, T y)
            {
                    var xc = this.PropInfo.GetValue(x, null);
                    var yc = this.PropInfo.GetValue(y, null);
                    if (this.Direction == System.ComponentModel.ListSortDirection.Ascending) {
                        return System.Collections.Comparer.Default.Compare(xc, yc);
                    } else {
                        return System.Collections.Comparer.Default.Compare(yc, xc);
                    }
             }
        }
    }
}
