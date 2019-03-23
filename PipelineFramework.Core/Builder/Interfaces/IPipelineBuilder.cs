using PipelineFramework.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Builder.Interfaces
{
    public interface IPipelineBuilder<out TPipeline> where TPipeline: IPipeline
    {
        TPipeline Build();
    }
}
