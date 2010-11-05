using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvalonWizardSample
{
    public class EventLogItem
    {
        public String EventName
        {
            get;
            set;
        }

        public String Sender
        {
            get;
            set;
        }

        public String ParameterName
        {
            get;
            set;
        }

        public String ParameterValue
        {
            get;
            set;
        }
    }
}
