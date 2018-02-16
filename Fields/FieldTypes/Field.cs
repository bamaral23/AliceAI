using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI.Fields.FieldTypes
{
    class Field
    {
        public String Name { get; }
        public String Id { get; }
        public int Length { get; }
        public FieldFormat FieldFormat { get; }
        
        public Field(String name, String Id, int Length, FieldFormat FieldFormat)
        {
            Name = name;
            this.Id = Id;
            this.Length = Length;
            this.FieldFormat = FieldFormat;
        }
    }
}
