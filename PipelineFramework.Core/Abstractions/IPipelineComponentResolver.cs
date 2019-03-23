using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Abstractions
{
    public interface IPipelineComponentResolver
    {
        T GetInstance<T>(string name) where T : IPipelineComponent;
    }
}
