﻿using PipelineFramework.Core.Abstractions;
using PipelineFramework.Core.Builder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Builder
{
    internal abstract class PipelineBuilderBase<TPipeline, TComponentBase, TPayload> :
        IPipelineBuilder<TPipeline>,
        ISettingsHolder<TPipeline>,
        IAdditionalPipelineComponentHolder<TPipeline, TComponentBase, TPayload>
        where TPipeline : IPipeline
        where TComponentBase : IPipelineComponent
    {
        protected readonly PipelineBuilderState State;

        protected PipelineBuilderBase()
        {
            State = new PipelineBuilderState();
        }


        public abstract TPipeline Build();

        public IAdditionalPipelineComponentHolder<TPipeline, TComponentBase, TPayload> WithComponent<TComponent>() where TComponent : TComponentBase
        {
            State.AddComponent(typeof(TComponent));
            return this;
        }

        public IAdditionalPipelineComponentHolder<TPipeline, TComponentBase, TPayload> WithComponent(string componentName)
        {
            State.AddComponent(componentName);
            return this;
        }

        public ISettingsHolder<TPipeline> WithComponentResolver(IPipelineComponentResolver componentResolver)
        {
            State.ComponentResolver = componentResolver;
            return this;
        }

        public IPipelineBuilder<TPipeline> WithNoSettings()
        {
            State.UseDefaultSettings();
            return this;
        }

        public IPipelineBuilder<TPipeline> WithSettings(IDictionary<string, IDictionary<string, string>> settings)
        {
            State.Settings = settings;
            return this;
        }
      
    }
}
