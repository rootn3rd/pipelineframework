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
    internal class Pipeline<T> : PipelineBase<IPipelineComponent<T>>, IPipeline<T>
    {
        internal Pipeline(
            IPipelineComponentResolver resolver,
            IEnumerable<string> componentNames,
            IDictionary<string, IDictionary<string, string>> settings
            ) : base(resolver, componentNames, settings)
        {

        }

        internal Pipeline(
             IPipelineComponentResolver resolver,
            IEnumerable<Type> componentTypes,
            IDictionary<string, IDictionary<string, string>> settings
            ) : base(resolver, componentTypes, settings)
        {

        }


        public T Execute(T payload, CancellationToken cancellationToken = default(CancellationToken))
        {
            IPipelineComponent current = null;

            try
            {
                foreach (var component in Components)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    current = component;

                    var currentPayload = component.Execute(payload, cancellationToken);

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
