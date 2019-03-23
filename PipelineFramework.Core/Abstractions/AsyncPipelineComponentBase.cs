using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Abstractions
{
    public abstract class AsyncPipelineComponentBase<T> : IAsyncPipelineComponent<T>
    {
        protected AsyncPipelineComponentBase()
        {
            Settings = new Settings(this);
        }

        public string Name { get; private set; }

        protected IDictionary<string, string> Settings { get; }

        public abstract Task<T> ExecuteAsync(T payload, CancellationToken cancellationToken);

        public virtual void Initialize(string name, IDictionary<string, string> settings)
        {
            Name = name;

            if (settings == null)
                return;

            Settings.AddRange(settings.Select(x => x));
        }
    }
}
