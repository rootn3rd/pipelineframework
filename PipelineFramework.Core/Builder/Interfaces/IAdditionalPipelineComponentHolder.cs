using PipelineFramework.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Builder.Interfaces
{
    public interface IAdditionalPipelineComponentHolder<out TPipeline, TComponentBase, TPayload> :
        IInitialPipelineComponentHolder<TPipeline, TComponentBase, TPayload>,
        IComponentResolverHolder<TPipeline>
        where TPipeline : IPipeline
        where TComponentBase : IPipelineComponent
    {
    }
}
