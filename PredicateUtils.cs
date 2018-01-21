using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceAI
{
    class PredicateUtils
    {

        public static Predicate<State> IsFieldSelected()
        {
            return currentState => currentState.selectedField != null;
        }

        public static Predicate<State> IsStateFull(State GoalState)
        {
            return currentState => (currentState.stateContext.Length >= GoalState.stateContext.Length);
        }

        public static Predicate<State> Not(Predicate<State> predicate)
        {
            return x => !predicate(x);
        }

        public static Predicate<State> And(Predicate<State> predicate1, Predicate<State> predicate2)
        {
            return x => predicate1(x) && predicate2(x);
        }

        public static Predicate<State> Or(Predicate<State> predicate1, Predicate<State> predicate2)
        {
            return x => predicate1(x) || predicate2(x);
        }
    }
}
