using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMMLDotNetCore.Shared.Model
{
    public class AdoDotNetParameterModel
    {
        public AdoDotNetParameterModel()
        {
        }

        public AdoDotNetParameterModel(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public object Value { get; set; }
    }
}
