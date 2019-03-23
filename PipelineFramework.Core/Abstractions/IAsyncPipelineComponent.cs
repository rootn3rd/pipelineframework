using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Abstractions
{
    public interface IAsyncPipelineComponent<T> : IPipelineComponent
    {
        Task<T> ExecuteAsync(T payload, CancellationToken cancellationToken);
    }
}
