using AliceAI.Fields.FieldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Field> fieldsToLearn = new List<Field>();
            fieldsToLearn.Add(new EnumField("MTI", "0", 4, "0800"));
            fieldsToLearn.Add(new EnumField("Processing Code", "3", 6, "003000"));
            fieldsToLearn.Add(new StringField("Transmission Date", "7", 14, "0128171600"));
            fieldsToLearn.Add(new StringField("Stan", "11", 6, "012345"));
            fieldsToLearn.Add(new StringField("Transaction Time", "12", 6, "171600"));
            fieldsToLearn.Add(new StringField("Transaction Date", "13", 4, "0128"));
            fieldsToLearn.Add(new StringField("Terminal Id", "41", 8, "01234567"));
            fieldsToLearn.Add(new StringField("Merchant Id", "42", 15, "123456789012345"));
            foreach(Field field in fieldsToLearn)
            {
                learnField(field);
            }
            Console.ReadLine();

        }

        private static void learnField(Field targetField)
        {
            State goalState = null;
            goalState = CreateState(targetField, goalState);
            Alice alice = new Alice(goalState);
            bool result = alice.learn(new State(""));
            if (result)
            {
                Console.WriteLine("Successfully learned field " + targetField.Name);
                foreach (Action action in alice.actionList)
                {
                    Console.WriteLine(action.ToString() + "\n");
                }
            }
            else
            {
                Console.WriteLine("Failed to learn field " + targetField.Name + "\n");
            }
        }

        private static State CreateState(Field targetField, State goalState)
        {
            if (targetField is SingleValueField)
            {
                goalState = new State(((SingleValueField)targetField).DefaultValue);
            }
            else if (targetField is MultiValueField)
            {
                goalState = new State(((MultiValueField)targetField).AvailabletValue[0]);
            }

            return goalState;
        }
    }

}
