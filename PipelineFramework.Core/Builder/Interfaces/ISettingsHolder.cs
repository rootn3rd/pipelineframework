using PipelineFramework.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Builder.Interfaces
{
    public interface ISettingsHolder<out TPipeline> where TPipeline : IPipeline
    {
        IPipelineBuilder<TPipeline> WithSettings(IDictionary<string, IDictionary<string, string>> settings);

        IPipelineBuilder<TPipeline> WithNoSettings();
    }
}
