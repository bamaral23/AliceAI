using AliceAI.Fields;
using AliceAI.Fields.FieldTypes;
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
            fields.Add(FieldFactory.Build("MTI", "0", 4, FieldFormat.Enum, "2800", "0800"));
            fields.Add(FieldFactory.Build("Processing Code", "3", 6, FieldFormat.Enum, "003000"));
            fields.Add(FieldFactory.Build("Transmission Date", "7", 14, FieldFormat.String, "20180128171600"));
            fields.Add(FieldFactory.Build("Stan", "11", 6, FieldFormat.String, "012345"));
            fields.Add(FieldFactory.Build("Transaction Time", "12", 14, FieldFormat.String, "20180128171600"));
            fields.Add(FieldFactory.Build("Acquirer Id", "32", 2, FieldFormat.String, "02"));
            fields.Add(FieldFactory.Build("Terminal Id", "41", 8, FieldFormat.String, "01234567"));
            fields.Add(FieldFactory.Build("Merchant Id", "42", 15, FieldFormat.String, "123456789012345"));
            return fields;
        }
    }
}
