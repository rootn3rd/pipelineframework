using PipelineFramework.Core.Abstractions;
using PipelineFramework.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core
{
    public class DictionaryPipelineComponentResolver : IPipelineComponentResolver
    {
        private readonly IDictionary<string, IPipelineComponent> _components;

        public DictionaryPipelineComponentResolver(IDictionary<string, IPipelineComponent> components)
        {
            _components = components;
        }

        public T GetInstance<T>(string name) where T : IPipelineComponent
        {
            if (!_components.ContainsKey(name))
                throw new PipelineComponentNotFoundException($"PipelineComponent named {name} could not be located");

            return (T)_components[name];
        }
    }
}
