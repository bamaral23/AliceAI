using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI
{
    class State
    {
        private Field selectedField;
        public String stateContext {get; }

        public State(String initialState)
        {
            this.stateContext = initialState;
        }

        public String getStateContext()
        {
            return this.stateContext;
        }
        
        public bool Equals(State state)
        {
            return this.stateContext == state.getStateContext();
        }
    }
}
