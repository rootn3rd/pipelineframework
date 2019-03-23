using PipelineFramework.Core.Abstractions;
using PipelineFramework.Core.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core
{
    internal class Settings : IDictionary<string, string>
    {
        private readonly IDictionary<string, string> _settings;
        private readonly IPipelineComponent _component;

        public Settings(IPipelineComponent component)
        {
            _component = component;
            _settings = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get
            {
                if (!_settings.ContainsKey(key))
                    throw new PipelineComponentSettingNotFoundException(_component, key);

                return _settings[key];
            }
            set => _settings[key] = value;
        }

        public ICollection<string> Keys => _settings.Keys;

        public ICollection<string> Values => _settings.Values;

        public int Count => _settings.Count;

        public bool IsReadOnly => _settings.IsReadOnly;

        public void Add(string key, string value)
        {
            _settings.Add(key, value);
        }

        public void Add(KeyValuePair<string, string> item)
        {
            _settings.Add(item);
        }

        public void Clear()
        {
            _settings.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return _settings.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return _settings.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            _settings.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _settings.GetEnumerator();


        public bool Remove(string key)
        {
            return _settings.Remove(key);

        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            return _settings.Remove(item);
        }

        public bool TryGetValue(string key, out string value)
        {
            return _settings.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
