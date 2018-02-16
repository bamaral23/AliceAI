using AliceAI.Fields.FieldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI.Fields
{
    class FieldFactory
    {

        public static Field Build(String name, String Id, int Length, FieldFormat fieldFormat, params String[] exampleValue)
        {
            Field response = null;
            switch (fieldFormat)
            {
                case FieldFormat.String:
                    response = new StringField(name, Id, Length, exampleValue[0]);
                    break;
                case FieldFormat.Enum:
                    response = new EnumField(name, Id, Length, exampleValue);
                    break;
            }
            return response;
        }
    }
}
