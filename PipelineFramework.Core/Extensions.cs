using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core
{
    public static class Extensions
    {
        public static void AddRange(
            this IDictionary<string, string> settings,
            IEnumerable<KeyValuePair<string, string>> config)
        {
            foreach (var item in config)
            {
                settings.Add(item);
            }
        }

        public static T GetSettingValue<T>(
            this IDictionary<string, string> settings,
            string name,
            bool throwOnSettingNotFound = true
            )
        {
            return settings.GetSettingValue(name).Convert<T>();
        }


        public static T GetSettingValue<T>(
         this IDictionary<string, string> settings,
         string name,
         T defaultValue,
         bool throwOnSettingNotFound = true)
        {
            return settings.GetSettingValue(name, throwOnSettingNotFound).Convert(defaultValue);
        }

        public static string GetSettingValue(
           this IDictionary<string, string> settings,
           string name,
           bool throwOnSettingNotFound = true)
        {
            if (throwOnSettingNotFound) return settings[name];

            return settings.ContainsKey(name) ? settings[name] : null;
        }

        public static T Convert<T>(this string s, T defaultValue)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                return (T)converter.ConvertFromString(s);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static T Convert<T>(this string s)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromString(s);
        }
    }
}
