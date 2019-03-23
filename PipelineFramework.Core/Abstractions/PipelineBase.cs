using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Abstractions
{
    public abstract class PipelineBase<TComponent>
        where TComponent : IPipelineComponent
    {
        protected PipelineBase(
            IPipelineComponentResolver resolver,
            IEnumerable<string> componentNames,
            IDictionary<string, IDictionary<string, string>> settings)
        {
            var list = new List<TComponent>();

            foreach (var name in componentNames)
            {
                IDictionary<string, string> componentSettings = null;

                if (settings != null && settings.ContainsKey(name))
                    componentSettings = settings[name];

                var component = resolver.GetInstance<TComponent>(name);
                component.Initialize(name, componentSettings);

                list.Add(component);
            }

            Components = list;
        }

        protected PipelineBase(
            IPipelineComponentResolver resolver,
            IEnumerable<Type> componentTypes,
            IDictionary<string, IDictionary<string, string>> settings
            ): this(resolver, componentTypes.Select(x=> x.Name), settings)
        {

        }

        protected IEnumerable<TComponent> Components { get; }
    }
}
