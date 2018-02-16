using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI.Fields.FieldTypes
{
    class StringField : SingleValueField
    {
        public String exampleValue {get; }

        public StringField(string name, string Id, int Length, string exampleValue) : base(name, Id, Length, FieldFormat.String, exampleValue)
        {
        }
    }
}
