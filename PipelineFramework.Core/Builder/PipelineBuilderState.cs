using PipelineFramework.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Builder
{
    internal class PipelineBuilderState
    {
        private readonly List<string> _componentNames = new List<string>();
        public IEnumerable<string> ComponentNames => _componentNames;

        public IPipelineComponentResolver ComponentResolver { get; set; }

        public IDictionary<string, IDictionary<string, string>> Settings { get; set; }

        public void AddComponent(Type component)
        {
            AddComponent(component.Name);
        }

        public void AddComponent(string componentName)
        {
            if (string.IsNullOrEmpty(componentName)) throw new ArgumentNullException(nameof(componentName));

            if (_componentNames.Contains(componentName))
                throw new ArgumentException($"A component with name {componentName} has already been registered.", nameof(componentName));

            _componentNames.Add(componentName);
        }

        public void UseDefaultSettings()
        {
            Settings = new Dictionary<string, IDictionary<string, string>>();
        }
    }
}
