using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI
{
    class FieldLoader
    {

        public static List<Field> loadFields()
        {
            List<Field> fields = new List<Field>();
            fields.Add(new Field("23"));

            return fields;
        }
    }
}
