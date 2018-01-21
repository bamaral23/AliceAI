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

        public State(Field selectedField)
        {
            this.stateContext = selectedField.ExampleValue;
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
