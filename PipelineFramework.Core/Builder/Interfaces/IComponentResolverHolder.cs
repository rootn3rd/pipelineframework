using PipelineFramework.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Builder.Interfaces
{
    public interface IComponentResolverHolder<out TPipeline> where TPipeline : IPipeline
    {
        ISettingsHolder<TPipeline> WithComponentResolver(IPipelineComponentResolver componentResolver);
    }
}
