using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI
{
    class Field
    {
        public String Name { get; }
        public String Id { get; }
        public int Length { get; }
        public FieldFormat FieldFormat { get; }
        public String ExampleValue { get; }

        public Field(String name, String ExampleValue)
        {
            Name = name;
            this.ExampleValue = ExampleValue;
        }
    }

}
