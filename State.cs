using AliceAI.Fields.FieldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI
{
    class State
    {
        public Field selectedField {get; }
        public String stateContext {get; }

        public State(String initialState)
        {
            this.stateContext = initialState;
        }

        public State(SingleValueField selectedField)
        {
            this.stateContext = selectedField.DefaultValue;
            this.selectedField = selectedField;
        }

        public State(MultiValueField selectedField, int index)
        {
            this.stateContext = selectedField.AvailabletValue[index];
            this.selectedField = selectedField;
        }


        public State(String context, Field selectedField)
        {
            this.stateContext = context;
            this.selectedField = selectedField;
        }

        public bool Equals(State state)
        {
            return this.stateContext == state.stateContext;
        }
    }
}
