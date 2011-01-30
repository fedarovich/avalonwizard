#region Licence
// This file is part of AvalonWizard.
// 
// AvalonWizard is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 2.1 of the License, or
// (at your option) any later version.
// 
// AvalonWizard is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with AvalonWizard.  If not, see <http://www.gnu.org/licenses/>.
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace AvalonWizard
{
    /// <summary>
    /// The collection of wizard's pages.
    /// </summary>
    public class WizardPageCollection : ObservableCollection<WizardPage>
    {
        internal WizardPageCollection(Wizard wizard)
        {
            this.wizard = wizard;
        }

        /// <summary>
        /// Inserts an item into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert.</param>
        protected override void InsertItem(int index, WizardPage item)
        {
            if (item.Wizard != null)
            {
                throw new InvalidOperationException();
            }
            item.Wizard = wizard;
            base.InsertItem(index, item);
        }

        /// <summary>
        /// Removes the item at the specified index of the collection.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        protected override void RemoveItem(int index)
        {
            if (index >= 0 && index < Items.Count)
            {
                var item = Items[index];
                item.Wizard = null;
            } 
            base.RemoveItem(index);
        }

        /// <summary>
        /// Removes all items from the collection. 
        /// </summary>
        protected override void ClearItems()
        {
            foreach (var item in Items)
            {
                item.Wizard = null;
            }
            base.ClearItems();
        }

        /// <summary>
        /// Replaces the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to replace.</param>
        /// <param name="item">The new value for the element at the specified index.</param>
        protected override void SetItem(int index, WizardPage item)
        {
            if (item.Wizard != null)
            {
                throw new InvalidOperationException();
            }
            if (index >= 0 && index < Items.Count)
            {
                var oldItem = Items[index];
                oldItem.Wizard = null;
                item.Wizard = wizard;
            } 
            base.SetItem(index, item);
        }

        private readonly Wizard wizard;
    }
}
