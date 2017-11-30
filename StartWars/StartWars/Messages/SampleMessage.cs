using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartWars.Messages
{
    internal class SampleMessage : MessageBase
    {
        public SampleMessage(int invokedCount) : base()
        {
            InvokedCount = invokedCount;
        }

        public int InvokedCount { get; set; }
    }
}
