using PipelineFramework.Core.Abstractions;
using System;

namespace PipelineFramework.Core.Exceptions
{
    public abstract class PipelineComponentExceptionBase : Exception
    {
        protected PipelineComponentExceptionBase(
            IPipelineComponent pipelineComponent,
            Exception innerException = null
            ) : base(null, innerException)
        {

        }

        public IPipelineComponent ThrowingComponent { get; }

        public override string Message => GetErrorMessage();

        protected abstract string GetErrorMessage();
    }
}
