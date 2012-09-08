﻿#region License
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

using System.Windows;

namespace AvalonWizardSample
{
    /// <summary>
    /// Interaction logic for EventLogWindow.xaml
    /// </summary>
    public partial class EventLogWindow : Window
    {
        public EventLogWindow()
        {           
            InitializeComponent();
        }

        public void AddLogItem(EventLogItem logItem)
        {
            if (logItem != null)
            {
                eventsList.Items.Add(logItem);
            }
        }
    }
}
