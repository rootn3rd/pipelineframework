using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Exceptions
{
    public class PipelineComponentNotFoundException: Exception
    {
        public PipelineComponentNotFoundException(string message): base (message)
        {

        }
    }
}
