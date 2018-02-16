using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI.Fields.FieldTypes
{
    class MultiValueField : Field
    {
        public String[] AvailabletValue { get; }

        public MultiValueField(String name, String Id, int Length, FieldFormat FieldFormat, params String[] Values) : base(name, Id, Length, FieldFormat)
        {
            this.AvailabletValue = Values;
        }
    }
}
