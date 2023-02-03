using Amazon.Lambda.SQSEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFunction1
{
    internal interface IProcessor
    {
        Task ProcessRequest(SQSEvent.SQSMessage message);
    }
}
