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

using System.Reflection;

[assembly: AssemblyCompany("Pavel Fedarovich")]
[assembly: AssemblyProduct("AvalonWizard")]
[assembly: AssemblyCopyright("Copyright © Pavel Fedarovich, 2010-2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//In order to begin building localizable applications, set 
//<UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
//inside a <PropertyGroup>.  For example, if you are using US english
//in your source files, set the <UICulture> to en-US.  Then uncomment
//the NeutralResourceLanguage attribute below.  Update the "en-US" in
//the line below to match the UICulture setting in the project file.

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]

[assembly: AssemblyVersion("1.2.0.0")]

#if NET35
[assembly: AssemblyFileVersion("1.2.0.35")]
[assembly: AssemblyInformationalVersion("1.2.0 RC for .Net 3.5")]
#elif NET40
[assembly: AssemblyFileVersion("1.2.0.40")]
[assembly: AssemblyInformationalVersion("1.2.0 RC for .Net 4.0")]
#endif



