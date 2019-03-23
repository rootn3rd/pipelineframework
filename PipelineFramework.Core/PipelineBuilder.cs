using PipelineFramework.Core.Abstractions;
using PipelineFramework.Core.Builder;
using PipelineFramework.Core.Builder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core
{
    public static class PipelineBuilder<TPayload>
    {
        public static IInitialPipelineComponentHolder<IAsyncPipeline<TPayload>, IAsyncPipelineComponent<TPayload>, TPayload> Async()
        {
            return AsyncPipelineBuilder<TPayload>.Initialize();
        }


        public static IInitialPipelineComponentHolder<IPipeline<TPayload>, IPipelineComponent<TPayload>, TPayload> NonAsync()
        {
            return NonAsyncPipelineBuilder<TPayload>.Initialize();
        }
    }
}
