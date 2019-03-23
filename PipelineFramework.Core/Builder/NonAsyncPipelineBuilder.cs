using PipelineFramework.Core.Abstractions;
using PipelineFramework.Core.Builder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Builder
{
    internal class NonAsyncPipelineBuilder<TPayload> : PipelineBuilderBase<IPipeline<TPayload>, IPipelineComponent<TPayload>, TPayload>
    {
        private NonAsyncPipelineBuilder()
        {

        }

        public static IInitialPipelineComponentHolder<IPipeline<TPayload>, IPipelineComponent<TPayload>, TPayload> Initialize()
        {
            return new NonAsyncPipelineBuilder<TPayload>();
        }

        public override IPipeline<TPayload> Build()
        {
            return new Pipeline<TPayload>(
                State.ComponentResolver,
                State.ComponentNames,
                State.Settings);
        }
    }
}
