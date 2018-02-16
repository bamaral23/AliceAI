using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI.Fields.FieldTypes
{
    class SingleValueField : Field
    {
        public String DefaultValue { get; }

        public SingleValueField(String name, String Id, int Length, FieldFormat FieldFormat, String DefaultValue) : base(name, Id, Length, FieldFormat)
        {
            this.DefaultValue = DefaultValue;
        }
    }
}
