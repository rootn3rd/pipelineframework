using PipelineFramework.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Exceptions
{
    public class PipelineComponentSettingNotFoundException: Exception
    {
        public PipelineComponentSettingNotFoundException(IPipelineComponent pipelineComponent, string key): base()
        {

        }
    }
}
