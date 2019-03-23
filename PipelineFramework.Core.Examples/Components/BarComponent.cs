﻿using PipelineFramework.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Examples.Components
{
    public class BarComponent : AsyncPipelineComponentBase<ExamplePipelinePayload>
    {
        public override async Task<ExamplePipelinePayload> ExecuteAsync(ExamplePipelinePayload payload, CancellationToken cancellationToken)
        {
            payload.Result = await Task.Run(() =>
            {
                return new Random().Next(100);
            }, cancellationToken);

            payload.Messages.Add($"Component {Name} called external api and returned result {payload.Result}");

            return payload;
        }
    }

    public class BarComponentNonAsync : PipelineComponentBase<ExamplePipelinePayload>
    {
       
        public override ExamplePipelinePayload Execute(ExamplePipelinePayload payload, CancellationToken cancellationToken)
        {
            payload.Result = new Random().Next(100);

            payload.Messages.Add($"Component {Name} called external api and returned result {payload.Result}");

            return payload;
        }
    }
}
