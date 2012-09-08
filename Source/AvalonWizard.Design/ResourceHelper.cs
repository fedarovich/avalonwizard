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
using System.Reflection;

namespace AvalonWizard.Design
{
    internal static class ResourceHelper
    {
        internal static Uri GetImageUri(String imageName)
        {
            String path = String.Format("{0};component/Images/{1}",
                                        Assembly.GetExecutingAssembly().GetName().Name,
                                        imageName);
            return new Uri(path, UriKind.Relative);
        }

        internal static Uri GetEffectUri(String effectName)
        {
            String path = String.Format("{0};component/Effects/{1}",
                                        Assembly.GetExecutingAssembly().GetName().Name,
                                        effectName);
            return new Uri(path, UriKind.Relative);
        }
    }
}
