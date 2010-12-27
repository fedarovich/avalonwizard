#region Licence
// This file is part of AvalonWizard.
// 
// AvalonWizard is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
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
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AvalonWizard.Design
{
    [MarkupExtensionReturnType(typeof(ImageSource))]
    public class AssemblyImageExtension : MarkupExtension
    {
        public AssemblyImageExtension()
        {           
        }

        public AssemblyImageExtension(String name)
        {
            Name = name;
        }

        #region Overrides of MarkupExtension

        /// <summary>
        /// When implemented in a derived class, returns an object that is set as the value of the target property for this markup extension. 
        /// </summary>
        /// <returns>
        /// The object value to set on the property where the extension is applied. 
        /// </returns>
        /// <param name="serviceProvider">Object that can provide services for the markup extension.
        /// </param>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var streamResourceInfo = Application.GetResourceStream(ResourceHelper.GetImageUri(Name));
            if (streamResourceInfo != null)
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = streamResourceInfo.Stream;
                bitmap.EndInit();
                return bitmap;
            }
            return null;
        }

        #endregion

        public string Name
        {
            get;
            set;
        }
    }
}
