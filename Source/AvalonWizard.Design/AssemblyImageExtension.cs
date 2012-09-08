#region License
// Copyright © Pavel Fedarovich, 2010-2012
// 
// This file is part of AvalonWizard.
//  
// You may at your option receive a license to Avalon Wizard under 
// either the terms of the Apache License version 2.0 or 
// the GNU Lesser General Public License (LGPL) version 2.1 or any later version.
//  
// AvalonWizard is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
//  
// You may obtain a copy of the Apache License at [http://www.apache.org/licenses/LICENSE-2.0].
// You may obtain a copy of the LGPL at [http://www.gnu.org/licenses/].
#endregion

using System;
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
