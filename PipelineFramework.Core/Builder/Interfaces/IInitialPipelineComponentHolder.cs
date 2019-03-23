using PipelineFramework.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Builder.Interfaces
{
    public interface IInitialPipelineComponentHolder<out TPipeline, TComponentBase, TPayload>
        where TPipeline: IPipeline
        where TComponentBase: IPipelineComponent
    {
        IAdditionalPipelineComponentHolder<TPipeline, TComponentBase, TPayload> WithComponent<TComponent>() where TComponent : TComponentBase;

        IAdditionalPipelineComponentHolder<TPipeline, TComponentBase, TPayload> WithComponent(string componentName);

    }
}
