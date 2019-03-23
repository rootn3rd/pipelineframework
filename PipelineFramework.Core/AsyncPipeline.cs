using PipelineFramework.Core.Abstractions;
using PipelineFramework.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipelineFramework.Core
{
    internal class AsyncPipeline<T> : PipelineBase<IAsyncPipelineComponent<T>>, IAsyncPipeline<T>
    {
        internal AsyncPipeline(
             IPipelineComponentResolver resolver,
            IEnumerable<string> componentNames,
            IDictionary<string, IDictionary<string, string>> settings
            ) : base(resolver, componentNames, settings)
        {

        }

        internal AsyncPipeline(
            IPipelineComponentResolver resolver,
            IEnumerable<Type> componentTypes,
            IDictionary<string, IDictionary<string, string>> settings
            ) : base(resolver, componentTypes, settings)
        {

        }

        public async Task<T> ExecuteAsync(T payload, CancellationToken cancellationToken)
        {
            IPipelineComponent current = null;

            try
            {
                foreach (var component in Components)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    current = component;

                    var currentPayload = await component.ExecuteAsync(payload, cancellationToken);

                    if (currentPayload == null) break;

                    payload = currentPayload;

                }

                return payload;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new PipelineExecutionException(current, exception);
            }

        }
    }
}
