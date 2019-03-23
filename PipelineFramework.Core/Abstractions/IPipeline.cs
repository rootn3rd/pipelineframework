using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Abstractions
{

    public interface IPipeline<T> : IPipeline
    {
        T Execute(T payload, CancellationToken cancellationToken = default(CancellationToken));
    }

    public interface IPipeline
    {
    }
}
