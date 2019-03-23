using PipelineFramework.Core.Abstractions;
using PipelineFramework.Core.Builder.Interfaces;

namespace PipelineFramework.Core.Builder
{
    internal class AsyncPipelineBuilder<TPayload> : PipelineBuilderBase<IAsyncPipeline<TPayload>, IAsyncPipelineComponent<TPayload>, TPayload>
    {
        private AsyncPipelineBuilder()
        {

        }

        public static IInitialPipelineComponentHolder<IAsyncPipeline<TPayload>, IAsyncPipelineComponent<TPayload>, TPayload> Initialize()
        {
            return new AsyncPipelineBuilder<TPayload>();
        }

        public override IAsyncPipeline<TPayload> Build()
        {
            return new AsyncPipeline<TPayload>(
                State.ComponentResolver,
                State.ComponentNames,
                State.Settings);
        }
    }
}
