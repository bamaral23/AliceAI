using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI
{
    class Action
    {
        private String name;
        private Func<State, State> function;

        public Action (String name, Func<State, State> function)
        {
            this.name = name;
            this.function = function;
        }

        public State Apply(State state)
        {
            return function(state);
        }

        public override String ToString()
        {
            return this.name;
        }
    }
}
