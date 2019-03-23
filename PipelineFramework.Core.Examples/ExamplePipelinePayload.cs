using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework.Core.Examples
{
    public class ExamplePipelinePayload
    {
        public ExamplePipelinePayload()
        {
            Messages = new List<string>();
        }

        public Guid FooKey { get; set; }
        public List<string> Messages { get; set; }
        public int Result { get; set; }
    }
}
