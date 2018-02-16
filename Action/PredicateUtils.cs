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

        public static Predicate<State> IsFieldFormat(FieldFormat fieldFormat)
        {
            return currentState => currentState.selectedField.FieldFormat.Equals(fieldFormat);
        }

        public static Predicate<State> IsGoalLesser(State Goal)
        {
            return currentState => currentState.stateContext.Length > Goal.stateContext.Length;
        }

        public static Predicate<State> IsContextGreaterThanZero()
        {
            return currentState => currentState.stateContext.Length > 0;
        }

        public static Predicate<State> Not(Predicate<State> predicate)
        {
            return x => !predicate(x);
        }

        public static Predicate<State> And(params Predicate<State>[] predicateList)
        {
            return x => AndList(predicateList, x);
                
        }

        public static Predicate<State> Or(Predicate<State> predicate1, Predicate<State> predicate2)
        {
            return x => predicate1(x) || predicate2(x);
        }

        private static bool AndList(Predicate<State>[] predicateList, State state)
        {
            bool result = true;
            foreach (Predicate<State> predicate in predicateList)
            {
                result = result && predicate(state);
            }
            return result;
        }
    }
}
