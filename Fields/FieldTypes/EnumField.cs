using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI.Fields.FieldTypes
{
    class EnumField : MultiValueField
    {
        public EnumField(string name, string Id, int Length, params string[] exampleValue) : base(name, Id, Length, FieldFormat.Enum, exampleValue)
        {
        }
    }
}
