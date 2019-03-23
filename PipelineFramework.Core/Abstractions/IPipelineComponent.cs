using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Abstractions
{
    public interface IPipelineComponent
    {
        string Name { get; }

        void Initialize(string name, IDictionary<string, string> settings);
    }


    public interface IPipelineComponent<T> : IPipelineComponent
    {
        T Execute(T payload, CancellationToken cancellationToken);
    }
}
