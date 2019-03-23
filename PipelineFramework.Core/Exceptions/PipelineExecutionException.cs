using PipelineFramework.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Exceptions
{
    public class PipelineExecutionException : PipelineComponentExceptionBase
    {
        private const string ErrorMessage = "Pipeline execution halted! Pipeline component named {0} has thrown an exception. See inner exception for details";

        public PipelineExecutionException(
            IPipelineComponent pipelineComponent,
            Exception componentException) : base(pipelineComponent, componentException)
        { }

        protected override string GetErrorMessage()
        {
            return string.Format(ErrorMessage, ThrowingComponent.Name);
        }
    }
}
